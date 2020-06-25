using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Net.Mail;

public partial class Signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                ddltheatres.DataSource = TheatresLogicLayer.GetAllTheatresSelect();
                ddltheatres.DataTextField = "TheatresName";
                ddltheatres.DataValueField = "TheatresNameId";
                ddltheatres.DataBind();
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
    protected void BtnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtEmailAddress.Text != "" && TxtPassword.Text != "" && TxtRepeat.Text != "" && TxtFirstName.Text != "" && TxtLastName.Text != "")
            {
                loginDetailLogicLayer login = new loginDetailLogicLayer();
                login.ProfileName = TxtFirstName.Text.Trim();
                login.FirstName = TxtFirstName.Text.Trim();
                login.EmailAddress = txtEmailAddress.Text.Trim();
                login.Password = TxtPassword.Text.Trim();
                login.IsAdmin = ddlLoginType.SelectedValue.ToString();
                login.LastName = TxtLastName.Text.Trim();
                login.MobileNumber = TxtmobileNo.Text.Trim();
                if (ddlLoginType.SelectedValue.ToString() == "4" || ddlLoginType.SelectedValue.ToString() == "3")
                {
                    login.TheatresId = ddltheatres.SelectedValue.ToString();
                }
                else
                {
                    login.TheatresId = "0";
                }
                login.Entrydate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
                string Ans = loginDetailLogicLayer.InsertloginDetailDetials(login);
                lblMsg.Text = Ans;
                #region Message
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                string msg = string.Empty;
                try
                {
                    MailAddress fromAddress = new MailAddress("softyoug@gmail.com");
                    //MailAddress fromAddress = new MailAddress("contact@kashyapindustries.in ");

                    message.From = fromAddress;
                    message.To.Add(txtEmailAddress.Text);
                    //message.To.Add("contact@kashyapindustries.in ");
                    //message.To.Add("info@kashyapindustries.in ");



                    //if (ccList != null && ccList != string.Empty)
                    //    message.CC.Add(ccList);
                    message.Subject = "Contact";
                    message.IsBodyHtml = true;
                    message.Body = "Thanks for connect gadgets-plus";//" <table><tr><td>Name:</td><td>" + txtName.Text + "</td></tr><tr><td>Email:</td><td>" + txtEmail.Text + "</td></tr><tr><td>Mobile No:</td><td>" + txtMobileNo.Text + "</td></tr><tr><td>Message:</td><td>" + txtMessage.Text + "</td></tr></table>";
                    //smtpClient.Host = "smtp.gmail.com";
                    //smtpClient.Host = "smtp.mail.yahoo.com";
                    smtpClient.Host = "127.0.0.1";

                    // smtpClient.Port = 587;
                    smtpClient.Port = 25;

                    smtpClient.EnableSsl = false;

                    //smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("noreplay@gadgets-plus.ca", "noreplay@ca");
                    //smtpClient.Credentials = new System.Net.NetworkCredential("softyoug@gmail.com", "softyougfriends");

                    //smtpClient.Credentials = new System.Net.NetworkCredential("contact@kashyapindustries.in ", "contact@in");


                    smtpClient.Send(message);



                }
                #endregion
                catch (Exception)
                {
                    //lblError.Text = ex.ToString();
                }
                txtEmailAddress.Text = "";
                TxtFirstName.Text = "";
                TxtLastName.Text = "";
                TxtPassword.Text = "";
                TxtRepeat.Text = "";
              
            }
        }
        catch (Exception)
        { }
    }
    protected void ddlLoginType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLoginType.SelectedValue.ToString() == "4" || ddlLoginType.SelectedValue.ToString() == "3")
        {
            trTheatresLbl.Visible = true;
            trTheatresValues.Visible = true;
        }
        else
        {
            trTheatresLbl.Visible = false;
            trTheatresValues.Visible = false;
        }
    }
}