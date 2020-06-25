using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class PersonalInformation : System.Web.UI.Page
{
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("PersonalInformation.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] == null)
            {
                ALogin.Visible = true;
                Lbl2.Visible = true;
                ASignup.Visible = true;
                lbl4.Visible = false;
                ALogOut.Visible = false;
                lbl3.Visible = false;
                Response.Redirect("Default.aspx");

            }
            else
            {
                ALogin.Visible = false;
                Lbl2.Visible = false;
                ASignup.Visible = false;
                lbl4.Visible = true;
                ALogOut.Visible = true;
                lbl3.Visible = true;
                lblUserSettings.Text = Convert.ToString(Session["UserName"]);
                
            }
            if (!Page.IsPostBack)
            {

                //DataTable Order = OrderDetailLogicLayer.GetAllOrderDetailwithproductDetialsUserMaster(Convert.ToString(Session["UserId"]));
                //DataTable CancelOrder = OrderDetailLogicLayer.GetAllOrderDetailwithproductDetialsUserMasterCancel(Convert.ToString(Session["UserId"]));
                //if (Order.Rows.Count > 0)
                //{
                //    lbOrder.Visible = true;
                //}
                //if (CancelOrder.Rows.Count > 0)
                //{
                //    lbCancelorder.Visible = true;
                //} 
                //DisplayRecordForLabel();
            }
            if (Request.Cookies["GadgetPlusCart"] != null)
            {
                HttpCookie aCookie = Request.Cookies["GadgetPlusCart"];
                if (aCookie.Value != "")
                {
                    string sProductID = aCookie.Value;
                    string[] sArrProdID = sProductID.Split('~');
                    //lblCartItemCount.Text = Convert.ToString((sArrProdID.Length - 1) / 7);
                }

            }
            else
            {
               // lblCartItemCount.Text = "0";

            }

        }
        catch (Exception)
        { }
    }
    private void DisplayRecordForLabel()
    {
        DataTable UserDetailDT = loginDetailLogicLayer.GetAllIDWiseloginDetailDetials(Convert.ToString(Session["UserId"]));
        TxtFirstName.Text = Convert.ToString(UserDetailDT.Rows[0]["FirstName"]);
        TxtLastName.Text = Convert.ToString(UserDetailDT.Rows[0]["LastName"]);
        TxtMobileNumber.Text = Convert.ToString(UserDetailDT.Rows[0]["MobileNumber"]);
        TxtLandlineNumber.Text = Convert.ToString(UserDetailDT.Rows[0]["LandLineNumber"]);
        DDlGender.SelectedValue = Convert.ToString(UserDetailDT.Rows[0]["Gender"]);
    }
    protected void btnPersonalDetailSave_Click(object sender, EventArgs e)
    {
        try
        {
            loginDetailLogicLayer login = new loginDetailLogicLayer();
            login.UserId = Convert.ToString(Session["UserId"]);
            login.FirstName = TxtFirstName.Text.Trim();
            login.Gender = DDlGender.SelectedItem.Value;
            login.LastName = TxtLastName.Text.Trim();
            login.Updatedate = DateTime.Now.ToString();
            login.MobileNumber = TxtMobileNumber.Text.Trim();
            loginDetailLogicLayer.updateloginDetailDetialsProfile(login);
            DisplayRecordForLabel();
        }
        catch (Exception)
        { }
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?Id=" + TxtSearch.Text);
    }
}