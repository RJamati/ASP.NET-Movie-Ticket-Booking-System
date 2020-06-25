using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using PlayMovieskp.LogicalLayers;
public partial class website_contact : System.Web.UI.Page
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
    private void GridFill()
    {
       //DataTable dt = TheatresLogicLayer.GetAllTheatresDetials();
        //GridView1.DataSource = dt;
        //GridView1.DataBind();
        ddlCity.DataSource = CityLogicLayer.GetAllCitySelect();
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityId";
        ddlCity.DataBind();
    }
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("contact.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserId"] == null)
            {
                ALogin.Visible = true;
                Lbl2.Visible = true;
                ASignup.Visible = true;
                lbl4.Visible = false;
                ALogOut.Visible = false;
                lbl3.Visible = false;
                GridFill();

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
                GridFill();
            }

            if (Session["UserId"] == null)
            {
                ALogin.Visible = true;
                Lbl2.Visible = true;
                ASignup.Visible = true;
                lbl4.Visible = false;
                ALogOut.Visible = false;
                lbl3.Visible = false;
                GridFill();

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
                GridFill();
            }
        }
      
    }
  
    protected void btnSend_OnClick(object sender, EventArgs e)
    {


       

    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable Dt =  TheatresLogicLayer.GetAllTheatresSelectId(ddlCity.SelectedValue.ToString());

            if (Dt.Rows.Count > 0)
            {
                ddltheatre.DataSource = Dt;
                ddltheatre.DataTextField = "TheatresName";
                ddltheatre.DataValueField = "TheatresNameId";
                ddltheatre.DataBind();
            }
        }
        catch (Exception)
        {
            
         
        }
    }
    protected void ddltheatre_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable Dt = TheatresLogicLayer.GetAllIDWiseTheatresDetials(ddltheatre.SelectedValue.ToString());

            if (Dt.Rows.Count > 0)
            {
                //ddltheatre.DataSource = Dt;
                //ddltheatre.DataTextField = "TheatresName";
                //ddltheatre.DataValueField = "TheatresNameId";
                //ddltheatre.DataBind();
                StMap.Attributes.Add("src", Dt.Rows[0]["LocDetail"].ToString());
                //StMap.InnerHtml = "";
            }
        }
        catch (Exception)
        {


        }
    }
}