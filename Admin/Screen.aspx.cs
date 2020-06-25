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
        dt = ScreenLogicLayer.GetAllScreenDetials();
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ddltheatres.DataSource = TheatresLogicLayer.GetAllTheatresSelect();
        ddltheatres.DataTextField = "TheatresName";
        ddltheatres.DataValueField = "TheatresNameId";
        ddltheatres.DataBind();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave.Text == "SAVE")
        {
            ScreenLogicLayer mobile = new ScreenLogicLayer();
            mobile.ScreenName = TxtScreenName.Text.Trim();
            mobile.TheatresId = ddltheatres.SelectedValue.ToString();
            mobile.GoldRate = TxtGoldRate.Text.Trim();
            mobile.GoldSeat= TxtGoldSeat.Text.Trim();
            mobile.PaltiumSeat = TxtPaltiumSeat.Text.Trim();
            mobile.PaltiumRate = TxtPaltiumRate.Text.Trim();
            mobile.SilverRate = TxtSilverRate.Text.Trim();
            mobile.SilverSeat = TxtSilverSeat.Text.Trim();
            mobile.Entrydate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Entryby = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Updateby = "1";
            LblMessage.Text = ScreenLogicLayer.InsertScreenDetials(mobile);
            GridFill();
            Clear();
        }
        else
        {
            ScreenLogicLayer mobile = new ScreenLogicLayer();
            mobile.ScreenId = hfScreenId.Value.ToString();
            mobile.ScreenName = TxtScreenName.Text.Trim();
            mobile.TheatresId = ddltheatres.SelectedValue.ToString();
            mobile.GoldRate = TxtGoldRate.Text.Trim();
            mobile.GoldSeat = TxtGoldSeat.Text.Trim();
            mobile.PaltiumSeat = TxtPaltiumSeat.Text.Trim();
            mobile.PaltiumRate = TxtPaltiumRate.Text.Trim();
            mobile.SilverRate = TxtSilverRate.Text.Trim();
            mobile.SilverSeat = TxtSilverSeat.Text.Trim();
            mobile.Entrydate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Entryby = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Updateby = "1";

            LblMessage.Text = ScreenLogicLayer.updateScreenDetials(mobile);
            GridFill();
            Clear();
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        ScreenLogicLayer mobile = new ScreenLogicLayer();
     
        mobile.ScreenId = hfScreenId.Value.ToString();
        mobile.ScreenName = TxtScreenName.Text.Trim();
        mobile.TheatresId = ddltheatres.SelectedValue.ToString();
        mobile.GoldRate = TxtGoldRate.Text.Trim();
        mobile.GoldSeat = TxtGoldSeat.Text.Trim();
        mobile.PaltiumSeat = TxtPaltiumSeat.Text.Trim();
        mobile.PaltiumRate = TxtPaltiumRate.Text.Trim();
        mobile.SilverRate = TxtSilverRate.Text.Trim();
        mobile.SilverSeat = TxtSilverSeat.Text.Trim();
        mobile.Entrydate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.Entryby = "1";
        mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.Updateby = "1";
        LblMessage.Text = ScreenLogicLayer.updateScreenDetials(mobile);
        GridFill();
        Clear();
    }
    private void Clear()
    {
       
        TxtGoldRate.Text = "0";
        TxtGoldSeat.Text = "0";
        TxtPaltiumRate.Text = "0";
        TxtPaltiumSeat.Text = "0";
        TxtScreenName.Text = "";
        TxtSilverRate.Text = "0";
        TxtSilverSeat.Text = "0";
        ddltheatres.SelectedValue = "0";

        BtnSave.Text = "SAVE";
        
        TableCellPhoneBrand.Visible = false;
        BtnNew.Visible = true;
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfVendorIdDeleted = (HiddenField)row.FindControl("hfMobileBrandId");

        string s = hfVendorIdDeleted.Value;
        LblMessage.Text = ScreenLogicLayer.DeleteScreenDetials(s);

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
            DataTable CamaignDetail = ScreenLogicLayer.GetAllIDWiseScreenDetials(s);
            hfScreenId.Value = s;
            TxtGoldRate.Text = CamaignDetail.Rows[0]["GoldRate"].ToString();
            TxtGoldSeat.Text = CamaignDetail.Rows[0]["GoldSeat"].ToString();
            TxtPaltiumRate.Text = CamaignDetail.Rows[0]["PaltiumRate"].ToString();
            TxtPaltiumSeat.Text = CamaignDetail.Rows[0]["PaltiumSeat"].ToString();
            TxtScreenName.Text = CamaignDetail.Rows[0]["ScreenName"].ToString();
            TxtSilverRate.Text = CamaignDetail.Rows[0]["SilverRate"].ToString();
            TxtSilverSeat.Text = CamaignDetail.Rows[0]["SilverSeat"].ToString();
            ddltheatres.SelectedValue = CamaignDetail.Rows[0]["TheatresId"].ToString();
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
        Dv1.RowFilter = "ScreenName LIKE '" + txtSearchbox.Text + "*'";
        GridView1.DataSource = Dv1.ToTable();
        GridView1.DataBind();
    }
}