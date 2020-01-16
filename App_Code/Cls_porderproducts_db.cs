using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_porderproducts_db
    {

        SqlConnection ConnectionString = new SqlConnection();

        #region Constructor
        public Cls_porderproducts_db()
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
        #endregion

        #region Public Methods
        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porderproducts_SelectAll";
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
        public porderproducts SelectById(Int64 opid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            porderproducts objporderproducts = new porderproducts();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porderproducts_SelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@opid", opid);
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
                                    objporderproducts.opid = Convert.ToInt64(ds.Tables[0].Rows[0]["opid"]);
                                    objporderproducts.oid = Convert.ToInt64(ds.Tables[0].Rows[0]["oid"]);
                                    objporderproducts.uid = Convert.ToInt64(ds.Tables[0].Rows[0]["uid"]);
                                    objporderproducts.pid = Convert.ToInt64(ds.Tables[0].Rows[0]["pid"]);
                                    objporderproducts.brandid = Convert.ToString(ds.Tables[0].Rows[0]["brandid"]);

                                    objporderproducts.sizeid = Convert.ToString(ds.Tables[0].Rows[0]["sizeid"]);
                                    objporderproducts.colorid = Convert.ToString(ds.Tables[0].Rows[0]["colorid"]);
                                    objporderproducts.cart = Convert.ToDecimal(ds.Tables[0].Rows[0]["cart"]);
                                    objporderproducts.pack = Convert.ToString(ds.Tables[0].Rows[0]["pack"]);
                                    objporderproducts.qty = Convert.ToDecimal(ds.Tables[0].Rows[0]["qty"]);

                                    objporderproducts.mrp = Convert.ToDecimal(ds.Tables[0].Rows[0]["mrp"]);
                                    objporderproducts.unitRate = Convert.ToDecimal(ds.Tables[0].Rows[0]["unitRate"]);
                                    objporderproducts.subTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["subTotal"]);
                                    objporderproducts.discount = Convert.ToDecimal(ds.Tables[0].Rows[0]["discount"]);
                                    objporderproducts.scheme = Convert.ToDecimal(ds.Tables[0].Rows[0]["scheme"]);



                                    objporderproducts.taxableamt = Convert.ToDecimal(ds.Tables[0].Rows[0]["taxableamt"]);
                                    objporderproducts.CGSTper = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGSTper"]);
                                    objporderproducts.SGSTper = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGSTper"]);
                                    objporderproducts.IGSTper = Convert.ToDecimal(ds.Tables[0].Rows[0]["IGSTper"]);
                                    objporderproducts.GSTamt = Convert.ToDecimal(ds.Tables[0].Rows[0]["GSTamt"]);
                                    objporderproducts.TotalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAmount"]);

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
            return objporderproducts;
        }
        public Int64 Insert(porderproducts objporderproducts)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porderproducts_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@opid";
                param.Value = objporderproducts.opid;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@oid", objporderproducts.oid);
                cmd.Parameters.AddWithValue("@uid", objporderproducts.uid);
                cmd.Parameters.AddWithValue("@pid", objporderproducts.pid);
                cmd.Parameters.AddWithValue("@brandid", objporderproducts.brandid);
                cmd.Parameters.AddWithValue("@sizeid", objporderproducts.sizeid);
                cmd.Parameters.AddWithValue("@colorid", objporderproducts.colorid);
                cmd.Parameters.AddWithValue("@cart", objporderproducts.cart);
                cmd.Parameters.AddWithValue("@pack", objporderproducts.pack);

                cmd.Parameters.AddWithValue("@qty", objporderproducts.qty);
                cmd.Parameters.AddWithValue("@mrp", objporderproducts.mrp);
                cmd.Parameters.AddWithValue("@unitRate", objporderproducts.unitRate);
                cmd.Parameters.AddWithValue("@subTotal", objporderproducts.subTotal);
                cmd.Parameters.AddWithValue("@discount", objporderproducts.discount);
                cmd.Parameters.AddWithValue("@scheme", objporderproducts.scheme);
                cmd.Parameters.AddWithValue("@taxableamt", objporderproducts.taxableamt);
                cmd.Parameters.AddWithValue("@CGSTper", objporderproducts.CGSTper);

                cmd.Parameters.AddWithValue("@SGSTper", objporderproducts.SGSTper);
                cmd.Parameters.AddWithValue("@IGSTper", objporderproducts.IGSTper);
                cmd.Parameters.AddWithValue("@GSTamt", objporderproducts.GSTamt);
                cmd.Parameters.AddWithValue("@TotalAmount", objporderproducts.TotalAmount);


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
        public Int64 Update(porderproducts objporderproducts)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porderproducts_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@opid";
                param.Value = objporderproducts.opid;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                //cmd.Parameters.AddWithValue("@oid", objporderproducts.oid);
                //cmd.Parameters.AddWithValue("@uid", objporderproducts.uid);
                //cmd.Parameters.AddWithValue("@pid", objporderproducts.pid);
                //cmd.Parameters.AddWithValue("@productprice", objporderproducts.productprice);
                //cmd.Parameters.AddWithValue("@gst", objporderproducts.gst);
                //cmd.Parameters.AddWithValue("@discount", objporderproducts.discount);
                //cmd.Parameters.AddWithValue("@productafterdiscountprice", objporderproducts.discount);
                //cmd.Parameters.AddWithValue("@quantites", objporderproducts.quantites);
                cmd.Parameters.AddWithValue("@oid", objporderproducts.oid);
                cmd.Parameters.AddWithValue("@uid", objporderproducts.uid);
                cmd.Parameters.AddWithValue("@pid", objporderproducts.pid);
                cmd.Parameters.AddWithValue("@brandid", objporderproducts.brandid);
                cmd.Parameters.AddWithValue("@sizeid", objporderproducts.sizeid);
                cmd.Parameters.AddWithValue("@colorid", objporderproducts.colorid);
                cmd.Parameters.AddWithValue("@cart", objporderproducts.cart);
                cmd.Parameters.AddWithValue("@pack", objporderproducts.pack);

                cmd.Parameters.AddWithValue("@qty", objporderproducts.qty);
                cmd.Parameters.AddWithValue("@mrp", objporderproducts.mrp);
                cmd.Parameters.AddWithValue("@unitRate", objporderproducts.unitRate);
                cmd.Parameters.AddWithValue("@subTotal", objporderproducts.subTotal);
                cmd.Parameters.AddWithValue("@discount", objporderproducts.discount);
                cmd.Parameters.AddWithValue("@scheme", objporderproducts.scheme);
                cmd.Parameters.AddWithValue("@taxableamt", objporderproducts.taxableamt);
                cmd.Parameters.AddWithValue("@CGSTper", objporderproducts.CGSTper);

                cmd.Parameters.AddWithValue("@SGSTper", objporderproducts.SGSTper);
                cmd.Parameters.AddWithValue("@IGSTper", objporderproducts.IGSTper);
                cmd.Parameters.AddWithValue("@GSTamt", objporderproducts.GSTamt);
                cmd.Parameters.AddWithValue("@TotalAmount", objporderproducts.TotalAmount);


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
        public bool Delete(Int64 opid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porderproducts_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                cmd.Parameters.AddWithValue("@opid", opid);

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
