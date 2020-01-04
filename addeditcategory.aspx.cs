using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
public partial class addeditcategory : System.Web.UI.Page
{
    int categoryImageFrontWidth = 500;
    int categoryImageFrontHeight = 605;
    string categoryMainPath = "~/uploads/category/";
    string categoryFrontPath = "~/uploads/category/front/";
    common ocommon = new common();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindMainCategory();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Update Category";
                Page.Title = "Update Category";
            }
            else
            {
                hPageTitle.InnerText = "New Category";
                Page.Title = "New Category";
                btnSave.Text = "Add";
                txtCategoryDiscount.Text = "0";
                txtActualPrice.Text = "0";
            }
        }
    }

    private void Clear()
    {
        lstmaincategory.SelectedIndex = 0;
        txtCategoryName.Text = string.Empty;
        txtActualPrice.Text = string.Empty;
        txtCategoryDiscount.Text = string.Empty;
        txtCategoryShortDescription.Text = string.Empty;
        txtCategoryLongDescription.Text = string.Empty;
        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        imgCategory.Visible = false;
        ViewState["fileName"] = null;
    }


    private void BindMainCategory()
    {
        DataTable dtMainCategory = (new Cls_maincategory_b().SelectAll());
        if (dtMainCategory != null)
        {
            if (dtMainCategory.Rows.Count > 0)
            {
                lstmaincategory.DataSource = dtMainCategory;
                lstmaincategory.DataTextField = "name";
                lstmaincategory.DataValueField = "id";
                lstmaincategory.DataBind();
                ListItem objListItem = new ListItem("--Select Main Category--", "0");
                lstmaincategory.Items.Insert(0, objListItem);
            }
        }
        
    }

    //private void BindBank()
    //{
    //    DataTable dtBank = (new Cls_bankmaster_b().SelectAll());
    //    if (dtBank != null)
    //    {
    //        if (dtBank.Rows.Count > 0)
    //        {
    //            ddlBank.DataSource = dtBank;
    //            ddlBank.DataTextField = "bankname";
    //            ddlBank.DataValueField = "bankid";
    //            ddlBank.DataBind();
    //            ListItem objListItem = new ListItem("--Select Bank--", "0");
    //            ddlBank.Items.Insert(0, objListItem);
    //        }
    //    }
    //}

    public void BindCategory(Int64 CategoryId)
    {
        
        category objcategory = (new Cls_category_b().SelectById(CategoryId));
        if (objcategory != null)
        {
            //ddlBank.SelectedValue = objcategory.bankid.ToString();
            txtCategoryName.Text = objcategory.categoryname;
            txtCategoryShortDescription.Text = objcategory.shortdesc;
            txtCategoryLongDescription.Text = objcategory.longdescp;
            hfmaincategory.Value = objcategory.maincategoryid;
            String [] maincatid = objcategory.maincategoryid.Split(',');
            foreach (string i in maincatid) { 
                //lstmaincategory.SelectedValue = i;
                //lstmaincategory.Items[Convert.ToInt16(i)].Selected = true;
            lstmaincategory.Items.FindByValue(i).Selected = true;
            }

            /*
             * 
             *  string[] arr = dtUser.Rows[0]["FK_subAreaId"].ToString().Split(',');
        arr = arr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int j = 0; j < ddlSubArea.Items.Count; j++)
        {
            for (int j1 = 0; j1 < arr.Length; j1++)
            {
                if (ddlSubArea.Items[j].Value.ToString().Trim() == arr[j1].ToString().Trim())
                {
                    ddlSubArea.Items[j].Selected = true;
                }
                else
                {
                }
            }

        }
*/


            if (!string.IsNullOrEmpty(objcategory.imagename))
            {
                imgCategory.Visible = true;
                ViewState["fileName"] = objcategory.imagename;
                imgCategory.ImageUrl = categoryFrontPath + objcategory.imagename;
                btnImageUpload.Visible = false;
                btnRemove.Visible = true;
            }
            else
            {
                btnImageUpload.Visible = true;
            }
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
        base.Render(writer);
    }

    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpCategory.HasFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(fpCategory.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpCategory.FileName);
            fpCategory.SaveAs(MapPath(categoryMainPath + fileName));
            ocommon.CreateThumbnail1("uploads\\category\\", categoryImageFrontWidth, categoryImageFrontHeight, "~/Uploads/category/front/", fileName);
            imgCategory.Visible = true;
            imgCategory.ImageUrl = categoryFrontPath + fileName;
            ViewState["fileName"] = fileName;
            btnRemove.Visible = true;
            btnImageUpload.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        category objcategory = new category();
        objcategory.categoryname = txtCategoryName.Text.Trim();
        objcategory.actualprice = 0;
        objcategory.discountprice = 0;
        objcategory.shortdesc = txtCategoryShortDescription.Text.Trim();
        objcategory.longdescp = txtCategoryLongDescription.Text.Trim();
        //objcategory.bankid = Convert.ToInt32(ddlBank.SelectedValue);
        objcategory.maincategoryid = hfmaincategory.Value;

        if (ViewState["fileName"] != null)
        {
            objcategory.imagename = ViewState["fileName"].ToString();
        }
        if (Request.QueryString["id"] != null)
        {
            //objcategory.maincategoryid = lstmaincategory.SelectedValue;

            objcategory.cid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_category_b().Update(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecategory.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Category Not Updated";
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            //objcategory.maincategoryid = hfmaincategory.Value;

            Result = (new Cls_category_b().Insert(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecategory.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Category Not Inserted";

            }
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        var filePath = Server.MapPath("~/uploads/category/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        var filePath1 = Server.MapPath("~/uploads/category/front/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgCategory.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managecategory.aspx"));
    }
}