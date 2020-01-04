using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class addeditcity : System.Web.UI.Page
{
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindCity(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "UPDATE";
                hPageTitle.InnerText = "Update City";
                Page.Title = "Update City ";
            }
            else
            {
                hPageTitle.InnerText = "New City";
                Page.Title = "New City";
                btnSave.Text = "ADD";
            }
        }
    }

    private void Clear()
    {
        txtcityname.Text = string.Empty;
        
    }

    public void BindCity(Int64 Id)
    {
        CityMaster objCityMaster = (new cls_CityMaster_b().SelectById(Id));
        if (objCityMaster != null)
        {
            txtcityname.Text = objCityMaster.cityname;
            
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managebank.aspx"));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        CityMaster objCityMaster = new CityMaster();
        objCityMaster.cityname= txtcityname.Text.Trim();
        

        if (Request.QueryString["id"] != null)
        {
            objCityMaster.id= Convert.ToInt32(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new cls_CityMaster_b().Update(objCityMaster));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecity.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "City Not Updated";
                BindCity(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new cls_CityMaster_b().Insert(objCityMaster));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecity.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "City Not Inserted";

            }
        }
    }
}