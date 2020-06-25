using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class Admin_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
                Response.Redirect("Default.aspx");
        }
    }
    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
           
            DataTable UserDetailDT = loginDetailLogicLayer.GetAllIDWiseloginDetailDetials(Convert.ToString(Session["UserId"]));
            if (TxtOldPassword.Text == Convert.ToString(UserDetailDT.Rows[0]["Password"]))
            {
                loginDetailLogicLayer login = new loginDetailLogicLayer();
                login.UserId = Convert.ToString(Session["UserId"]);
                login.Password = TxtNewPassword.Text.Trim();
                login.Updatedate = DateTime.Now.ToString();
                lblErrorMessage .Text = loginDetailLogicLayer.updatePasswordDetials(login);

            }
            else
            {
                lblErrorMessage.Text = "Invalid Password";
            }
        }
        catch (Exception)
        { }
    }
}