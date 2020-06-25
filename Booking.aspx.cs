using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PlayMovieskp.LogicalLayers;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using PlayMovieskp;
public partial class ProductAss : System.Web.UI.Page
{
    [WebMethod]
    protected void ALogOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("ProductAss.aspx");
    }
    public static List<string> GetAutoCompleteData(string username)
    {
        List<string> result = new List<string>();
        DataTable Dt;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Vvw_ProductAutoSearch where ProductName LIKE '%'+@SearchText+'%' ", con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@SearchText", username);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                Dt = ds.Tables[0];
                //rcCorporateMenu.DataSource = Dt;
                //rcCorporateMenu.DataBind();


                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr["ProductName"].ToString());
                }

                return result;
            }
        }

    }
    static string Id = "";
    static int CountId = 0;
    DataTable table = GetTable();
    static DataTable GetTable()
    {
        // Here we create a DataTable with four columns.
        DataTable table = new DataTable();
        table.Columns.Add("SrNo", typeof(int));
        table.Columns.Add("Type", typeof(int));

        return table;
    }
    DataTable tableBooking = GetBookingTable();
    static DataTable GetBookingTable()
    {
        // Here we create a DataTable with four columns.
        DataTable table = new DataTable();
        table.Columns.Add("SrNo", typeof(int));
        table.Columns.Add("ProductId", typeof(string));
        table.Columns.Add("ProductName", typeof(string));
        table.Columns.Add("Rate", typeof(string));
        table.Columns.Add("Qty", typeof(string));
        table.Columns.Add("Total", typeof(string));
        return table;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
           
            if (!Page.IsPostBack)
            {
                Id = Convert.ToString(Request.QueryString["Id"]);
                Paltium();
                ViewState["DtBooking"] = tableBooking;

            }
            if (Session["UserId"] == null)
            {
                ALogin.Visible = true;
                Lbl2.Visible = true;
                ASignup.Visible = true;
                lbl4.Visible = false;
                ALogOut.Visible = false;
                lbl3.Visible = false;


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
            try
            {
                Id = Convert.ToString(Request.QueryString["Id"]);
                DataTable CamaignDetail = MoviesLogicLayer.GetAllIDWiseMoviesDetials(Id);
                ImgAss.ImageUrl = "~/Admin\\MovieImage\\" + CamaignDetail.Rows[0]["MoviesImage"].ToString();

                lblHomeHeader.Text = Convert.ToString(CamaignDetail.Rows[0]["MoviesName"]);
                if (Convert.ToString(CamaignDetail.Rows[0]["GoldRate"]) != "0")
                    LinkButtonGold.Visible = true;
                else
                    LinkButtonGold.Visible = false;
                if (Convert.ToString(CamaignDetail.Rows[0]["PaltiumRate"]) != "0")
                    LinkButtonPaltium.Visible = true;
                else
                    LinkButtonPaltium.Visible = false;
                if (Convert.ToString(CamaignDetail.Rows[0]["SilverRate"]) != "0")
                    LinkButtonSilver.Visible = true;
                else
                    LinkButtonSilver.Visible = false;

                DataSet ProductDetails = AccessoriesProductDetailLogicLayer.GetAllIDWiseAccessoriesProductDetailDetials(Id);

            }
            catch (Exception)
            { }
        }
        else
        {
            Response.Redirect("Default.aspx?login=box");
        }
    }

    protected void RptCateen_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        DataTable dtCurrentTable = (DataTable)ViewState["DtBooking"];
        DataTable DtC = CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetials(e.CommandArgument.ToString());
        dtCurrentTable.Rows.Add((dtCurrentTable.Rows.Count + 1).ToString(), DtC.Rows[0]["CateenId"].ToString(), DtC.Rows[0]["ProductName"].ToString(), DtC.Rows[0]["Rate"].ToString(), "1", DtC.Rows[0]["Rate"].ToString());

        ViewState["DtBooking"] = dtCurrentTable;
        rptBookedCatenlist.DataSource = ViewState["DtBooking"];
        rptBookedCatenlist.DataBind();

    }
   
    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int CheckCount =0;
        if (string.IsNullOrWhiteSpace(Request.QueryString["Count"]))
            {
             CheckCount = 100;
         }
         else
         {
             CheckCount = Convert.ToInt32(Request.QueryString["Count"]);
         }

         if (CheckCount > CountId)
         {
             if (e.CommandName == "book")
             {
                 DataTable dtCurrentTable = (DataTable)ViewState["dtTable"];

                 dtCurrentTable.Rows[Convert.ToInt32(e.CommandArgument)]["type"] = "0";
                 ViewState["dtTable"] = dtCurrentTable;
                 rpt.DataSource = ViewState["dtTable"];
                 rpt.DataBind();
                 CountId = CountId + 1;
             }
             else if (e.CommandName == "booked")
             {

             }
             else if (e.CommandName == "Selectbook")
             {
                 DataTable dtCurrentTable = (DataTable)ViewState["dtTable"];
                 dtCurrentTable.Rows[Convert.ToInt32(e.CommandArgument)]["SrNo"] = "1";
                 ViewState["dtTable"] = dtCurrentTable;
                 rpt.DataSource = (DataTable)ViewState["dtTable"];
                 rpt.DataBind();
               
             }
         }
         else
         {
            
         }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bookingLogicLayer BL = new bookingLogicLayer();
        BL.PayamentStatus = "0";
        BL.UserId = Session["UserId"].ToString();
        BL.EntryBy = Session["UserId"].ToString();
        string BID = bookingLogicLayer.InsertbookingDetials(BL);

        DataTable dtCurrentTable = (DataTable)ViewState["dtTable"];
        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
        {
            if (dtCurrentTable.Rows[i]["type"].ToString() == "0")
            {



                dtCurrentTable.Rows[i]["type"] = "2";
                BookingSeatLogicLayer BLS = new BookingSeatLogicLayer();
                if (rdobtnD1.Checked == true)
                    BLS.BookingDate = rdobtnD1.Text;
                else if (rdobtnD2.Checked == true)
                    BLS.BookingDate = rdobtnD2.Text;
                else if (rdobtnD3.Checked == true)
                    BLS.BookingDate = rdobtnD3.Text;

                if (RadioButton1.Checked == true)
                    BLS.BookingTime = "1";
                else if (RadioButton2.Checked == true)
                    BLS.BookingTime = "2";
                else if (RadioButton3.Checked == true)
                    BLS.BookingTime = "3";
                else if (RadioButton4.Checked == true)
                    BLS.BookingTime = "4";

                BLS.BookingId = BID;
                BLS.BookingType = TypeId;
                BLS.SeatNo = (i + 1).ToString();
                BLS.Rate = lblRate.Text.Trim();
                BLS.UserId = Session["UserId"].ToString();
                BLS.MovieId = hfMoviesId.Value;
                BookingSeatLogicLayer.InsertBookingSeatDetials(BLS);
                DataTable Dt = BookingSeatLogicLayer.GetAllIDWiseBookedSeatDetials(BID);
                if (Dt.Rows.Count > 0)
                {
                    string Message = "";
                    Message = "MovieName :" + Dt.Rows[0]["MoviesName"].ToString() + " ScreenName : " + Dt.Rows[0]["ScreenName"].ToString() + " Seat No : " + Dt.Rows[0]["SeatNo"].ToString();
                    MessageCenter.SendMsg(Dt.Rows[0]["MobileNumber"].ToString(), Message);
                }
            }
        }
        ViewState["dtTable"] = dtCurrentTable;
        DataTable DtBooking1 = (DataTable)ViewState["DtBooking"];
        for (int i = 0; i < DtBooking1.Rows.Count; i++)
        {
            BookingCateenLogicLayer BCL = new BookingCateenLogicLayer();
            BCL.BookingId = BID;
            BCL.ProductId = DtBooking1.Rows[i]["ProductId"].ToString();
            BCL.Qty = DtBooking1.Rows[i]["Qty"].ToString();
            BCL.Rate = DtBooking1.Rows[i]["Rate"].ToString();
            BCL.UserId = Session["UserId"].ToString();
            BCL.EntryBy = Session["UserId"].ToString();
            BookingCateenLogicLayer.InsertBookingCateenDetials(BCL);
        }
        rpt.DataSource = ViewState["dtTable"];
        rpt.DataBind();

         int CheckCount =0;
        if (string.IsNullOrWhiteSpace(Request.QueryString["Count"]))
            {
             CheckCount = 100;
         }
         else
         {
             CheckCount = Convert.ToInt32(Request.QueryString["Count"]);
         }
        if (CheckCount != 0 || CheckCount != 100)
        {
            string AAAA = bookingLogicLayer.ReSudulewithBookingId(Convert.ToString(Request.QueryString["OldBookingId"]));
        }
       // Response.Redirect("Recipt.aspx?Id=" + BID);
        Response.Redirect("BookCanteen.aspx?Bookingid=" + BID);
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("Search.aspx?Id=" + TxtSearch.Text);
    }
    protected void GridViewAccessoriesDetailsHeader_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gr = (GridView)(e.Row.FindControl("GridViewAccessoriesDetailsDetails"));
            if (gr != null)
            {
                HiddenField hfFeatureHeaderId = (HiddenField)(e.Row.FindControl("hfFeatureHeaderId"));
                gr.DataSource = AccessoriesProductDetailLogicLayer.GetAllProductIDWiseAccessoriesProductDetailDetials(hfFeatureHeaderId.Value, Id).Tables[0];
                gr.DataBind();
            }
        }

    }
    protected void BtnAddToCart_Click(object sender, EventArgs e)
    {
            }
    protected void LinkButtonPaltium_Click(object sender, EventArgs e)
    {
        Paltium();
    }
    String TypeId = "1";
    private void Booktime()
    {
        if (rdobtnD1.Checked == true)
        {
            int hour = DateTime.Now.Hour;
            if (hour > 12)
            {
                RadioButton1.Enabled = false;
            }
            if (hour > 15)
            {
                RadioButton2.Enabled = false;
            }
            if (hour > 18)
            {
                RadioButton3.Enabled = false;
            }
            if (hour > 21)
            {
                RadioButton4.Enabled = false;
            }
        }
        else
        {
            RadioButton1.Enabled = true;
            RadioButton2.Enabled = true;
            RadioButton3.Enabled = true;
            RadioButton4.Enabled = true;
        }
    }
    private void Paltium()
    {
        Booktime();
        TypeId = "1";
        DataTable CamaignDetail = MoviesLogicLayer.GetAllIDWiseMoviesDetials(Id);
        lblClass.Text = "Paltium";
        hfMoviesId.Value = Convert.ToString(CamaignDetail.Rows[0]["MoviesId"]);
        lblMovieName.Text = Convert.ToString(CamaignDetail.Rows[0]["MoviesName"]);
        lblRate.Text = Convert.ToString(CamaignDetail.Rows[0]["PaltiumRate"]);
        lblScreenName.Text = Convert.ToString(CamaignDetail.Rows[0]["ScreenName"]);
        DataTable DTbook = MoviesLogicLayer.GetAllIDWisebookedSeat(Convert.ToString(CamaignDetail.Rows[0]["MoviesId"]));
        for (int i = 0; i < Convert.ToInt32(CamaignDetail.Rows[0]["PaltiumSeat"]); i++)
        {
            table.Rows.Add(i, 1);
        }
        DateTime RelaseDate = Convert.ToDateTime(CamaignDetail.Rows[0]["RealsieDate"]);
        if (RelaseDate >= DateTime.Now)
        {
            DateTime ExpiryDate = Convert.ToDateTime(CamaignDetail.Rows[0]["ExpiryDate"]);

            rdobtnD1.Text = RelaseDate.ToString("dd-MMM-yyyy");
            if (ExpiryDate >= DateTime.Now.AddDays(1))
            {
                rdobtnD2.Text = RelaseDate.AddDays(1).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD2.Visible = false;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(2))
            {
                rdobtnD3.Text = RelaseDate.AddDays(2).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD3.Visible = false;
            }

        }
        else
        {
            DateTime ExpiryDate = Convert.ToDateTime(CamaignDetail.Rows[0]["ExpiryDate"]);
            if (ExpiryDate >= DateTime.Now)
            {
                rdobtnD1.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD1.Visible = false;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(1))
            {
                rdobtnD2.Text = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD2.Visible = false;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(2))
            {
                rdobtnD3.Text = DateTime.Now.AddDays(2).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD3.Visible = false;
            }
        }
        if (rdobtnD1.Visible == false && rdobtnD2.Visible == false && rdobtnD3.Visible == false)
        {
            rpt.Visible = false;
            btnSubmit.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            RadioButton3.Visible = false;
            RadioButton4.Visible = false;

        }
        else
        {
            rpt.Visible = true;
            btnSubmit.Visible = true;
            RadioButton1.Visible = true;
            RadioButton2.Visible = true;
            RadioButton3.Visible = true;
            RadioButton4.Visible = true;
        }

        string BookingDate = "";
        if (rdobtnD1.Checked == true)
            BookingDate = rdobtnD1.Text;
        else if (rdobtnD2.Checked == true)
            BookingDate = rdobtnD2.Text;
        else if (rdobtnD3.Checked == true)
            BookingDate = rdobtnD3.Text;
        string BookingTime = "";
        if (RadioButton1.Checked == true)
            BookingTime = "1";
        else if (RadioButton2.Checked == true)
            BookingTime = "2";
        else if (RadioButton3.Checked == true)
            BookingTime = "3";
        else if (RadioButton4.Checked == true)
            BookingTime = "4";

        DataTable DtSeat12 = BookingSeatLogicLayer.GetAllIDWiseBookingSeat(hfMoviesId.Value, TypeId, BookingDate, BookingTime);
        for (int i = 0; i < Convert.ToInt32(CamaignDetail.Rows[0]["GoldSeat"]); i++)
        {
            for (int j = 0; j < DtSeat12.Rows.Count; j++)
            {
                if (Convert.ToInt32(DtSeat12.Rows[j]["SeatNo"]) == i + 1)
                    table.Rows[i]["type"] = "2";
            }
        }
        ViewState["dtTable"] = table;
        rpt.DataSource = (DataTable)ViewState["dtTable"];
        rpt.DataBind();
        RptCateen.DataSource = CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetialsT(Convert.ToString(CamaignDetail.Rows[0]["TheatresNameId"]));
        RptCateen.DataBind();
        // rptBookedCatenlist.DataSource = CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetialsT(Convert.ToString(CamaignDetail.Rows[0]["TheatresNameId"]));
        // rptBookedCatenlist.DataBind();

    }
    protected void LinkButtonGold_Click(object sender, EventArgs e)
    {
        TypeId = "2";

        Gold();
    }
    string ShowTime;
    private void Plan(string ShowTime1)
    {
        Booktime();
        ShowTime = ShowTime1;
        if (TypeId == "1")
        {
            Paltium();
        }
        else if (TypeId == "2")
        {
            Gold();
        }
        else if (TypeId == "3")
        {
            Sliver();
        }
    }
    private void Gold()
    {
        Booktime();
        DataTable CamaignDetail = MoviesLogicLayer.GetAllIDWiseMoviesDetials(Id);
        lblClass.Text = "Gold";
        hfMoviesId.Value = Convert.ToString(CamaignDetail.Rows[0]["MoviesId"]);
        lblMovieName.Text = Convert.ToString(CamaignDetail.Rows[0]["MoviesName"]);
        lblRate.Text = Convert.ToString(CamaignDetail.Rows[0]["GoldRate"]);
        lblScreenName.Text = Convert.ToString(CamaignDetail.Rows[0]["ScreenName"]);
        for (int i = 0; i < Convert.ToInt32(CamaignDetail.Rows[0]["GoldSeat"]); i++)
        {
            table.Rows.Add(i, 1);
        }
        DateTime RelaseDate = Convert.ToDateTime(CamaignDetail.Rows[0]["RealsieDate"]);
        if (RelaseDate >= DateTime.Now)
        {
            DateTime ExpiryDate = Convert.ToDateTime(CamaignDetail.Rows[0]["ExpiryDate"]);

            rdobtnD1.Text = RelaseDate.ToString("dd-MMM-yyyy");
            if (ExpiryDate >= DateTime.Now.AddDays(1))
            {
                rdobtnD2.Text = RelaseDate.AddDays(1).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD2.Visible = true;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(2))
            {
                rdobtnD3.Text = RelaseDate.AddDays(2).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD3.Visible = true;
            }

        }
        else
        {
            DateTime ExpiryDate = Convert.ToDateTime(CamaignDetail.Rows[0]["ExpiryDate"]);
            if (ExpiryDate >= DateTime.Now)
            {
                rdobtnD1.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD1.Visible = false;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(1))
            {
                rdobtnD2.Text = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD2.Visible = false;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(2))
            {
                rdobtnD3.Text = DateTime.Now.AddDays(2).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD3.Visible = false;
            }
        }
        if (rdobtnD1.Visible == false && rdobtnD2.Visible == false && rdobtnD3.Visible == false)
        {
            rpt.Visible = false;
            btnSubmit.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            RadioButton3.Visible = false;
            RadioButton4.Visible = false;

        }
        else
        {
            rpt.Visible = true;
            btnSubmit.Visible = true;
            RadioButton1.Visible = true;
            RadioButton2.Visible = true;
            RadioButton3.Visible = true;
            RadioButton4.Visible = true;
        }
       
        string BookingDate ="";
         if (rdobtnD1.Checked == true)
                    BookingDate = rdobtnD1.Text;
                else if (rdobtnD2.Checked == true)
                   BookingDate = rdobtnD2.Text;
                else if (rdobtnD3.Checked == true)
                    BookingDate = rdobtnD3.Text;
           string BookingTime ="";
                if (RadioButton1.Checked == true)
                    BookingTime ="1";
                else if (RadioButton2.Checked == true)
                   BookingTime = "2";
                else if (RadioButton3.Checked == true)
                    BookingTime = "3";
                else if (RadioButton4.Checked == true)
                    BookingTime = "4";
             
        DataTable DtSeat12 = BookingSeatLogicLayer.GetAllIDWiseBookingSeat(hfMoviesId.Value, TypeId, BookingDate, BookingTime);
        for (int i = 0; i < Convert.ToInt32(CamaignDetail.Rows[0]["GoldSeat"]); i++)
        {
            for (int j = 0; j < DtSeat12.Rows.Count; j++)
            {
                if (Convert.ToInt32(DtSeat12.Rows[j]["SeatNo"]) == i+1)
                    table.Rows[i]["type"] = "2"; 
            }
        }
        ViewState["dtTable"] = table;
        rpt.DataSource = (DataTable)ViewState["dtTable"];
        rpt.DataBind();


        RptCateen.DataSource = CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetialsT(Convert.ToString(CamaignDetail.Rows[0]["TheatresNameId"]));
        RptCateen.DataBind();
    }
   
    protected void LinkButtonSilver_Click(object sender, EventArgs e)
    {
        TypeId = "3";
        Sliver();
    }

    private void Sliver()
    {
        Booktime();
        DataTable CamaignDetail = MoviesLogicLayer.GetAllIDWiseMoviesDetials(Id);
        lblClass.Text = "Silver";
        hfMoviesId.Value = Convert.ToString(CamaignDetail.Rows[0]["MoviesId"]);
        lblMovieName.Text = Convert.ToString(CamaignDetail.Rows[0]["MoviesName"]);
        lblRate.Text = Convert.ToString(CamaignDetail.Rows[0]["SilverRate"]);
        lblScreenName.Text = Convert.ToString(CamaignDetail.Rows[0]["ScreenName"]);
        for (int i = 0; i < Convert.ToInt32(CamaignDetail.Rows[0]["SilverSeat"]); i++)
        {
            table.Rows.Add(i, 1);
        }
        DateTime RelaseDate = Convert.ToDateTime(CamaignDetail.Rows[0]["RealsieDate"]);
        if (RelaseDate >= DateTime.Now)
        {
            DateTime ExpiryDate = Convert.ToDateTime(CamaignDetail.Rows[0]["ExpiryDate"]);

            rdobtnD1.Text = RelaseDate.ToString("dd-MMM-yyyy");
            if (ExpiryDate >= DateTime.Now.AddDays(1))
            {
                rdobtnD2.Text = RelaseDate.AddDays(1).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD2.Visible = true;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(2))
            {
                rdobtnD3.Text = RelaseDate.AddDays(2).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD3.Visible = true;
            }

        }
        else
        {
            DateTime ExpiryDate = Convert.ToDateTime(CamaignDetail.Rows[0]["ExpiryDate"]);
            if (ExpiryDate >= DateTime.Now)
            {
                rdobtnD1.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD1.Visible = false;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(1))
            {
                rdobtnD2.Text = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD2.Visible = false;
            }
            if (ExpiryDate >= DateTime.Now.AddDays(2))
            {
                rdobtnD3.Text = DateTime.Now.AddDays(2).ToString("dd-MMM-yyyy");
            }
            else
            {
                rdobtnD3.Visible = false;
            }
        }
        if (rdobtnD1.Visible == false && rdobtnD2.Visible == false && rdobtnD3.Visible == false)
        {
            rpt.Visible = false;
            btnSubmit.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            RadioButton3.Visible = false;
            RadioButton4.Visible = false;

        }
        else
        {
            rpt.Visible = true;
            btnSubmit.Visible = true;
            RadioButton1.Visible = true;
            RadioButton2.Visible = true;
            RadioButton3.Visible = true;
            RadioButton4.Visible = true;
        }
        string BookingDate = "";
        if (rdobtnD1.Checked == true)
            BookingDate = rdobtnD1.Text;
        else if (rdobtnD2.Checked == true)
            BookingDate = rdobtnD2.Text;
        else if (rdobtnD3.Checked == true)
            BookingDate = rdobtnD3.Text;
        string BookingTime = "";
        if (RadioButton1.Checked == true)
            BookingTime = "1";
        else if (RadioButton2.Checked == true)
            BookingTime = "2";
        else if (RadioButton3.Checked == true)
            BookingTime = "3";
        else if (RadioButton4.Checked == true)
            BookingTime = "4";

        DataTable DtSeat12 = BookingSeatLogicLayer.GetAllIDWiseBookingSeat(hfMoviesId.Value, TypeId, BookingDate, BookingTime);
        for (int i = 0; i < Convert.ToInt32(CamaignDetail.Rows[0]["GoldSeat"]); i++)
        {
            for (int j = 0; j < DtSeat12.Rows.Count; j++)
            {
                if (Convert.ToInt32(DtSeat12.Rows[j]["SeatNo"]) == i + 1)
                    table.Rows[i]["type"] = "2";
            }
        }
        ViewState["dtTable"] = table;
        rpt.DataSource = (DataTable)ViewState["dtTable"];
        rpt.DataBind();
        RptCateen.DataSource = CateenMasterLogicLayer.GetAllIDWiseCateenMasterDetialsT(Convert.ToString(CamaignDetail.Rows[0]["TheatresNameId"]));
        RptCateen.DataBind();
    }
   
    protected void rdobtnD1_CheckedChanged(object sender, EventArgs e)
    {
        Plan("0");
        CountId = 0;
    }
    protected void rdobtnD2_CheckedChanged(object sender, EventArgs e)
    {
        Plan("0");
        CountId = 0;
    }
    protected void rdobtnD3_CheckedChanged(object sender, EventArgs e)
    {
        Plan("0");
        CountId = 0;
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        Plan("1");
        CountId = 0;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Plan("2");
        CountId = 0;
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        Plan("3");
        CountId = 0;
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        Plan("4");
        CountId = 0;
    }
}