using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;

public partial class slider_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            GridFill();
        }
    }
    private void GridFill()
    {
        DataTable dt = BannerLogicLayer.GetAllBannerDetialsIsAcitveonly();
        rcMobileImage.DataSource = dt;
        rcMobileImage.DataBind();
    }
}