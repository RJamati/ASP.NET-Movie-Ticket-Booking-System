using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;

public partial class Admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        DataTable uname = MenuMasterLogicLayer.GetUserId(txt_name.Text);
        if (uname.Rows.Count > 0)
        {
            DataTable login = MenuMasterLogicLayer.GetLogin(txt_name.Text, txtPassword.Text);
            if (login.Rows.Count > 0)
            {
                if (Convert.ToString(login.Rows[0]["IsAdmin"]) == "1")
                {
                    Session["AdminUserId"] = Convert.ToString(login.Rows[0]["UserId"]);
                    Session["UserId"] = Convert.ToString(login.Rows[0]["UserId"]);
                    Session["AdminUserName"] = Convert.ToString(login.Rows[0]["ProfileName"]);
                    string ProfileName = Convert.ToString(login.Rows[0]["ProfileName"]);
                    if (ProfileName.Length < 15)
                    {
                        Session["UserName"] = ProfileName;
                    }
                    else
                    {
                        Session["UserName"] = ProfileName.Substring(0, 13) + "..";
                    }
                    Response.Redirect("dashboard.aspx", false);
                }
                else if (Convert.ToString(login.Rows[0]["IsAdmin"]) == "3")
                {
                    Session["AdminUserId"] = Convert.ToString(login.Rows[0]["UserId"]);
                    Session["UserId"] = Convert.ToString(login.Rows[0]["UserId"]);
                    Session["AdminUserName"] = Convert.ToString(login.Rows[0]["ProfileName"]);
                    Session["TheatresId"] = Convert.ToString(login.Rows[0]["TheatresId"]);
                    string ProfileName = Convert.ToString(login.Rows[0]["ProfileName"]);
                    if (ProfileName.Length < 15)
                    {
                        Session["UserName"] = ProfileName;
                    }
                    else
                    {
                        Session["UserName"] = ProfileName.Substring(0, 13) + "..";
                    }
                    Response.Redirect("TheatresDashboard.aspx", false);
                }
                else if (Convert.ToString(login.Rows[0]["IsAdmin"]) == "4")
                {
                    Session["AdminUserId"] = Convert.ToString(login.Rows[0]["UserId"]);
                    Session["UserId"] = Convert.ToString(login.Rows[0]["UserId"]);
                    Session["AdminUserName"] = Convert.ToString(login.Rows[0]["ProfileName"]);
                    Session["TheatresId"] = Convert.ToString(login.Rows[0]["TheatresId"]);
                    string ProfileName = Convert.ToString(login.Rows[0]["ProfileName"]);
                    if (ProfileName.Length < 15)
                    {
                        Session["UserName"] = ProfileName;
                    }
                    else
                    {
                        Session["UserName"] = ProfileName.Substring(0, 13) + "..";
                    }
                    Response.Redirect("CateenDashboard.aspx", false);
                }
                else
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
                    Response.Redirect("../Default.aspx", false);
                }
            }
            else
            {
                lblError.Text = "Error : Invalid Password.";
                txtPassword.Focus();
                txtPassword.Text = "";
            }
        }
        else
        {
            lblError.Text = "Error : Invalid User Id.";
            txt_name.Focus();
            txt_name.Text = "";
        }
    }
    protected void txt_name_TextChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
    }
    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
    }
}
