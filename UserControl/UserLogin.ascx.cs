using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class UserControl_UserLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtEmailAddress.Text != "" && TxtPassword.Text != "")
            {
                UserMasterLogicLayer User = new UserMasterLogicLayer();
                User.EmailAddress = TxtEmailAddress.Text.Trim();
                User.Password = TxtPassword.Text.Trim();
                DataTable login = MenuMasterLogicLayer.GetLogin(TxtEmailAddress.Text, TxtPassword.Text);
                if (login.Rows.Count > 0)
                {
                    
                        Session["UserId"] = Convert.ToString(login.Rows[0]["UserId"]);
                        string ProfileName = Convert.ToString(login.Rows[0]["ProfileName"]);
                        if (ProfileName.Length < 15)
                        {
                            Session["UserName"] = ProfileName;
                        }
                        else
                        {
                            Session["UserName"] = ProfileName.Substring(0, 13) + "..";
                        }
                        Response.Redirect("Default.aspx", false);
                    
                }
                else
                {
                    //txtPassword.Focus();         
                    //txtPassword.Text = "";
                }
                
            }
        }
        catch(Exception)
        {
        }
    }
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}