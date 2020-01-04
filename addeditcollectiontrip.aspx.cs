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
            Bind();
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

    private void Bind()
    {
        //List<SelectListItem> list = new List<SelectListItem>();
        DataTable dtEmployee = new DataTable();
        DataTable dtCity = new DataTable();
        
        try
        {
            
            Cls_Employee_b clsEmployee = new Cls_Employee_b();
            dtEmployee = clsEmployee.SelectAll();

            cls_CityMaster_b clscity = new cls_CityMaster_b();
            dtCity = clscity.SelectAll();

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
                //System.Web.UI.WebControls.ListItem objListItem = new System.Web.UI.WebControls.ListItem("--Select Employee--", "0");
                //lstemployee.Items.Insert(0, objListItem);
            }
        }
        lstemployee.SelectedIndex = 0;
        if (dtCity != null)
        {
            if (dtCity.Rows.Count > 0)
            {
                Session["city"] = dtCity;
                lstCity.DataSource = dtCity;
                lstCity.DataTextField = "cityname";
                lstCity.DataValueField = "id";
                lstCity.DataBind();
                //System.Web.UI.WebControls.ListItem objListItem = new System.Web.UI.WebControls.ListItem("--Select City--", "0");
                //lstCity.Items.Insert(0, objListItem);
            }
        }
        //lstCity.SelectedIndex = 0;

    }



    private void Clear()
    {
        lstemployee.SelectedIndex = 0;
        lstday.SelectedIndex = 0;
        lstCity.SelectedIndex = 0;
    }

    public void BindTrip(Int64 Id)
    {
        collectiontrip objcollectiontrip = (new Cls_collectiontrip_b().SelectById(Id));
        if (objcollectiontrip != null)
        {
            lstemployee.SelectedValue = objcollectiontrip.empid.ToString();
            hfempid.Value = objcollectiontrip.empid.ToString();
            lstday.SelectedValue = objcollectiontrip.weekday;
            hfday.Value = objcollectiontrip.weekday;
            //lstCity.SelectedValue = objcollectiontrip.cityname;
            hfcity.Value = objcollectiontrip.cityname;
            String[] cityid = objcollectiontrip.cityname.Split(',');
            foreach (string i in cityid)
            {
                lstCity.Items.FindByValue(i).Selected = true;

            }

            //foreach (var item in lstCity.Items)
            //{
            //    if (cityid.Contains(item))
            //        item.Selected = true;
            //}


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

        
        objcollectiontrip.cityname = hfcity.Value;
        objcollectiontrip.empid = Convert.ToInt64(hfempid.Value);
        objcollectiontrip.weekday = hfday.Value;



        if (Request.QueryString["id"] != null)
        {
            objcollectiontrip.id = Convert.ToInt32(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            
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