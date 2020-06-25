using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class Admin_ProfileSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["AdminUserId"] != null)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["UserId"] = "1";
                    FillData();
                }
            }
            catch (Exception)
            { }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void FillData()
    {
        DataTable UserDetailDT = loginDetailLogicLayer.GetAllIDWiseloginDetailDetials(Convert.ToString(Session["UserId"]));
        TxtFirstName.Text = Convert.ToString(UserDetailDT.Rows[0]["FirstName"]);
        TxtLastName.Text = Convert.ToString(UserDetailDT.Rows[0]["LastName"]);
        TxtPhoneNumber.Text = Convert.ToString(UserDetailDT.Rows[0]["MobileNumber"]);
        DDlGender.SelectedValue = Convert.ToString(UserDetailDT.Rows[0]["Gender"]);
        txtCity.Text = Convert.ToString(UserDetailDT.Rows[0]["City"]);
        TxtPinCode.Text = Convert.ToString(UserDetailDT.Rows[0]["PostalCode"]);
        txtState.SelectedItem.Text = Convert.ToString(UserDetailDT.Rows[0]["Province"]);
        TxtStreetAddress.Text = Convert.ToString(UserDetailDT.Rows[0]["StreetAddress"]);
    }
    protected void btnPersonalDetailSave_Click(object sender, EventArgs e)
    {
        try
        {
            loginDetailLogicLayer login = new loginDetailLogicLayer();
            login.UserId = Convert.ToString(Session["UserId"]);
            login.ProfileName = TxtFirstName.Text.Trim();
            login.City = txtCity.Text.Trim();
            login.FirstName = TxtFirstName.Text.Trim();
            login.FullAddress = "";
            login.Gender = DDlGender.SelectedItem.Value;
            login.IsAdmin = "1";
            login.LastName = TxtLastName.Text.Trim();
            login.MobileNumber = TxtPhoneNumber.Text.Trim();
            login.PostalCode = TxtPinCode.Text.Trim();
            login.Province = txtState.SelectedItem.Text;
            login.StreetAddress = TxtStreetAddress.Text.Trim();
            login.Updatedate = DateTime.Now.ToString();
            loginDetailLogicLayer.updateloginDetailDetials(login);
            Clear();
            FillData();
           
        }
        catch (Exception)
        {}
    }

    private void Clear()
    {
        txtCity.Text = "";
        TxtFirstName.Text = "";
        TxtLandMark.Text = "";
        TxtLastName.Text = "";
        TxtPhoneNumber.Text = "";
        TxtPinCode.Text = "";
        txtState.SelectedItem.Value = "0";
        TxtStreetAddress.Text = "";
    }
}