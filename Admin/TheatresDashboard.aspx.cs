using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Controls_accessory : System.Web.UI.Page
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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["AdminUserId"] = null;
        Response.Redirect("Default.aspx");
    }
}