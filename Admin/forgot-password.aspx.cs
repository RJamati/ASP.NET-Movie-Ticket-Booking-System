using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;
using System.Net.Mail;

public partial class Admin_forgot_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void ContBtn_Click(object sender, EventArgs e)
    {
        if (TxtEmailAddressForPassword.Text != "")
        {
            string Email = "";
            if (RdbtnPassword.Checked == true)
            {
                Email = TxtEmailAddressForPassword.Text;
            }
            else if (RdbtnSignin.Checked == true)
            {
                Email = TxtEmailAddressForSignin.Text;
            }
            else if (RdbtnUserName.Checked == true)
            {
                Email = TxtEmailAddressForUserName.Text;
            }

            DataTable DtUser = loginDetailLogicLayer.GetLoginDataWithEmailId(TxtEmailAddressForPassword.Text.Trim());
            if (DtUser.Rows.Count > 0)
            {
                DtUser.Rows[0]["Password"].ToString();
                #region Message
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                string msg = string.Empty;
                try
                {
                    MailAddress fromAddress = new MailAddress("noreply@gadgets-plus.ca");
                    //MailAddress fromAddress = new MailAddress("contact@kashyapindustries.in ");

                    message.From = fromAddress;
                    message.To.Add(Email);
                    //message.To.Add("contact@kashyapindustries.in ");
                    //message.To.Add("info@kashyapindustries.in ");



                    //if (ccList != null && ccList != string.Empty)
                    //    message.CC.Add(ccList);
                    message.Subject = "Contact";
                    message.IsBodyHtml = true;
                    string MessageDetail = "<table><tr><td>userId :-</td><td>" + Email + "</td> <td>Password :-</td><td>" + DtUser.Rows[0]["Password"].ToString() + "</td></tr></table>";
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
    }
}