using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPSnippets.SmsAPI;
using System.Net.Mail;

namespace PlayMovieskp
{
    /// <summary>
    /// Summary description for SmsAndMail
    /// </summary>
    public class SmsAndMail
    {
        public SmsAndMail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

    }
    public class MessageCenter
    {
        public static string SendMsg(string MobileNo, string msg)
        {
            string ans = "";
            try
            {
                SMS.APIType = SMSGateway.Site2SMS;
                SMS.MashapeKey = "f3kYoi2CYdmshQ1kibAbLDR69ElFp1ukuhpjsn1NAnwaybUmvt";
                SMS.Username = "";// txtNumber.Text.Trim();
                SMS.Password = "";//txtPassword.Text.Trim();
                if (MobileNo.IndexOf(",") == -1)
                {
                    //Single SMS
                    SMS.SendSms(MobileNo, msg);
                    ans = "Send Message Sucessfully";
                }
                else
                {
                    //Multiple SMS

                    List<string> numbers = MobileNo.Split(',').ToList();
                    SMS.SendSms(numbers, msg);
                    ans = "Send Message Sucessfully";
                }
            }
            catch (Exception)
            {

                ans = "Send Message Failed";
            }
            return ans;
        }
        public static string SendMail(string txtEmailAddress, string msg)
        {
            #region Message
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg1 = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress("bkp4444@gmail.com");
      

                message.From = fromAddress;
                message.To.Add(txtEmailAddress);
           
                message.Subject = "Contact";
                message.IsBodyHtml = true;
                message.Body = "";
                //smtpClient.Host = "smtp.gmail.com";
                //smtpClient.Host = "smtp.mail.yahoo.com";
                smtpClient.Host = "127.0.0.1";

              
                smtpClient.Port = 25;

                smtpClient.EnableSsl = false;

              
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("bkp4444@gmail.com", "8140371730");
             


                smtpClient.Send(message);



            }

            catch (Exception)
            {
               
            }
            #endregion
            return "";
        }
    }
}