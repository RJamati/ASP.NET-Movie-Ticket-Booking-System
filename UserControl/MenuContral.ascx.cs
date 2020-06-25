using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class UserControl_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (TxtEmailAddress.Text != "" && TxtPassword.Text != "")
    //        {
    //            UserMasterLogicLayer User = new UserMasterLogicLayer();
    //            User.EmailAddress = TxtEmailAddress.Text.Trim();
    //            User.Password = TxtPassword.Text.Trim();
    //            DataTable LoginDt = UserMasterLogicLayer.GetLoginData(User);
    //            if (LoginDt.Rows.Count > 0)
    //            {
    //                Session["UserId"] = Convert.ToString(LoginDt.Rows[0]["UserId"]);
    //                TxtEmailAddress.Text = "";
    //                TxtPassword.Text = "";
    //                Response.Redirect("Default.aspx");
    //            }

    //        }
    //    }
    //    catch (Exception)
    //    {
    //    }
    //}
    //protected void BtnSignUp_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (TxtSignEmailAddress.Text != "" && txtSignPassword.Text != "" && TxtRepeat.Text != "")
    //        {
    //            UserMasterLogicLayer User = new UserMasterLogicLayer();
    //            User.EmailAddress = TxtSignEmailAddress.Text.Trim();
    //            User.Password = txtSignPassword.Text.Trim();
    //            User.Entrydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    //            UserMasterLogicLayer.InsertUserMasterDetials(User);
    //        }
    //    }
    //    catch (Exception)
    //    { }
    //}
}