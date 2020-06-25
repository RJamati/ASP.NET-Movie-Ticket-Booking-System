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
        if (Session["AdminUserId"] != null)
        {
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        DataTable uname = MenuMasterLogicLayer.GetUserId(txt_name.Text);
        if (uname.Rows.Count > 0)
        {
            DataTable login = MenuMasterLogicLayer.GetLogin(txt_name.Text, txtPassword.Text);
            if (login.Rows.Count > 0)
            {
                Session["AdminUserId"] = Convert.ToString(login.Rows[0]["LoginId"]);
                Response.Redirect("dashboard.aspx", false);
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
