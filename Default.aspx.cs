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
    protected void BtnCity_Click(object sender, EventArgs e)
    {
      
    }
    protected void lBtnCity_Click(object sender, EventArgs e)
    {
        mp1.Hide();
        HttpCookie CityCookies = new HttpCookie("City");
        CityCookies.Value = ddlCity.SelectedValue.ToString();
        CityCookies.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(CityCookies);
    }
    protected void Rptmovies_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "SetVideo")
        {
            DataTable CamaignDetail = MoviesLogicLayer.GetAllIDWiseMoviesDetials(e.CommandArgument.ToString());
            lblVideo.Text = CamaignDetail.Rows[0]["MoviesTrailer"].ToString();
            ModalPopupvideo.Show();
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
        {
          
            ddlCity.DataSource = CityLogicLayer.GetAllCitySelect();
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();

            CityWiseData();
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
   
    protected void DlForDisplayAccessoricesHeader_ItemDataBound(object sender, DataListItemEventArgs e)
    {


        DataRowView drv = e.Item.DataItem as DataRowView;
        string Str = ((Label)e.Item.FindControl("lblDLAssCompanyProductNameId")).Text;
        Repeater innerDataList = e.Item.FindControl("RptAccessories") as Repeater;
      
        innerDataList.DataSource = MoviesLogicLayer.GetAllMoviesDetialsWithTheatres(Str); 
        innerDataList.DataBind();

    }
  
  

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Cookies["City"].Value = ddlCity.SelectedValue.ToString();
        CityWiseData();

    }

    private void CityWiseData()
    {
       // 
        string Id = "";
        if (Request.Cookies["City"] != null)
        {
            //Response.Cookies["City"].Value = ddlCity.SelectedValue.ToString();
            ddlCity.SelectedValue =Request.Cookies["City"].Value;
            Id = Request.Cookies["City"].Value;
        }
        else
        {
            HttpCookie CityCookies = new HttpCookie("City");
            CityCookies.Value = ddlCity.SelectedValue.ToString();
            CityCookies.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(CityCookies);
        }

        DataTable CamaignDetail = CityLogicLayer.GetAllIDWiseCityDetials(Id);
        if (CamaignDetail.Rows.Count > 0)
        {
            lnkbtnCityName.InnerHtml = CamaignDetail.Rows[0]["CityName"].ToString();
            DataTable AccessoricesHeader = MoviesLogicLayer.GetAllMoviesDetialsWithCity(Id);
            DlForDisplayAccessoricesHeader.DataSource = AccessoricesHeader;
            DlForDisplayAccessoricesHeader.DataBind();
            mp1.Hide();
        }
        else
        {
            mp1.Show();
        }
    }
 
}