using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class Bookinglist : System.Web.UI.Page
{
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("PersonalInformation.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] == null)
            {
                ALogin.Visible = true;
                Lbl2.Visible = true;
                ASignup.Visible = true;
                lbl4.Visible = false;
                ALogOut.Visible = false;
                lbl3.Visible = false;
                Response.Redirect("Default.aspx");

            }
            else
            {
                ALogin.Visible = false;
                Lbl2.Visible = false;
                ASignup.Visible = false;
                lbl4.Visible = true;
                ALogOut.Visible = true;
                lbl3.Visible = true;
                lblUserSettings.Text = Convert.ToString(Session["UserName"]);

            }
            if (!Page.IsPostBack)
            {
                Griddatafill("1");

            }


        }
        catch (Exception)
        { }
    }
    protected void GridViewOrderProductDetailsHeader_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gr = (GridView)(e.Row.FindControl("GridViewProductDetailsDetails"));
            if (gr != null)
            {
                Label lblOrderId = (Label)(e.Row.FindControl("lblOrderNo"));
                gr.DataSource = bookingLogicLayer.GetAllIDWisebookingDetialsseatwithUserId(lblOrderId.Text);
                gr.DataBind();
            }
        }

    }
    private void Griddatafill(string Id)
    {
        string FilterId = Session["UserId"].ToString();
        GridViewOrderProductDetailsHeader.DataSource = bookingLogicLayer.GetAllIDWisebookingDetialswithUserId(FilterId);
        GridViewOrderProductDetailsHeader.DataBind();


    }
    //protected void GridViewOrderProductDetailsHeader_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow row = (GridViewRow)GridViewOrderProductDetailsHeader.Rows[e.RowIndex];
    //        Label LblOrderId = (Label)row.FindControl("lblOrderNo");
    //        TextBox txtDocket = (TextBox)row.FindControl("TxtDocket");
    //        TextBox txtCourier = (TextBox)row.FindControl("TxtCourier");
    //        RadioButtonList rb = row.FindControl("RblProcessStates") as RadioButtonList;
    //        OrderDetailLogicLayer Order = new OrderDetailLogicLayer();
    //        Order.OrderId = LblOrderId.Text;
    //        Order.ProductProcess = rb.SelectedValue;
    //        Order.CancelDatetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    //        Order.DispatchDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    //        Order.DeliveryDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    //        Order.Docket = txtDocket.Text;



    //    }
    //    catch (Exception)
    //    {
    //    }
    //}
    decimal totalPrice = 0M;
    decimal totalStock = 0M;
    int totalItems = 0;
    protected void GridViewProductDetailsDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");
                decimal price = Decimal.Parse(lblSubTotal.Text);
                totalPrice += price;
                totalItems += 1;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalSubTotal = (Label)e.Row.FindControl("lblTotalSubTotal");
                lblTotalSubTotal.Text = totalPrice.ToString();
            }
        }
        catch (Exception)
        {
        }
    }

    protected void GridViewOrderProductDetailsHeader_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridViewOrderProductDetailsHeader.Rows[e.RowIndex];
        HiddenField hfCampaignIdDeleted = (HiddenField)row.FindControl("hfBosssokId");

        string s = hfCampaignIdDeleted.Value;

    }
    protected void GridViewProductDetailsDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        //Get the value        
        string strOrderID = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hfBookSessssatId")).Value;

        // GridViewRow row = (GridViewRow)GridViewProductDetailsDetails.Rows[e.RowIndex];
        // HiddenField LblOrderId = (HiddenField)row.FindControl("hfBookSessssatId");
        // string s = LblOrderId.Value;
        //GridViewRow row = (GridViewRow)GridViewProductDetailsDetails.Rows[e.RowIndex];
        //HiddenField hfCampaignIdDeleted = (HiddenField)row.FindControl("hfBookId");


    }


    protected void GridViewOrderProductDetailsHeader_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)GridViewOrderProductDetailsHeader.Rows[e.RowIndex];
            HiddenField hfCampaignIdDeleted = (HiddenField)row.FindControl("hfBosssokId");
            HiddenField HiddenFieldMovieId = (HiddenField)row.FindControl("HiddenFieldMovieId");
            HiddenField HiddenFieldMoviesCount = (HiddenField)row.FindControl("HiddenFieldMoviesCount");
            string s = hfCampaignIdDeleted.Value;
            string MoviesId = HiddenFieldMovieId.Value;
            string MoviesCount = HiddenFieldMoviesCount.Value;
            Response.Redirect("Booking.aspx?ID=" + MoviesId + "&Count=" + MoviesCount+"&OldBookingId="+s);
           // string AAAA = bookingLogicLayer.CancelwithBookingId(s);
        }
        catch (Exception)
        {


        }
       
    }
    protected void GridViewOrderProductDetailsHeader_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
           GridViewRow row = (GridViewRow)GridViewOrderProductDetailsHeader.Rows[e.RowIndex];
        HiddenField hfCampaignIdDeleted = (HiddenField)row.FindControl("hfBosssokId");

        string s = hfCampaignIdDeleted.Value;
        string AAAA =  bookingLogicLayer.CancelwithBookingId(s);
        Griddatafill("1");
        }
        catch (Exception)
        {
            
          
        }
    }
}