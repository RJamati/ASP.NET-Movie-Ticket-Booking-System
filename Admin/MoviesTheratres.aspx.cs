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
        string TheatresId = Session["TheatresId"].ToString();
        dt = MoviesLogicLayer.GetAllMoviesDetialsWithThertresId(TheatresId);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ddlScreenName.DataSource = ScreenLogicLayer.GetAllScreenSelecttherters(TheatresId);
        ddlScreenName.DataTextField = "ScreenName";
        ddlScreenName.DataValueField = "ScreenId";
        ddlScreenName.DataBind();
 
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave.Text == "SAVE")
        {
            MoviesLogicLayer mobile = new MoviesLogicLayer();
            String Id = System.IO.Path.GetExtension(FUMovieImage.FileName).ToLower();
            mobile.Stopbooking = Convert.ToDateTime(TxtMovieBookingStopDate.Text.Trim()).ToString("yyyy-MMM-dd");
            mobile.ExpiryDate = Convert.ToDateTime(TxtmovieOutDate.Text.Trim()).ToString("yyyy-MMM-dd");
            mobile.MoviesDesc = Id;
            mobile.MoviesName = TxtMoviesName.Text.Trim();
            mobile.RealsieDate = Convert.ToDateTime(TxtRealseDate.Text.Trim()).ToString("yyyy-MMM-dd");
            mobile.ScreenId = ddlScreenName.SelectedValue.ToString();
            mobile.Startbooking = Convert.ToDateTime(TxtmovieBookingStartDate.Text.Trim()).ToString("yyyy-MMM-dd");
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Entryby = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Updateby = "1";
            String str = MoviesLogicLayer.InsertMoviesDetials(mobile);
            if (str.Length < 8)
            {
                FUMovieImage.SaveAs(MapPath("~/Admin//MovieImage//" + str + Id));
                LblMessage.Text = "Successfully Save";
            }
            else
            {
                LblMessage.Text = "Detail Not Saved...";
            }
            GridFill();
            Clear();
        }
        else
        {
            MoviesLogicLayer mobile = new MoviesLogicLayer();
            mobile.MoviesId = hfScreenId.Value.ToString();
            String Id = System.IO.Path.GetExtension(FUMovieImage.FileName).ToLower();
            mobile.Stopbooking = Convert.ToDateTime(TxtMovieBookingStopDate.Text.Trim()).ToString("yyyy-MMM-dd");
            mobile.ExpiryDate = Convert.ToDateTime(TxtmovieOutDate.Text.Trim()).ToString("yyyy-MMM-dd");
            if (Id != "")
            {
                mobile.MoviesDesc = Id;
            }
            else
            {
                mobile.MoviesDesc = ViewState["MovieImage"].ToString();
            }
            mobile.MoviesName = TxtMoviesName.Text.Trim();
            mobile.RealsieDate = Convert.ToDateTime(TxtRealseDate.Text.Trim()).ToString("yyyy-MMM-dd");
            mobile.ScreenId = ddlScreenName.SelectedValue.ToString();
            mobile.Startbooking = Convert.ToDateTime(TxtmovieBookingStartDate.Text.Trim()).ToString("yyyy-MMM-dd");
            mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Entryby = "1";
            mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
            mobile.Updateby = "1";

            LblMessage.Text = MoviesLogicLayer.updateMoviesDetials(mobile);
            if (Id != "")
            {
                FUMovieImage.SaveAs(MapPath("~/Admin//MovieImage//" + hfScreenId.Value + Id));
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
        MoviesLogicLayer mobile = new MoviesLogicLayer();
        mobile.MoviesId = hfScreenId.Value.ToString();
        String Id = System.IO.Path.GetExtension(FUMovieImage.FileName).ToLower();
        mobile.Stopbooking = Convert.ToDateTime(TxtMovieBookingStopDate.Text.Trim()).ToString("yyyy-MMM-dd");
        mobile.ExpiryDate = Convert.ToDateTime(TxtmovieOutDate.Text.Trim()).ToString("yyyy-MMM-dd");
        if (Id != "")
        {
            mobile.MoviesDesc = Id;
        }
        else
        {
            mobile.MoviesDesc = ViewState["MovieImage"].ToString();
        }
        mobile.MoviesName = TxtMoviesName.Text.Trim();
        mobile.RealsieDate = Convert.ToDateTime(TxtRealseDate.Text.Trim()).ToString("yyyy-MMM-dd");
        mobile.ScreenId = ddlScreenName.SelectedValue.ToString();
        mobile.Startbooking = Convert.ToDateTime(TxtmovieBookingStartDate.Text.Trim()).ToString("yyyy-MMM-dd");
        mobile.EntryDate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.Entryby = "1";
        mobile.UpdateDate = DateTime.Now.ToString("yyyy-MMM-dd");
        mobile.Updateby = "1";

        LblMessage.Text = MoviesLogicLayer.updateMoviesDetials(mobile);
        if (Id != "")
        {
            FUMovieImage.SaveAs(MapPath("~/Admin//MovieImage//" + hfScreenId.Value + Id));
        }
        else
        {

        }
        RequiredFieldValidator2.Visible = false;
        GridFill();
        Clear();
    }
    private void Clear()
    {

        TxtmovieBookingStartDate.Text = DateTime.Now.ToString();
        TxtMovieBookingStopDate.Text = DateTime.Now.ToString();
        TxtmovieOutDate.Text = DateTime.Now.ToString();
        TxtMoviesName.Text = "0";
        TxtRealseDate.Text = DateTime.Now.ToString();
        ddlScreenName.SelectedValue = "0";

        BtnSave.Text = "SAVE";

        TableCellPhoneBrand.Visible = false;
        BtnNew.Visible = true;
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfVendorIdDeleted = (HiddenField)row.FindControl("hfMobileBrandId");

        string s = hfVendorIdDeleted.Value;
        LblMessage.Text = MoviesLogicLayer.DeleteMoviesDetials(s);

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
            DataTable CamaignDetail = MoviesLogicLayer.GetAllIDWiseMoviesDetials(s);
            hfScreenId.Value = s;
            TxtmovieBookingStartDate.Text = CamaignDetail.Rows[0]["Startbooking"].ToString();
            TxtMovieBookingStopDate.Text = CamaignDetail.Rows[0]["Stopbooking"].ToString();
            TxtmovieOutDate.Text = CamaignDetail.Rows[0]["ExpiryDate"].ToString();
            TxtMoviesName.Text = CamaignDetail.Rows[0]["MoviesName"].ToString();
            TxtRealseDate.Text = CamaignDetail.Rows[0]["RealsieDate"].ToString();
            ddlScreenName.SelectedValue = CamaignDetail.Rows[0]["ScreenId"].ToString();
            ViewState["MovieImage"] = CamaignDetail.Rows[0]["Moviesdesc"].ToString();
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
        Dv1.RowFilter = "MoviesName LIKE '" + txtSearchbox.Text + "*'";
        GridView1.DataSource = Dv1.ToTable();
        GridView1.DataBind();
    }
}