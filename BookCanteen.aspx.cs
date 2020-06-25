using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PlayMovieskp.LogicalLayers;

public partial class BookCanteen : System.Web.UI.Page
{
    [WebMethod]
    public static List<string> GetAutoCompleteData(string username)
    {
        List<string> result = new List<string>();
        DataTable Dt;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Vvw_ProductAutoSearch where ProductName LIKE '%'+@SearchText+'%' ", con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@SearchText", username);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                Dt = ds.Tables[0];
                //rcCorporateMenu.DataSource = Dt;
                //rcCorporateMenu.DataBind();


                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr["ProductName"].ToString());
                }

                return result;
            }
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserId"] == null)
        {
            ALogin.Visible = true;
            Lbl2.Visible = true;
            ASignup.Visible = true;
            lbl4.Visible = false;
            ALogOut.Visible = false;
            lbl3.Visible = false;



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
            if (!Page.IsPostBack)
            {
                hfBookingId.Value = Convert.ToString(Request.QueryString["Bookingid"]);
                DataTable Dt = CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetialsFoodName(hfBookingId.Value.ToString());
                DrpFoodName.DataSource = Dt;
                DrpFoodName.DataTextField = "ProductName";
                DrpFoodName.DataValueField = "CateenId";
                DrpFoodName.DataBind();
                GridFill(hfBookingId.Value.ToString());
                //  ViewState["DtBooking"] = tableBooking;

            }
        }
    }

    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("about.aspx");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            BookingCateenLogicLayer BCL = new BookingCateenLogicLayer();
            BCL.BookingId = hfBookingId.Value.ToString() ;
            BCL.ProductId = DrpFoodName.SelectedValue.ToString();
            BCL.Qty = TextBox1.Text;
            BCL.Rate = LblRs.Text;
            BCL.UserId = Session["UserId"].ToString();
            BCL.EntryBy = Session["UserId"].ToString();
            if (Rdbtn1.Checked == true)
            {
                BCL.Type = "1";
            }
            else if (RdBtn2.Checked == true)
            {
                BCL.Type = "2";
            }

            BookingCateenLogicLayer.InsertBookingCateenDetials(BCL);
            GridFill(hfBookingId.Value.ToString());
        }
        catch (Exception)
        {
            
          
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
         GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfVendorIdDeleted = (HiddenField)row.FindControl("hfBannerId");

        string s = hfVendorIdDeleted.Value;
        BookingCateenLogicLayer.DeleteIDWiseBookingCateenDetials(s);
        GridFill(hfBookingId.Value.ToString());
    }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void BtnSkip_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recipt.aspx?Id=" + hfBookingId.Value.ToString());
    }
    protected void DrpFoodName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           DataTable dt =  CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetialsFoodNameQtyRate(DrpFoodName.SelectedValue.ToString());
           if (dt.Rows.Count > 0)
           {
               LblRs.Text = dt.Rows[0]["Rate"].ToString();
           }
           else
           {
               LblRs.Text = "";
           }
        }
        catch (Exception)
        {
            
           
        }
    }
    private void GridFill(string BoogkingId)
    {
        DataTable dt = CateenMasterLogicLayer.GetAllIDWiseCateenMasterFillGrid(BoogkingId);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //ddltheatres.DataSource = TheatresLogicLayer.GetAllTheatresSelect();
        //ddltheatres.DataTextField = "TheatresName";
        //ddltheatres.DataValueField = "TheatresNameId";
        //ddltheatres.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recipt.aspx?Id=" + hfBookingId.Value.ToString());
    }
}