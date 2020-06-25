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
using System.Net.Mail;
public partial class forgot_Password : System.Web.UI.Page
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
                //lblCartItemCount.Text = Convert.ToString((sArrProdID.Length - 1) / 7);
            }

        }
        else
        {
           // lblCartItemCount.Text = "0";

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
    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?Id=" + TxtSearch.Text);
    }
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        //Response.Redirect("about.aspx");
    }
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        UserMasterLogicLayer User = new UserMasterLogicLayer();
        User.EmailAddress = TxtEmailAddress.Text.Trim();
        DataTable DtUser =  UserMasterLogicLayer.GetLoginDataWithEmailId(User);
        DtUser.Rows[0]["Password"].ToString();

        #region Message
        MailMessage message = new MailMessage();
        SmtpClient smtpClient = new SmtpClient();
        string msg = string.Empty;
        try
        {
            MailAddress fromAddress = new MailAddress("softyoug@gmail.com");
            //MailAddress fromAddress = new MailAddress("contact@kashyapindustries.in ");

            message.From = fromAddress;
            message.To.Add(TxtEmailAddress.Text);
            //message.To.Add("contact@kashyapindustries.in ");
            //message.To.Add("info@kashyapindustries.in ");



            //if (ccList != null && ccList != string.Empty)
            //    message.CC.Add(ccList);
            message.Subject = "Contact";
            message.IsBodyHtml = true;
            string MessageDetail = "<table><tr><td>Enail :-</td><td>" + TxtEmailAddress.Text + "</td></tr></table>";
            message.Body = "Thanks for connect gadgets-plus";//" <table><tr><td>Name:</td><td>" + txtName.Text + "</td></tr><tr><td>Email:</td><td>" + txtEmail.Text + "</td></tr><tr><td>Mobile No:</td><td>" + txtMobileNo.Text + "</td></tr><tr><td>Message:</td><td>" + txtMessage.Text + "</td></tr></table>";
            //smtpClient.Host = "smtp.gmail.com";
            //smtpClient.Host = "smtp.mail.yahoo.com";
            smtpClient.Host = "127.0.0.1";

            // smtpClient.Port = 587;
            smtpClient.Port = 25;

            smtpClient.EnableSsl = false;

            //smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("noreply@gadgets-plus.ca", "noreply@ca");
            //smtpClient.Credentials = new System.Net.NetworkCredential("softyoug@gmail.com", "softyougfriends");

            //smtpClient.Credentials = new System.Net.NetworkCredential("contact@kashyapindustries.in ", "contact@in");


            smtpClient.Send(message);



        }
        catch { }
        #endregion
    }
}