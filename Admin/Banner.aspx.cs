
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayMovieskp.LogicalLayers;
using System.Data;
using System.Drawing;

public partial class Admin_Banner : System.Web.UI.Page
{
    static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                GridFill();
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }
    private void GridFill()
    {
        dt = BannerLogicLayer.GetAllBannerDetials();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfBannerIdD = (HiddenField)row.FindControl("hfBannerId");
        string s = hfBannerIdD.Value;
        LblMessage.Text = BannerLogicLayer.DeleteIDWiseBannerDetials(s);
        GridFill();
        Clear();

    }
    private void Clear()
    {
        txtBannerName.Text = "";
        ChkActive.Checked = false;
        BtnSave.Text = "SAVE";
        img1.Src = null;

    }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        HiddenField hfBannerIdD = (HiddenField)row.FindControl("hfBannerId");

        string s = hfBannerIdD.Value;
        try
        {
            DataTable CamaignDetail = BannerLogicLayer.GetAllIDWiseBannerDetials(s);
            hfMobileBrandId1.Value = s;
            txtBannerName.Text = CamaignDetail.Rows[0]["BannerName"].ToString();
            ChkActive.Checked = Convert.ToBoolean(CamaignDetail.Rows[0]["IsAcitve"].ToString());
            hfImadeName.Value = CamaignDetail.Rows[0]["Image"].ToString();

            string Str1 = Convert.ToString(CamaignDetail.Rows[0]["ImageName"]);
            int index = Str1.IndexOf('.');
            string pennies = Str1.Substring(index, Str1.Length - index);
            TempImageLogicLayer Temp = new TempImageLogicLayer();
            Temp.image = pennies;
            string Str = TempImageLogicLayer.InsertTempImageDetials(Temp);

            ViewState["ViewStateImage"] = Str;
            string path1 = Server.MapPath("~/" + "Admin\\banner\\" + Convert.ToString(CamaignDetail.Rows[0]["ImageName"]));
            string path = Server.MapPath("~/" + "Admin\\TempImage\\" + Str);
            SaveImage(MapPathReverse(path1), MapPathReverse(path));
            // System.IO.File.Delete(path1);
            System.Drawing.Image img2 = System.Drawing.Image.FromFile(MapPath("~/Admin//TempImage//") + Str);
            img1.Src = "~/Admin//TempImage//" + Str;

            BtnSave.Text = "UPDATE";
            //btn_save.Text = "UPDATE";

        }
        catch (Exception)
        {


        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortingDirection = string.Empty;
        if (dir == SortDirection.Ascending)
        {
            dir = SortDirection.Descending;
            sortingDirection = "Desc";
        }
        else
        {
            dir = SortDirection.Ascending;
            sortingDirection = "Asc";
        }

        DataView sortedView = new DataView(dt);
        sortedView.Sort = e.SortExpression + " " + sortingDirection;
        GridView1.DataSource = sortedView;
        GridView1.DataBind();
    }
    public SortDirection dir
    {
        get
        {
            if (ViewState["dirState"] == null)
            {
                ViewState["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["dirState"];
        }
        set
        {
            ViewState["dirState"] = value;
        }
    }
    protected void btnPhotoPreview_Click(object sender, EventArgs e)
    {
        if (FUBanner.HasFile)
        {
            TempImageLogicLayer Temp = new TempImageLogicLayer();
            Temp.image = System.IO.Path.GetExtension(FUBanner.FileName).ToLower();
            string Str = TempImageLogicLayer.InsertTempImageDetials(Temp);
            ViewState["ViewStateImage"] = Str;
            FUBanner.SaveAs(MapPath("~/Admin//TempImage//" + Str));
            System.Drawing.Image objImage = System.Drawing.Image.FromFile(Server.MapPath("~/Admin//TempImage//" + Str));
            int width = objImage.Width;
            int height = objImage.Height;
            if (width != 950 && height != 432)
            {
                ViewState["ViewStateImage"] = null;
                img1.Src = null;
                //System.IO.File.Delete((MapPath("~/" + "Admin\\TempImage\\" + Str)));
                Response.Write("<script>alert('Image Size Is Not Valid, Allow image size 950 X 432');</script>");

            }
            else
            {
                System.Drawing.Image img2 = System.Drawing.Image.FromFile(MapPath("~/Admin//TempImage//") + Str);
                img1.Src = "~/Admin//TempImage//" + Str;
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (img1.Src != "")
        {
            if (BtnSave.Text == "SAVE")
            {
                BannerLogicLayer Banner = new BannerLogicLayer();
                Banner.BannerName = txtBannerName.Text.Trim();
                if (ChkActive.Checked == true)
                {
                    Banner.IsAcitve = "True";
                }
                else
                {
                    Banner.IsAcitve = "False";
                }

                string Str1 = Convert.ToString(ViewState["ViewStateImage"]);
                int index = Str1.IndexOf('.');
                string pennies = Str1.Substring(index, Str1.Length - index);
                Banner.Image = pennies;
                if (Convert.ToInt32(BannerLogicLayer.GetCount()) < 10)
                {
                    string Ans = BannerLogicLayer.InsertBannerDetials(Banner);
                    if (Ans.Length < 4)
                    {
                        #region image
                        hfMobileBrandId1.Value = Ans;
                        // FUBanner.SaveAs(Server.MapPath("~/Admin\\banner\\" + Ans + System.IO.Path.GetExtension(FUBanner.FileName).ToLower()));
                        string path1 = Server.MapPath("~/" + "Admin\\TempImage\\" + ViewState["ViewStateImage"].ToString());
                        string path = Server.MapPath("~/" + "Admin\\banner\\" + Ans + pennies);
                        SaveImage(MapPathReverse(path1), MapPathReverse(path));
                        #endregion
                        LblMessage.Text = "Banner successfully Saved...";
                    }
                    GridFill();
                    Clear();
                }
                else
                {
                    LblMessage.Text = "Already Active 10 banner in your record...";
                }
            }
            else
            {
                BannerLogicLayer Banner = new BannerLogicLayer();
                Banner.BannerId = hfMobileBrandId1.Value;
                Banner.BannerName = txtBannerName.Text.Trim();
                if (ChkActive.Checked == true)
                {
                    Banner.IsAcitve = "True";
                }
                else
                {
                    Banner.IsAcitve = "False";
                }
                //if (System.IO.Path.GetExtension(FUBanner.FileName).ToLower() == "")
                //{
                //    Banner.Image = hfImadeName.Value;
                //}
                //else
                //{
                //    Banner.Image = System.IO.Path.GetExtension(FUBanner.FileName).ToLower();
                //}
                string Str1 = Convert.ToString(ViewState["ViewStateImage"]);
                int index = Str1.IndexOf('.');
                string pennies = Str1.Substring(index, Str1.Length - index);
                Banner.Image = pennies;
                if (Convert.ToInt32(BannerLogicLayer.GetCount()) < 10)
                {
                    string Ans = BannerLogicLayer.updateBannerDetials(Banner);
                    if (Ans.Length < 4)
                    {
                        #region image
                        hfMobileBrandId1.Value = Ans;
                        //if (System.IO.Path.GetExtension(FUBanner.FileName).ToLower() == "")
                        //{
                        //}
                        //else
                        //{
                        //    FUBanner.SaveAs(Server.MapPath("~/Admin\\banner\\" + Ans + System.IO.Path.GetExtension(FUBanner.FileName).ToLower()));
                        //}
                        string path1 = Server.MapPath("~/" + "Admin\\TempImage\\" + ViewState["ViewStateImage"].ToString());
                        string path = Server.MapPath("~/" + "Admin\\banner\\" + Ans + pennies);
                        SaveImage(MapPathReverse(path1), MapPathReverse(path));
                        #endregion
                        LblMessage.Text = "Banner successfully Update...";
                    }
                    GridFill();
                    Clear();
                }
                else
                {
                    LblMessage.Text = "Already Active 10 banner in your record...";
                }
            }
        }
        else
        {
            LblMessage.Text = "Upload Image Than Save/Update Record(950 X 432)...";
        }
    }
    public void SaveImage(string sourcefile, string destinationfile)
    {
        System.Drawing.Image image =
    System.Drawing.Image.FromFile(Server.MapPath(sourcefile));
        int srcWidth = image.Width;
        int srcHeight = image.Height;
        int thumbWidth = srcWidth;
        int thumbHeight = srcHeight;
        Bitmap bmp;

        bmp = new Bitmap(thumbWidth, thumbHeight);

        System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        System.Drawing.Rectangle rectDestination =
               new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
        gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
        bmp.Save(Server.MapPath(destinationfile));
        bmp.Dispose();
        image.Dispose();

    }

    public static string MapPathReverse(string fullServerPath)
    {
        return @"~\" + fullServerPath.Replace(HttpContext.Current.Request.PhysicalApplicationPath, String.Empty);
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
}