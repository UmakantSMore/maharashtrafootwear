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

public partial class addeditcollectiontrip : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindEmployee();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindTrip(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "UPDATE";
                hPageTitle.InnerText = "Update Trip";
                Page.Title = "Update Trip";
            }
            else
            {
                hPageTitle.InnerText = "New Trip";
                Page.Title = "New Trip";
                btnSave.Text = "ADD";
            }
        }
    }

    private void BindEmployee()
    {
        //List<SelectListItem> list = new List<SelectListItem>();
        DataTable dtEmployee = new DataTable();
        
        try
        {
            
            Cls_Employee_b clsEmployee = new Cls_Employee_b();
            dtEmployee = clsEmployee.SelectAll();



        }
        catch { }
        finally { con.Close(); }
        
        if (dtEmployee != null)
        {
            if (dtEmployee.Rows.Count > 0)
            {
                Session["employee"] = dtEmployee;
                lstemployee.DataSource = dtEmployee;
                lstemployee.DataTextField = "employeeName";
                lstemployee.DataValueField = "id";
                lstemployee.DataBind();
                System.Web.UI.WebControls.ListItem objListItem = new System.Web.UI.WebControls.ListItem("--Select Employee--", "0");
                lstemployee.Items.Insert(0, objListItem);
            }
        }
        lstemployee.SelectedIndex = 0;
    }



    private void Clear()
    {
        lstemployee.SelectedIndex = 0;
        lstday.SelectedIndex = 0;
        txtcityname.Text = string.Empty;
    }

    public void BindTrip(Int64 Id)
    {
        collectiontrip objcollectiontrip = (new Cls_collectiontrip_b().SelectById(Id));
        if (objcollectiontrip != null)
        {
            lstemployee.SelectedValue = objcollectiontrip.empid.ToString();
            lstday.SelectedValue = objcollectiontrip.weekday;
            txtcityname.Text = objcollectiontrip.cityname;
            
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managecollectiontrip.aspx"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        collectiontrip objcollectiontrip =  new collectiontrip();

        
        objcollectiontrip.cityname = txtcityname.Text.Trim();



        if (Request.QueryString["id"] != null)
        {
            objcollectiontrip.id = Convert.ToInt32(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            objcollectiontrip.weekday = lstday.SelectedValue;
            objcollectiontrip.empid = Convert.ToInt64(lstemployee.SelectedValue);
            
            Result = (new Cls_collectiontrip_b().Update(objcollectiontrip));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecollectiontrip.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Trip Not Updated";
                BindTrip(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            objcollectiontrip.empid = Convert.ToInt64(hfempid.Value);
            objcollectiontrip.weekday = hfday.Value;

            Result = (new Cls_collectiontrip_b().Insert(objcollectiontrip));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecollectiontrip.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Trip Not Inserted";

            }
        }
    }

    
    
}