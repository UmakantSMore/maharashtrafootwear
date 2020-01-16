using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_porders_db
    {

        SqlConnection ConnectionString = new SqlConnection();

        #region Constructor
        public Cls_porders_db()
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
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porders_SelectAll";
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
            return ds;
        }
        public porders SelectById(Int64 oid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            porders objporders = new porders();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porders_SelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@oid", oid);
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


                                objporders.oid = Convert.ToInt64(ds.Tables[0].Rows[0]["oid"]);
                                objporders.uid = Convert.ToInt64(ds.Tables[0].Rows[0]["uid"]);
                                objporders.paymentType = Convert.ToString(ds.Tables[0].Rows[0]["paymentType"]);
                                objporders.orderno = Convert.ToString(ds.Tables[0].Rows[0]["orderno"]);
                                objporders.invoicetype = Convert.ToString(ds.Tables[0].Rows[0]["invoicetype"]);
                                objporders.paymentMode = Convert.ToString(ds.Tables[0].Rows[0]["paymentMode"]);
                                objporders.orderdate = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["orderdate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[0].Rows[0]["orderdate"]);
                                objporders.subamount = Convert.ToDecimal(ds.Tables[0].Rows[0]["subamount"]);
                                objporders.totalGSTAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["totalGSTAmount"]);
                                objporders.per_tradeDisandScheme = Convert.ToDecimal(ds.Tables[0].Rows[0]["per_tradeDisandScheme"]);
                                objporders.amt_tradeDisandScheme = Convert.ToDecimal(ds.Tables[0].Rows[0]["amt_tradeDisandScheme"]);
                                objporders.per_taxableDiscount = Convert.ToDecimal(ds.Tables[0].Rows[0]["per_taxableDiscount"]);
                                objporders.amt_taxableDiscount = Convert.ToDecimal(ds.Tables[0].Rows[0]["amt_taxableDiscount"]);
                                objporders.TaxableAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxableAmount"]);
                                objporders.TotalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAmount"]);
                                objporders.CGSTamt = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGSTamt"]);
                                objporders.SGSTamt = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGSTamt"]);
                                objporders.IGSTamt = Convert.ToDecimal(ds.Tables[0].Rows[0]["IGSTamt"]);
                                objporders.otheramt = Convert.ToDecimal(ds.Tables[0].Rows[0]["otheramt"]);
                                objporders.freightDiscount = Convert.ToDecimal(ds.Tables[0].Rows[0]["freightDiscount"]);
                                objporders.duedate = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["duedate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[0].Rows[0]["duedate"]);
                                objporders.grandTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["grandTotal"]);
                                objporders.Referenceby = Convert.ToString(ds.Tables[0].Rows[0]["Referenceby"]);
                                objporders.DeliveredThrough = Convert.ToString(ds.Tables[0].Rows[0]["DeliveredThrough"]);
                                objporders.DeliveredDetails = Convert.ToString(ds.Tables[0].Rows[0]["DeliveredDetails"]);
                                objporders.orderstatus = Convert.ToInt64(ds.Tables[0].Rows[0]["orderstatus"]);
                                objporders.ordertype = Convert.ToString(ds.Tables[0].Rows[0]["ordertype"]);
                                objporders.pendingAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["pendingAmt"]);

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
            return objporders;
        }
        public Int64 Insert(porders objporders)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porders_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@oid";
                param.Value = objporders.oid;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@uid", objporders.uid);
                cmd.Parameters.AddWithValue("@paymentType", objporders.paymentType);
                cmd.Parameters.AddWithValue("@invoicetype", objporders.invoicetype);
                cmd.Parameters.AddWithValue("@orderno", objporders.orderno);
                cmd.Parameters.AddWithValue("@paymentMode", objporders.paymentMode);
                cmd.Parameters.AddWithValue("@orderdate", objporders.orderdate);
                cmd.Parameters.AddWithValue("@subamount", objporders.subamount);
                cmd.Parameters.AddWithValue("@totalGSTAmount", objporders.totalGSTAmount);
                cmd.Parameters.AddWithValue("@per_tradeDisandScheme", objporders.per_tradeDisandScheme);
                cmd.Parameters.AddWithValue("@amt_tradeDisandScheme", objporders.amt_tradeDisandScheme);
                cmd.Parameters.AddWithValue("@per_taxableDiscount", objporders.per_taxableDiscount);
                cmd.Parameters.AddWithValue("@amt_taxableDiscount", objporders.amt_taxableDiscount);
                cmd.Parameters.AddWithValue("@TaxableAmount", objporders.TaxableAmount);
                cmd.Parameters.AddWithValue("@TotalAmount", objporders.TotalAmount);
                cmd.Parameters.AddWithValue("@CGSTamt", objporders.CGSTamt);
                cmd.Parameters.AddWithValue("@SGSTamt", objporders.SGSTamt);
                cmd.Parameters.AddWithValue("@IGSTamt", objporders.IGSTamt);
                cmd.Parameters.AddWithValue("@otheramt", objporders.otheramt);
                cmd.Parameters.AddWithValue("@freightDiscount", objporders.freightDiscount);
                cmd.Parameters.AddWithValue("@duedate", objporders.duedate);
                cmd.Parameters.AddWithValue("@grandTotal", objporders.grandTotal);
                cmd.Parameters.AddWithValue("@Referenceby", objporders.Referenceby);
                cmd.Parameters.AddWithValue("@DeliveredThrough", objporders.DeliveredThrough);
                cmd.Parameters.AddWithValue("@DeliveredDetails", objporders.DeliveredDetails);
                cmd.Parameters.AddWithValue("@orderstatus", objporders.orderstatus);
                cmd.Parameters.AddWithValue("@ordertype", objporders.ordertype);
                cmd.Parameters.AddWithValue("@pendingAmt", objporders.pendingAmt);
                cmd.Parameters.AddWithValue("@isconfirmed", objporders.isconfirmed);
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
        public Int64 Update(porders objporders)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porders_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@oid";
                param.Value = objporders.oid;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@uid", objporders.uid);
                cmd.Parameters.AddWithValue("@paymentType", objporders.paymentType);
                cmd.Parameters.AddWithValue("@invoicetype", objporders.invoicetype);
                cmd.Parameters.AddWithValue("@orderno", objporders.orderno);
                cmd.Parameters.AddWithValue("@paymentMode", objporders.paymentMode);
                cmd.Parameters.AddWithValue("@orderdate", objporders.orderdate);
                cmd.Parameters.AddWithValue("@subamount", objporders.subamount);
                cmd.Parameters.AddWithValue("@totalGSTAmount", objporders.totalGSTAmount);
                cmd.Parameters.AddWithValue("@per_tradeDisandScheme", objporders.per_tradeDisandScheme);
                cmd.Parameters.AddWithValue("@amt_tradeDisandScheme", objporders.amt_tradeDisandScheme);
                cmd.Parameters.AddWithValue("@per_taxableDiscount", objporders.per_taxableDiscount);
                cmd.Parameters.AddWithValue("@amt_taxableDiscount", objporders.amt_taxableDiscount);
                cmd.Parameters.AddWithValue("@TaxableAmount", objporders.TaxableAmount);
                cmd.Parameters.AddWithValue("@TotalAmount", objporders.TotalAmount);
                cmd.Parameters.AddWithValue("@CGSTamt", objporders.CGSTamt);
                cmd.Parameters.AddWithValue("@SGSTamt", objporders.SGSTamt);
                cmd.Parameters.AddWithValue("@IGSTamt", objporders.IGSTamt);
                cmd.Parameters.AddWithValue("@otheramt", objporders.otheramt);
                cmd.Parameters.AddWithValue("@freightDiscount", objporders.freightDiscount);
                cmd.Parameters.AddWithValue("@duedate", objporders.duedate);
                cmd.Parameters.AddWithValue("@grandTotal", objporders.grandTotal);
                cmd.Parameters.AddWithValue("@Referenceby", objporders.Referenceby);
                cmd.Parameters.AddWithValue("@DeliveredThrough", objporders.DeliveredThrough);
                cmd.Parameters.AddWithValue("@DeliveredDetails", objporders.DeliveredDetails);
                cmd.Parameters.AddWithValue("@orderstatus", objporders.orderstatus);
                cmd.Parameters.AddWithValue("@ordertype", objporders.ordertype);
                cmd.Parameters.AddWithValue("@pendingAmt", objporders.pendingAmt);

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
        public bool Delete(Int64 oid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "porders_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@oid", oid);
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
        public DataTable Selectporderdetailsbysupplierid(Int64 supplierId)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Selectporderdetailsbysupplierid";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@uid", supplierId);
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


        #endregion

    }

}
