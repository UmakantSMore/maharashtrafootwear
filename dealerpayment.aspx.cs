using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class dealerpayment : System.Web.UI.Page
{
    common ocommon = new common();
    SqlConnection ConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindEmployeeAmount();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Accept Payments";
        }

        if (Request.QueryString["mode"] == "u")
        {
            /*
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Employee Updated Successfully";
            */
        }
        else if (Request.QueryString["mode"] == "i")
        {
            /*
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Employee Inserted Successfully";
            */
        }
        else if (Request.QueryString["mode"] == "a")
        {
            
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Payment Accepted Successfully!!!";
            
        }
    }

    private void BindEmployeeAmount()
    {
        DataTable dtEmployeeAmount = new DataTable();
        SqlDataAdapter da;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dealerpaymentuser_SelectEmployeeWithCollection";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = ConnectionString;
            ConnectionString.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtEmployeeAmount);
        }
        catch (Exception ex) { }
        finally { ConnectionString.Close(); }
        if (dtEmployeeAmount != null)
        {
            if (dtEmployeeAmount.Rows.Count > 0)
            {
                repemployee.DataSource = dtEmployeeAmount;
                repemployee.DataBind();
            }
            else
            {
                repemployee.DataSource = null;
                repemployee.DataBind();
            }
        }
        else
        {
            repemployee.DataSource = null;
            repemployee.DataBind();
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Page.ResolveUrl("~/addeditEmployee.aspx"));
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        //  Int32 BankCount = int.Parse((item.FindControl("lblBankCount") as Label).Text);
        spnMessage.Visible = true;
        //if (BankCount.ToString() == "0")
        //{
        Int32 AgentId = int.Parse((item.FindControl("lblAgentId") as Label).Text);
        bool yes = (new Cls_Employee_b().Delete(AgentId));

        if (yes)
        {
            //BindEmployee();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Employee Deleted Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Employee Not Deleted";
        }

    }


    protected void repBank_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            /*
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditEmployee.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
            */

        }
    }



    protected void lnkAccept_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        spnMessage.Visible = true;
        DataTable dtResult = new DataTable();
        int count = 0;

        Int32 AgentId = int.Parse((item.FindControl("lblAgentId") as Label).Text);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dealerpaymentuser_SelectByEmployeeId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", AgentId);
            cmd.Connection = ConnectionString;
            ConnectionString.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtResult);



            SqlCommand cmdpt = new SqlCommand();
            cmdpt.CommandText = "PaymentTransaction_Insert";
            cmdpt.CommandType = CommandType.StoredProcedure;
            cmdpt.Connection = ConnectionString;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Payid";
            param.Value = 0;
            param.SqlDbType = SqlDbType.BigInt;
            param.Direction = ParameterDirection.InputOutput;
            cmdpt.Parameters.Add(param);



            if (dtResult != null)
            {
                if (dtResult.Rows.Count > 0)
                {
                    foreach (DataRow row in dtResult.Rows) {

                        
                        cmdpt.Parameters.AddWithValue("@FK_uid", row["dealerid"]);

                        cmdpt.Parameters.AddWithValue("@date1", row["paydate"]);
                        cmdpt.Parameters.AddWithValue("@Paidamt", row["amount"]);

                        cmdpt.Parameters.AddWithValue("@Note", row["note"]);

                        cmdpt.Parameters.AddWithValue("@paymentType", row["paymenttype"]);
                        cmdpt.Parameters.AddWithValue("@chequeno", row["chequeno"]);
                        cmdpt.Parameters.AddWithValue("@paymentType1", row["paymenttype1"]);
                        
                        
                        cmdpt.Parameters.AddWithValue("@bankName", row["bankname"]);


                        int t = cmdpt.ExecuteNonQuery();
                        Int64 result = 0;
                        result = Convert.ToInt64(param.Value);
                        if (result != 0) {
                            count++;
                            SqlCommand cmddpuupdate = new SqlCommand();
                            cmddpuupdate.CommandText = "dealerpaymentuser_UpdateStatus";
                            cmddpuupdate.CommandType = CommandType.StoredProcedure;
                            cmddpuupdate.Connection = ConnectionString;

                            SqlParameter paramcmddpuupdate = new SqlParameter();
                            paramcmddpuupdate.ParameterName = "@id";
                            paramcmddpuupdate.Value = row["id"];
                            paramcmddpuupdate.SqlDbType = SqlDbType.BigInt;
                            paramcmddpuupdate.Direction = ParameterDirection.InputOutput;
                            cmddpuupdate.Parameters.Add(paramcmddpuupdate);
                            int tt = cmddpuupdate.ExecuteNonQuery();
                            
                        }

                    }
                }
                /*else
                {
                    repemployee.DataSource = null;
                    repemployee.DataBind();
                }
                */
            }
            /*
            else
            {
                repemployee.DataSource = null;
                repemployee.DataBind();
            }
            */
            //if (count != 0) {

            //    Response.Redirect(Page.ResolveUrl("~/dealerpayment.aspx?mode=a"));


            //}


        }
        catch (Exception ex)
        { }
        finally { ConnectionString.Close(); }
        spnMessage.Style.Add("color", "green");
        spnMessage.InnerText = "Payment Done Successfully!!!";
        BindEmployeeAmount();
    }
}