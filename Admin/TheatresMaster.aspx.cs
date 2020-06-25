using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class Admin_Accessory_Companybrand : System.Web.UI.Page
{
    static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                GridFill();
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
        dt = TheatresLogicLayer.GetAllTheatresDetials();
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ddlCity.DataSource = CityLogicLayer.GetAllCitySelect();
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityId";
        ddlCity.DataBind();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave.Text == "SAVE")
        {
            TheatresLogicLayer mobile = new TheatresLogicLayer();
            mobile.Address = TxtAddress.Text.Trim();
            mobile.TheatresName = TxtTheatreName.Text.Trim();
            mobile.CityId = ddlCity.SelectedValue.ToString();
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.EntryBy = "1";
            mobile.UpdateBy = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.LocDetail  = TxtLoc.Text.Trim();
           
            LblMessage.Text = TheatresLogicLayer.InsertTheatresDetials(mobile);
            GridFill();
            Clear();
        }
        else
        {
            TheatresLogicLayer mobile = new TheatresLogicLayer();
            mobile.TheatresNameId = hfMobileBrandId1.Value;
            mobile.Address = TxtAddress.Text.Trim();
            mobile.TheatresName = TxtTheatreName.Text.Trim();
            mobile.CityId = ddlCity.SelectedValue.ToString();
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.EntryBy = "1";
            mobile.UpdateBy = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.LocDetail = TxtLoc.Text.Trim();
            LblMessage.Text = TheatresLogicLayer.updateTheatresDetials(mobile);
            GridFill();
            Clear();
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        TheatresLogicLayer mobile = new TheatresLogicLayer();
        mobile.TheatresNameId = hfMobileBrandId1.Value;
        mobile.Address = TxtAddress.Text.Trim();
        mobile.TheatresName = TxtTheatreName.Text.Trim();
        mobile.CityId = ddlCity.SelectedValue.ToString();
        mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.EntryBy = "1";
        mobile.UpdateBy = "1";
        mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
        LblMessage.Text = TheatresLogicLayer.updateTheatresDetials(mobile);
        GridFill();
        Clear();

    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        Clear();
        LblMessage.Text = "";
    }
    private void Clear()
    {
        TxtAddress.Text = "";
        TxtTheatreName.Text = "";
        ddlCity.SelectedValue = "0";
        BtnSave.Text = "SAVE";
        //btn_save.Text = "SAVE";
        //BtnUpdate.Enabled = false;
        TableAccessoriesBrand.Visible = false;
        BtnNew.Visible = true;
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfVendorIdDeleted = (HiddenField)row.FindControl("hfMobileBrandId");
        string s = hfVendorIdDeleted.Value;
        LblMessage.Text = TheatresLogicLayer.DeleteTheatresDetials(s);
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
            DataTable CamaignDetail = TheatresLogicLayer.GetAllIDWiseTheatresDetials(s);
            hfMobileBrandId1.Value = s;
            TxtAddress.Text = CamaignDetail.Rows[0]["Address"].ToString();
            TxtTheatreName.Text = CamaignDetail.Rows[0]["TheatresName"].ToString();
            ddlCity.SelectedValue = CamaignDetail.Rows[0]["CityId"].ToString();
            BtnSave.Text = "UPDATE";
            //btn_save.Text = "UPDATE";
            TableAccessoriesBrand.Visible = true;
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
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        TableAccessoriesBrand.Visible = true;
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
        dt = TheatresLogicLayer.GetAllTheatresDetials();
        DataView Dv1 = new DataView(dt);
        Dv1.RowFilter = "TheatresName LIKE '" + txtSearchbox.Text + "*'";
        dt = Dv1.ToTable();
        GridView1.DataSource = Dv1.ToTable();
        GridView1.DataBind();
    }
}