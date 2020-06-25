using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PlayMovieskp.LogicalLayers;

public partial class Admin_ChangeEmailAddress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void BtnEmailAddress_Click(object sender, EventArgs e)
    {
        try
        {
            
            DataTable UserDetailDT = loginDetailLogicLayer.GetAllIDWiseloginDetailDetials(Convert.ToString(Session["UserId"]));
            if (TxtOldEmailAddress.Text == Convert.ToString(UserDetailDT.Rows[0]["EmailAddress"]))
            {
                loginDetailLogicLayer login = new loginDetailLogicLayer();
                login.UserId = Convert.ToString(Session["UserId"]);
                login.EmailAddress = TxtNewEmailAddress.Text.Trim();
                login.Updatedate = DateTime.Now.ToString();
                lblErrorMessage.Text = loginDetailLogicLayer.updateEmailAddressDetials(login);
                clear();
            }
            else
            {
            }
        }
        catch (Exception)
        { }
    }

    private void clear()
    {
        TxtNewEmailAddress.Text = "";
        TxtOldEmailAddress.Text = "";
        TxtRepeat.Text = "";
    }
}