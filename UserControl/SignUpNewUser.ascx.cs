using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using PlayMovieskp.LogicalLayers;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using PlayMovieskp;


public partial class UserControl_SignUpNewUser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblerrormsg.Text = "";
        if (!IsPostBack)
        {

            FillCapctha();

        }
    }
    void FillCapctha()
    {

        try
        {

            Random random = new Random();

            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            StringBuilder captcha = new StringBuilder();

            for (int i = 0; i < 6; i++)

                captcha.Append(combination[random.Next(combination.Length)]);

            Session["captcha"] = captcha.ToString();

            imgCaptcha.ImageUrl = "GenCap.aspx?" + DateTime.Now.Ticks.ToString();

        }

        catch
        {



            throw;

        }

    }

    protected void BtnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtEmailAddress.Text != "" && TxtPassword.Text != "" && TxtRepeat.Text != "" && TxtFirstName.Text != "" && TxtLastName.Text != "")
            {
                if (Session["captcha"].ToString() != txtCaptcha.Text)

                   
                   Response.Write("<script>alert('Enter proper Captcha');</script>");
                   
             

                loginDetailLogicLayer login = new loginDetailLogicLayer();
                login.ProfileName = TxtFirstName.Text.Trim();
                login.FirstName = TxtFirstName.Text.Trim();
                login.EmailAddress = txtEmailAddress.Text.Trim();
                login.Password = TxtPassword.Text.Trim();
                login.MobileNumber = TxtMobileNo.Text.Trim();

                login.IsAdmin = "2";
                login.LastName = TxtLastName.Text.Trim();
                login.Entrydate = DateTime.Now.ToString("yyyy-MM-dd");
                string ans = loginDetailLogicLayer.InsertloginDetailDetials(login);
                

                //MessageCenter.SendMsg(TxtMobileNo.Text.Trim(),"Your Registration Have Sucessfull.");
                //MessageCenter.SendMail(txtEmailAddress.Text, "Your Registration Have Sucessfull");
                lblerrormsg.Text = ans;
              
                txtEmailAddress.Text = "";
                TxtFirstName.Text = "";
                TxtLastName.Text = "";
                TxtPassword.Text = "";
                TxtRepeat.Text = "";
                txtCaptcha.Text = "";
                TxtMobileNo.Text = "";
            }

        }
        catch (Exception)
        { }

    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        FillCapctha();
    }
}