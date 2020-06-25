using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PlayMovieskp.LogicalLayers;

public partial class Admin_Controls_feature_master : System.Web.UI.Page
{
    static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                GridFill();
                //Dt = AdvertisementPackageLogicLayer.GetAllIDWiseAdvertisementPackageDetials("1");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["AdminUserId"] = null;
        Response.Redirect("Default.aspx");
    }
    private void GridFill()
    {
        dt =CateenMasterLogicLayer.GetAllCateenMasterDetials();
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ddlTheatresName.DataSource = TheatresLogicLayer.GetAllTheatresSelect();
        ddlTheatresName.DataTextField = "TheatresName";
        ddlTheatresName.DataValueField = "TheatresNameId";
        ddlTheatresName.DataBind();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave.Text == "SAVE")
        {
           CateenMasterLogicLayer mobile = new CateenMasterLogicLayer();
            String Id = System.IO.Path.GetExtension(FUProductImage.FileName).ToLower();
            mobile.ProductImage= Id;
            mobile.ProductDesc = TxtDesc.Text.Trim();
            mobile.ProductName = TxtProductName.Text.Trim();
            mobile.TheatreId = ddlTheatresName.SelectedValue.ToString();
            mobile.Rate = TxtRate.Text.Trim();
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.EntryBy = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Updateby = "1";
            String str =CateenMasterLogicLayer.InsertCateenMasterDetials(mobile);
            if(str.Length<8)
            {
                FUProductImage.SaveAs(MapPath("~/Admin//Cateen//" + str + Id));
                 LblMessage.Text ="Successfully Save";
            }
            else
            {
                LblMessage.Text ="Detail Not Saved...";
            }
            GridFill();
            Clear();
        }
        else
        {
            CateenMasterLogicLayer mobile = new CateenMasterLogicLayer();
            mobile.CateenId = hfScreenId.Value.ToString();
            String Id = System.IO.Path.GetExtension(FUProductImage.FileName).ToLower();
            if (Id != "")
            {
                mobile.ProductImage = Id;
            }
            else
            {
                mobile.ProductImage = ViewState["MovieImage"].ToString();
            }
            mobile.ProductDesc = TxtDesc.Text.Trim();
            mobile.ProductName = TxtProductName.Text.Trim();
            mobile.TheatreId = ddlTheatresName.SelectedValue.ToString();
            mobile.Rate = TxtRate.Text.Trim();
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.EntryBy = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Updateby = "1";

            LblMessage.Text =CateenMasterLogicLayer.updateCateenMasterDetials(mobile);
            if(Id != "")
            {
                FUProductImage.SaveAs(MapPath("~/Admin//Cateen//" + hfScreenId.Value + Id));
            }
            else
            {

            }
            GridFill();
            Clear();
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        CateenMasterLogicLayer mobile = new CateenMasterLogicLayer();
        mobile.CateenId = hfScreenId.Value.ToString();
        String Id = System.IO.Path.GetExtension(FUProductImage.FileName).ToLower();
        if (Id != "")
        {
            mobile.ProductImage = Id;
        }
        else
        {
            mobile.ProductImage = ViewState["MovieImage"].ToString();
        }
        mobile.ProductDesc = TxtDesc.Text.Trim();
        mobile.ProductName = TxtProductName.Text.Trim();
        mobile.TheatreId = ddlTheatresName.SelectedValue.ToString();
        mobile.Rate = TxtRate.Text.Trim();
        mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.EntryBy = "1";
        mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.Updateby = "1";

        LblMessage.Text = CateenMasterLogicLayer.updateCateenMasterDetials(mobile);
        if (Id != "")
        {
            FUProductImage.SaveAs(MapPath("~/Admin//Cateen//" + hfScreenId.Value + Id));
        }
        else
        {

        }
        GridFill();
        Clear();
    }
    private void Clear()
    {

        TxtRate.Text = "0";
        TxtProductName.Text = "";
        TxtDesc.Text = "";
        ddlTheatresName.SelectedValue = "0";
        BtnSave.Text = "SAVE";
        TableCellPhoneBrand.Visible = false;
        BtnNew.Visible = true;
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfVendorIdDeleted = (HiddenField)row.FindControl("hfMobileBrandId");

        string s = hfVendorIdDeleted.Value;
        LblMessage.Text =CateenMasterLogicLayer.DeleteCateenMasterDetials(s);

        GridFill();
        Clear();
    }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfCampaignIdDeleted = (HiddenField)row.FindControl("hfMobileBrandId");

        string s = hfCampaignIdDeleted.Value;
        try
        {
            DataTable CamaignDetail =CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetials(s);
            hfScreenId.Value = s;
            TxtDesc.Text = CamaignDetail.Rows[0]["ProductDesc"].ToString();
            TxtProductName.Text = CamaignDetail.Rows[0]["ProductName"].ToString();
            TxtRate.Text = CamaignDetail.Rows[0]["Rate"].ToString();
            ddlTheatresName.SelectedValue = CamaignDetail.Rows[0]["TheatreId"].ToString();
            ViewState["MovieImage"] = CamaignDetail.Rows[0]["ProductImage"].ToString();
            BtnSave.Text = "UPDATE";
            TableCellPhoneBrand.Visible = true;
            BtnNew.Visible = false;
        }
        catch (Exception)
        {


        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        Clear();
        LblMessage.Text = "";
    }
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        TableCellPhoneBrand.Visible = true;
        BtnNew.Visible = false;
        LblMessage.Text = "";
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortingDirection = string.Empty;
        if (dir == SortDirection.Ascending)
        {
            dir = SortDirection.Descending;
            sortingDirection = "Desc";
        }
        else
        {
            dir = SortDirection.Ascending;
            sortingDirection = "Asc";
        }

        DataView sortedView = new DataView(dt);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        GridView1.DataSource = sortedView;
        GridView1.DataBind();
    }
    public SortDirection dir
    {
        get
        {
            if (ViewState["dirState"] == null)
            {
                ViewState["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["dirState"];
        }
        set
        {
            ViewState["dirState"] = value;
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        // dt = AccessoriesProductDetailLogicLayer.GetAllProductDetials();
        DataView Dv1 = new DataView(dt);
        Dv1.RowFilter = "ProductName LIKE '" + txtSearchbox.Text + "*'";
        GridView1.DataSource = Dv1.ToTable();
        GridView1.DataBind();
    }
}