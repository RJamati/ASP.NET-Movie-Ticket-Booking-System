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

public partial class website_about : System.Web.UI.Page
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
        if (Request.Cookies["GadgetPlusCart"] != null)
        {
            HttpCookie aCookie = Request.Cookies["GadgetPlusCart"];
            if (aCookie.Value != "")
            {
                string sProductID = aCookie.Value;
                string[] sArrProdID = sProductID.Split('~');
              //  lblCartItemCount.Text = Convert.ToString((sArrProdID.Length - 1) / 7);
            }
        }
        else
        {
            //lblCartItemCount.Text = "0";
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
   
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("about.aspx");
    }
}