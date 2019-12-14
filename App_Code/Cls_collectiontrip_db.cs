using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_collectiontrip_db
    {
        SqlConnection ConnectionString = new SqlConnection();
        public Cls_collectiontrip_db()
        {
            string name = string.Empty;
            string conname = string.Empty;
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                foreach (ConnectionStringSettings connection in connections)
                {
                    name = connection.Name;
                }
                conname = "" + name + "";
            }
            ConnectionString.ConnectionString = ConfigurationManager.ConnectionStrings[conname].ConnectionString;
        }

        #region Public Methods


        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "collectiontrip_SelectAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                ConnectionString.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return null;
            }
            finally
            {
                ConnectionString.Close();
            }
            return ds.Tables[0];
        }

        public collectiontrip SelectById(Int64 bankid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            collectiontrip objcollectiontrip = new collectiontrip();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "collectiontrip_SelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", bankid);
                ConnectionString.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                {
                                    // id, weekday, cityname, empid, empname, isdeleted

                                    objcollectiontrip.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objcollectiontrip.empid = Convert.ToInt64(ds.Tables[0].Rows[0]["empid"]);
                                    objcollectiontrip.weekday= Convert.ToString(ds.Tables[0].Rows[0]["weekday"]);
                                    objcollectiontrip.cityname = Convert.ToString(ds.Tables[0].Rows[0]["cityname"]);
                                    objcollectiontrip.empname = Convert.ToString(ds.Tables[0].Rows[0]["empname"]);
                                    

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return null;
            }
            finally
            {
                ConnectionString.Close();
            }
            return objcollectiontrip;
        }

        public Int64 Insert(collectiontrip objcollectiontrip)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "collectiontrip_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;


                // id, weekday, cityname, empid, empname, isdeleted

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcollectiontrip.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@weekday", objcollectiontrip.weekday);
                cmd.Parameters.AddWithValue("@cityname", objcollectiontrip.cityname);
                cmd.Parameters.AddWithValue("@empid", objcollectiontrip.empid);
                



                ConnectionString.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt64(param.Value);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
            finally
            {
                ConnectionString.Close();
            }
            return result;
        }

        public Int64 Update(collectiontrip objcollectiontrip)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "collectiontrip_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;


                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcollectiontrip.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@weekday", objcollectiontrip.weekday);
                cmd.Parameters.AddWithValue("@cityname", objcollectiontrip.cityname);
                cmd.Parameters.AddWithValue("@empid", objcollectiontrip.empid);


                ConnectionString.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt64(param.Value);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
            finally
            {
                ConnectionString.Close();
            }
            return result;
        }

        public bool Delete(Int64 agentid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "collectiontrip_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                cmd.Parameters.AddWithValue("@id", agentid);

                ConnectionString.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                ConnectionString.Close();
            }
            return true;
        }


        #endregion


    }

}
