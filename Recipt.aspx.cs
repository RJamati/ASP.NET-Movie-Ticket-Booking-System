using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

public partial class website_Default : System.Web.UI.Page
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
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("Default.aspx");
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            string Id = Convert.ToString(Request.QueryString["Id"]);
            DataTable Dt = BookingSeatLogicLayer.GetAllIDWiseBookedSeatDetials(Id);
            hfMoviesId.Value = Dt.Rows[0]["MovieId"].ToString();
            lblMovieName.Text = Dt.Rows[0]["MoviesName"].ToString();
            ImgAss.ImageUrl = "Admin/MovieImage/" + Dt.Rows[0]["MoviesImage"].ToString();
            lblScreenName.Text = Dt.Rows[0]["ScreenName"].ToString();
            if (Dt.Rows[0]["BookingType"].ToString() == "1")
                lblClass.Text = "Platium";
            else if (Dt.Rows[0]["BookingType"].ToString() == "2")
                lblClass.Text = "Gold";
            else if (Dt.Rows[0]["BookingType"].ToString() == "3")
                lblClass.Text = "Silver";
            lblRate.Text = Dt.Rows[0]["Rate"].ToString();
            lblSeatNo.Text = Dt.Rows[0]["SeatNo"].ToString();
            lblAmt.Text = Dt.Rows[0]["TotalRate"].ToString();
            lblCityName.Text = Dt.Rows[0]["CityName"].ToString();
            lblTheatresName.Text = Dt.Rows[0]["TheatresName"].ToString();
            lblBookDate.Text = Convert.ToDateTime(Dt.Rows[0]["BookingDate"]).ToString("dd-MMM-yyyy");
            if (Dt.Rows[0]["BookingTime"].ToString() == "1")
            lblBookTime.Text = "First";
            else if (Dt.Rows[0]["BookingTime"].ToString() == "2")
                lblBookTime.Text = "Second";
            else if (Dt.Rows[0]["BookingTime"].ToString() == "3")
                lblBookTime.Text = "Evening";
            else if (Dt.Rows[0]["BookingTime"].ToString() == "4")
                lblBookTime.Text = "Night";

            DataTable Dt2 = BookingSeatLogicLayer.GetAllIDWiseBookedCateenDetials(Id);
            int Rate = 0;
            for(int i=0;i<Dt2.Rows.Count;i++)
            {
                Rate = Rate + Convert.ToInt32(Dt.Rows[0]["rate"]);
            }
            lblTotal111.Text = Rate.ToString()+".00";
            if (Dt2.Rows.Count > 0)
            {
                rptBookedCatenlist.DataSource = Dt2;
                rptBookedCatenlist.DataBind();
            }
            else
            {
                H1.Visible = false;
               
            }
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
            }





        }
    }







}