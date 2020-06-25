using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PlayMovieskp.LogicalLayers;

public partial class Admin_RegisterUserList : System.Web.UI.Page
{
    static DataTable Product;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                 Product = loginDetailLogicLayer.GetAllloginDetailDetials();
                GridView1.DataSource = Product;
                GridView1.DataBind();
                lblUserList.Text = Product.Rows.Count.ToString();
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
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Product = loginDetailLogicLayer.GetAllloginDetailDetials();
        DataView Dv1 = new DataView(Product);
        if (ddlSearch.SelectedValue.ToString() == "1")
        {
            Dv1.RowFilter = "FirstName LIKE '" + txtSearchbox.Text + "*'";
        }
        else if (ddlSearch.SelectedValue.ToString() == "2")
        {
            Dv1.RowFilter = "StreetAddress LIKE '" + txtSearchbox.Text + "*'";
        }
        else if (ddlSearch.SelectedValue.ToString() == "3")
        {
            Dv1.RowFilter = "MobileNumber LIKE '" + txtSearchbox.Text + "*'";
        }
        else if (ddlSearch.SelectedValue.ToString() == "4")
        {
            Dv1.RowFilter = "EmailAddress LIKE '" + txtSearchbox.Text + "*'";
        }
        else if (ddlSearch.SelectedValue.ToString() == "5")
        {
            Dv1.RowFilter = "PostalCode LIKE '" + txtSearchbox.Text + "*'";
        }
        else if (ddlSearch.SelectedValue.ToString() == "6")
        {
            Dv1.RowFilter = "City LIKE '" + txtSearchbox.Text + "*'";
        }
        else if (ddlSearch.SelectedValue.ToString() == "7")
        {
            Dv1.RowFilter = "Province LIKE '" + txtSearchbox.Text + "*'";
        }
        Product = Dv1.ToTable();
        GridView1.DataSource = Dv1.ToTable();
        GridView1.DataBind();
    }
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = Product;
        GridView1.DataBind();
    }
}