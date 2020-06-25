using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class Admin_Controls_Accessory_brand : System.Web.UI.Page
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
        dt = CityLogicLayer.GetAllCityDetials();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave.Text == "SAVE")
        {
            CityLogicLayer mobile = new CityLogicLayer();
            mobile.CityName = TxtCityName.Text.Trim();
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.EntryBy = "1";
            mobile.UpdateBy = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            LblMessage.Text = CityLogicLayer.InsertCityDetials(mobile);
            GridFill();
            Clear();
        }
        else
        {
            CityLogicLayer mobile = new CityLogicLayer();
            mobile.CityId = hfCityId.Value;
            mobile.CityName = TxtCityName.Text.Trim();
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.EntryBy = "1";
            mobile.UpdateBy = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            LblMessage.Text = CityLogicLayer.updateCityDetials(mobile);
            GridFill();
            Clear();
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        CityLogicLayer mobile = new CityLogicLayer();
        mobile.CityId = hfCityId.Value;
        mobile.CityName = TxtCityName.Text.Trim();
        mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.EntryBy = "1";
        mobile.UpdateBy = "1";
        mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
        LblMessage.Text = CityLogicLayer.updateCityDetials (mobile);
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
        TxtCityName.Text = "";
        BtnSave.Text = "SAVE";
        //btn_save.Text = "SAVE";
        //BtnUpdate.Enabled = false;
        TableCity.Visible = false;
        BtnNew.Visible = true;
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfVendorIdDeleted = (HiddenField)row.FindControl("hfMobileBrandId");
        string s = hfVendorIdDeleted.Value;
        LblMessage.Text = CityLogicLayer.DeleteCityDetials(s);
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
            DataTable CamaignDetail = CityLogicLayer.GetAllIDWiseCityDetials(s);
            hfCityId.Value = s;
            TxtCityName.Text = CamaignDetail.Rows[0]["CityName"].ToString();
            BtnSave.Text = "UPDATE";
            //btn_save.Text = "UPDATE";
            TableCity.Visible = true;
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
        TableCity.Visible = true;
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
        dt = CityLogicLayer.GetAllCityDetials();
        DataView Dv1 = new DataView(dt);
        Dv1.RowFilter = "CityName LIKE '" + txtSearchbox.Text + "*'";
        dt = Dv1.ToTable();
        GridView1.DataSource = Dv1.ToTable();
        GridView1.DataBind();
    }
}