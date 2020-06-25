using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class ProfileSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Default.aspx");
                ALogin.Visible = true;
                Lbl2.Visible = true;
                ASignup.Visible = true;
                Lbl1.Visible = true;

            }
            else
            {
                ALogin.Visible = false;
                Lbl1.Visible = false;
                ASignup.Visible = false;
                Lbl2.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                
                
                DisplayRecordForLabel();
                if (Request.QueryString["Id"] != null)
                {
                    UserAddressMasterLogicLayer.DeleteUserAddressMasterDetials(Convert.ToString(Request.QueryString["Id"]));
                    DisplayRecordForLabel();
                    DivVisiable();
                    Response.Redirect("ProfileSetting.aspx", true);
                }
            }
            
        }
        catch (Exception)
        {}
    }

    private void DisplayRecordForLabel()
    {
        DataTable UserDetailDT = UserMasterLogicLayer.GetAllIDWiseUserMasterDetials(Convert.ToString(Session["UserId"]));
        DlAddresses.DataSource = UserAddressMasterLogicLayer.GetAllIDWiseUserAddressMasterDetials(Convert.ToString(Session["UserId"]));
        DlAddresses.DataBind();
        lblEmailAddress.Text = Convert.ToString(UserDetailDT.Rows[0]["EmailAddress"]);
        lblOldEmailAddress.Text = Convert.ToString(UserDetailDT.Rows[0]["EmailAddress"]);
        TxtName.Text = Convert.ToString(UserDetailDT.Rows[0]["FirstName"]) +" " + Convert.ToString(UserDetailDT.Rows[0]["LastName"]);
        TxtPhoneNumber.Text = Convert.ToString(UserDetailDT.Rows[0]["MobileNumber"]);
        TxtFirstName.Text = Convert.ToString(UserDetailDT.Rows[0]["FirstName"]);
        TxtLastName.Text = Convert.ToString(UserDetailDT.Rows[0]["LastName"]);
        TxtMobileNumber.Text = Convert.ToString(UserDetailDT.Rows[0]["MobileNumber"]);
        TxtLandlineNumber.Text = Convert.ToString(UserDetailDT.Rows[0]["LandLineNumber"]);
        DDlGender.SelectedValue = Convert.ToString(UserDetailDT.Rows[0]["Gender"]);
        
    }

    private void DivVisiable()
    {
        DivAddresses.Visible = true;
        DivChangePassword.Visible = false;
        DivPersonalInformation.Visible = false ;
        DivUpdateEmail.Visible = false;
    }
    protected void btnPersonalDetailSave_Click(object sender, EventArgs e)
    {
        try
        {
            UserMasterLogicLayer User = new UserMasterLogicLayer();
            User.UserId = Convert.ToString(Session["UserId"]);
            User.FirstName = TxtFirstName.Text.Trim();
            User.LastName = TxtLastName.Text.Trim();
            User.MobileNumber = TxtMobileNumber.Text.Trim();
            User.LandLineNumber = TxtLandlineNumber.Text.Trim();
            User.Gender = DDlGender.SelectedValue.ToString();
            UserMasterLogicLayer.UpdateUserMasterPersonalDetials(User);
            DisplayRecordForLabel();
        }
        catch (Exception)
        {}
    }
    protected void btnChagePasswordSave_Click(object sender, EventArgs e)
    {
        try
        {
            UserMasterLogicLayer User = new UserMasterLogicLayer();
            User.UserId = Convert.ToString(Session["UserId"]);
            User.Password = TxtNewPassword.Text.Trim();
            UserMasterLogicLayer.UpdateUserMasterChangePasswordDetials(User);
            DisplayRecordForLabel();
        }
        catch (Exception)
        {}
    }
    protected void BtnAddressSave_Click(object sender, EventArgs e)
    {
        try
        {
            UserAddressMasterLogicLayer User = new UserAddressMasterLogicLayer();
            User.UserId = Convert.ToString(Session["UserId"]);
            string Address = TxtName.Text.Trim() + "<br />" +TxtStreetAddress.Content + TxtLandMark.Text.Trim()+"<br />"+txtCity.Text.Trim()+" "+TxtPinCode.Text.Trim() +"<br />"+ txtState.Text.Trim() +"("+txtCountry.Text.Trim()+")"+ "<br />"+TxtPhoneNumber.Text.Trim();
            User.UserAddress = Address;
            User.entryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            User.DefultAddress = "true";
            UserAddressMasterLogicLayer.InsertUserAddressMasterDetials(User);
            DisplayRecordForLabel();
        }
        catch (Exception)
        {}
    }
    protected void BtnEmailSave_Click(object sender, EventArgs e)
    {
        try
        {
            UserMasterLogicLayer User = new UserMasterLogicLayer();
            User.UserId = Convert.ToString(Session["UserId"]);
            User.EmailAddress = txtNewEmailAddress.Text.Trim();
            UserMasterLogicLayer.UpdateUserMasterChangeEmailDetials(User);
            DisplayRecordForLabel();
        }
        catch (Exception)
        {}
    }
    protected void linkbuttonChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            DivAddresses.Visible = false;
            DivChangePassword.Visible = true;
            DivPersonalInformation.Visible = false;
            DivUpdateEmail.Visible = false;
        }
        catch (Exception)
        {}
    }
    protected void linkbuttonAddresses_Click(object sender, EventArgs e)
    {
        try
        {
            DivAddresses.Visible = true;
            DivChangePassword.Visible = false;
            DivPersonalInformation.Visible = false;
            DivUpdateEmail.Visible = false;
        }
        catch (Exception)
        {}
    }
    protected void linkbuttonPersonalInformation_Click(object sender, EventArgs e)
    {
        try
        {
            DivAddresses.Visible = false;
            DivChangePassword.Visible = false;
            DivPersonalInformation.Visible = true;
            DivUpdateEmail.Visible = false;
        }
        catch (Exception)
        {}
    }
    protected void linkbuttonUpdateEmail_Click(object sender, EventArgs e)
    {
        try
        {
            DivAddresses.Visible = false;
            DivChangePassword.Visible = false;
            DivPersonalInformation.Visible = false;
            DivUpdateEmail.Visible = true;
        }
        catch (Exception)
        {}
    }
}