using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("Default.aspx");
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
                    lblCartItemCount.Text = Convert.ToString((sArrProdID.Length - 1) / 7);
                }

            }
            else
            {
                lblCartItemCount.Text = "0";

            }

        }
        catch (Exception)
        { }
    }
    private void DisplayRecordForLabel()
    {
        //DataTable UserDetailDT = UserMasterLogicLayer.GetAllIDWiseUserMasterDetials(Convert.ToString(Session["UserId"]));
       
       // lblEmailAddress.Text = Convert.ToString(UserDetailDT.Rows[0]["EmailAddress"]);
     

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
                loginDetailLogicLayer.updatePasswordDetials(login);
                TxtNewPassword.Text = "";
                TxtOldPassword.Text = "";
                TxtRepeat.Text = "";
               
            }
            else
            {
            }
        }
        catch (Exception)
        { }
        //try
        //{
        //    UserMasterLogicLayer User = new UserMasterLogicLayer();
        //    User.UserId = Convert.ToString(Session["UserId"]);
        //    User.Password = TxtNewPassword.Text.Trim();
        //    UserMasterLogicLayer.UpdateUserMasterChangePasswordDetials(User);
        //    DisplayRecordForLabel();
        //}
        //catch (Exception)
        //{ }
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?Id=" + TxtSearch.Text);
    }
}