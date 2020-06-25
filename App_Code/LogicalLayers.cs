using System.Data;
using PlayMovieskp.DataLayer;
using System;
/// <summary>
/// Summary description for LogicalLayers
/// </summary>
/// 
namespace PlayMovieskp.LogicalLayers
{
    public class LogicalLayers
    {
        public LogicalLayers()
        {
            //
            // TODO: Add constructor logic here
            //
        }

    }
    public class Test
    {

        static string _AssCompanyProductNameId, _Title, _CompanyProductName, _EntryBy, _EntryDate, _UpdateBy;
        static DataTable _UpdateDate;
        DataTable _UpdateDate1;

        
        public string Title { get { return _Title; } set { _Title = value; } }
        public string AssCompanyProductNameId { get { return _AssCompanyProductNameId; } set { _AssCompanyProductNameId = value; } }
        public string CompanyProductName { get { return _CompanyProductName; } set { _CompanyProductName = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public static string UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public static DataTable UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public DataTable UpdateDate1 { get { return _UpdateDate1; } set { _UpdateDate1 = value; } }

    }

    public class TheatresLogicLayer
    {

        string _TheatresNameId, _TheatresName, _Address, _CityId, _EntryBy, _EntryDate, _UpdateBy, _UpdateDate, _LocDetail;
        public TheatresLogicLayer()
        {
            _TheatresNameId = "  ";
            _TheatresName = "  ";
            _Address = "  ";
            _CityId = "  ";
            _UpdateBy = "  ";
            _UpdateDate = "  ";
            _EntryBy = "";
            _EntryDate = "";
            _LocDetail = "";


        }
        public string TheatresNameId { get { return _TheatresNameId; } set { _TheatresNameId = value; } }
        public string TheatresName { get { return _TheatresName; } set { _TheatresName = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string CityId { get { return _CityId; } set { _CityId = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public string UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public string LocDetail { get { return _LocDetail; } set { _LocDetail = value; } }


        public static string InsertTheatresDetials(TheatresLogicLayer TheatresDetail)
        {
            return TheatresDataLayer.InsertTheatresDetials(TheatresDetail);
        }

        public static string updateTheatresDetials(TheatresLogicLayer TheatresDetail)
        {
            return TheatresDataLayer.UpdateTheatresDetials(TheatresDetail);
        }

        public static DataTable GetAllTheatresDetials()
        {
            return TheatresDataLayer.GetAllTheatresDetials();
        }
        public static DataTable GetAllTheatresSelect()
        {
            return TheatresDataLayer.GetAllTheatresSelect();
        }
        public static DataTable GetAllTheatresSelectId(string Id)
        {
            return TheatresDataLayer.GetAllTheatresSelectId( Id);
        }
        public static DataTable GetAllIDWiseTheatresDetials(string Id)
        {
            return TheatresDataLayer.GetAllIDWiseTheatresDetials(Id);
        }
        public static string DeleteTheatresDetials(string Id)
        {
            return TheatresDataLayer.DeleteTheatresDetials(Id);
        }





    }

    public class ScreenLogicLayer
    {

        string
            _ScreenId,
_ScreenName,
_TheatresId,
_PaltiumSeat,
_PaltiumRate,
_GoldSeat,
_GoldRate,
_SilverSeat,
_SilverRate,
_Entryby,
_Entrydate,
_UpdateDate,
_Updateby;

        public ScreenLogicLayer()
        {
            _ScreenId = "";
            _ScreenName = "";
            _TheatresId = "";
            _PaltiumSeat = "";
            _PaltiumRate = "";
            _GoldSeat = "";
            _GoldRate = "";
            _SilverSeat = "";
            _SilverRate = "";
            _Entryby = "";
            _Entrydate = "";
            _UpdateDate = "";
            _Updateby = "";


        }
        public string ScreenId { get { return _ScreenId; } set { _ScreenId = value; } }
        public string ScreenName { get { return _ScreenName; } set { _ScreenName = value; } }
        public string TheatresId { get { return _TheatresId; } set { _TheatresId = value; } }
        public string PaltiumSeat { get { return _PaltiumSeat; } set { _PaltiumSeat = value; } }
        public string PaltiumRate { get { return _PaltiumRate; } set { _PaltiumRate = value; } }
        public string GoldSeat { get { return _GoldSeat; } set { _GoldSeat = value; } }
        public string GoldRate { get { return _GoldRate; } set { _GoldRate = value; } }
        public string SilverSeat { get { return _SilverSeat; } set { _SilverSeat = value; } }
        public string SilverRate { get { return _SilverRate; } set { _SilverRate = value; } }
        public string Entryby { get { return _Entryby; } set { _Entryby = value; } }
        public string Entrydate { get { return _Entrydate; } set { _Entrydate = value; } }
        public string UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public string Updateby { get { return _Updateby; } set { _Updateby = value; } }


        public static string InsertScreenDetials(ScreenLogicLayer ScreenDetail)
        {
            return ScreenDataLayer.InsertScreenDetials(ScreenDetail);
        }

        public static string updateScreenDetials(ScreenLogicLayer ScreenDetail)
        {
            return ScreenDataLayer.UpdateScreenDetials(ScreenDetail);
        }

        public static DataTable GetAllScreenDetials()
        {
            return ScreenDataLayer.GetAllScreenDetials();
        }
        public static DataTable GetAllScreenSelect()
        {
            return ScreenDataLayer.GetAllScreenSelect();
        }
        public static DataTable GetAllScreenSelecttherters(string TID)
        {
            return ScreenDataLayer.GetAllScreenSelecttherters(TID);
        }
        public static DataTable GetAllIDWiseScreenDetials(string Id)
        {
            return ScreenDataLayer.GetAllIDWiseScreenDetials(Id);
        }
        public static string DeleteScreenDetials(string Id)
        {
            return ScreenDataLayer.DeleteScreenDetials(Id);
        }





    }

    public class CateenMasterLogicLayer
    {

        string _CateenId, _TheatreId, _ProductName, _ProductImage, _Rate, _ProductDesc, _EntryBy, _EntryDate, _Updateby, _UpdateDate;

        public CateenMasterLogicLayer()
        {
            _CateenId = "  ";
            _TheatreId = "  ";
            _ProductName = "  ";
            _ProductImage = "  ";
            _Rate = "  ";
            _ProductDesc = "  ";
            _EntryBy = "  ";
            _EntryDate = "  ";
            _Updateby = "  ";
            _UpdateDate = "  ";


        }
        public string CateenId { get { return _CateenId; } set { _CateenId = value; } }
        public string TheatreId { get { return _TheatreId; } set { _TheatreId = value; } }
        public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
        public string ProductImage { get { return _ProductImage; } set { _ProductImage = value; } }
        public string Rate { get { return _Rate; } set { _Rate = value; } }
        public string ProductDesc { get { return _ProductDesc; } set { _ProductDesc = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string Updateby { get { return _Updateby; } set { _Updateby = value; } }
        public string UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }


        public static string InsertCateenMasterDetials(CateenMasterLogicLayer CateenMasterDetail)
        {
            return CateenMasterDataLayer.InsertCateenMasterDetials(CateenMasterDetail);
        }

        public static string updateCateenMasterDetials(CateenMasterLogicLayer CateenMasterDetail)
        {
            return CateenMasterDataLayer.UpdateCateenMasterDetials(CateenMasterDetail);
        }

        public static DataTable GetAllCateenMasterDetials()
        {
            return CateenMasterDataLayer.GetAllCateenMasterDetials();
        }
        public static DataTable GetAllCateenMasterDetialsTID(string Id)
        {
            return CateenMasterDataLayer.GetAllCateenMasterDetialsTID(Id);
        }
        public static DataTable GetAllCateenMasterSelect()
        {
            return CateenMasterDataLayer.GetAllCateenMasterSelect();
        }
        public static DataTable GetAllIDWiseCateenMasterDetials(string Id)
        {
            return CateenMasterDataLayer.GetAllIDWiseCateenMasterDetials(Id);
        }
        public static DataTable GetAllIDWiseCateenMasterDetialsT(string Id)
        {
            return CateenMasterDataLayer.GetAllIDWiseCateenMasterDetialsT(Id);
        }
        public static DataTable GetAllIDWiseCateenMasterDetialsFoodName(string Id)
        {
            return CateenMasterDataLayer.GetAllIDWiseCateenMasterDetialsFoodName(Id);
        }
        public static DataTable GetAllIDWiseCateenMasterDetialsFoodNameQtyRate(string Id)
        {
            return CateenMasterDataLayer.GetAllIDWiseCateenMasterDetialsFoodNameQtyRate(Id);
        }
        public static string DeleteCateenMasterDetials(string Id)
        {
            return CateenMasterDataLayer.DeleteCateenMasterDetials(Id);
        }
        public static DataTable GetAllIDWiseCateenMasterFillGrid(string Id)
        {
            return CateenMasterDataLayer.GetAllIDWiseCateenMasterFillGrid(Id);
        }



    }

    public class MoviesLogicLayer
    {

        string _MoviesTrailer, _MoviesId, _MoviesName, _ScreenId, _MoviesDesc, _RealsieDate, _Startbooking, _ExpiryDate, _Stopbooking, _Entryby, _EntryDate, _UpdateDate, _Updateby;

        public MoviesLogicLayer()
        {
            _MoviesTrailer = " ";
            _MoviesId = "  ";
            _MoviesName = "  ";
            _ScreenId = "  ";
            _MoviesDesc = "  ";
            _RealsieDate = "  ";
            _Startbooking = "  ";
            _ExpiryDate = "  ";
            _Stopbooking = "  ";
            _Entryby = "  ";
            _EntryDate = "  ";
            _UpdateDate = "  ";
            _Updateby = "  ";


        }
        public string MoviesTrailer { get { return _MoviesTrailer; } set { _MoviesTrailer = value; } }
        public string MoviesId { get { return _MoviesId; } set { _MoviesId = value; } }
        public string MoviesName { get { return _MoviesName; } set { _MoviesName = value; } }
        public string ScreenId { get { return _ScreenId; } set { _ScreenId = value; } }
        public string MoviesDesc { get { return _MoviesDesc; } set { _MoviesDesc = value; } }
        public string RealsieDate { get { return _RealsieDate; } set { _RealsieDate = value; } }
        public string Startbooking { get { return _Startbooking; } set { _Startbooking = value; } }
        public string ExpiryDate { get { return _ExpiryDate; } set { _ExpiryDate = value; } }
        public string Stopbooking { get { return _Stopbooking; } set { _Stopbooking = value; } }
        public string Entryby { get { return _Entryby; } set { _Entryby = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }
        public string Updateby { get { return _Updateby; } set { _Updateby = value; } }


        public static string InsertMoviesDetials(MoviesLogicLayer MoviesDetail)
        {
            return MoviesDataLayer.InsertMoviesDetials(MoviesDetail);
        }

        public static string updateMoviesDetials(MoviesLogicLayer MoviesDetail)
        {
            return MoviesDataLayer.UpdateMoviesDetials(MoviesDetail);
        }

        public static DataTable GetAllMoviesDetials()
        {
            return MoviesDataLayer.GetAllMoviesDetials();
        }
        public static DataTable GetAllMoviesDetialsWithThertresId(string TId)
        {
            return MoviesDataLayer.GetAllMoviesDetialsWithThertresId(TId);
        }
        public static DataTable GetAllMoviesDetialsWithCity(string City)
        {
            return MoviesDataLayer.GetAllMoviesDetialsWithCity(City);
        }
        public static DataTable GetAllMoviesDetialsWithTheatres(string Theatres)
        {
            return MoviesDataLayer.GetAllMoviesDetialsWithTheatres(Theatres);
        }
        public static DataTable GetAllMoviesDetialsWithTheatresupcoming(string Theatres)
        {
            return MoviesDataLayer.GetAllMoviesDetialsWithTheatresupcoming(Theatres);
        }
        public static DataTable GetAllMoviesSelect()
        {
            return MoviesDataLayer.GetAllMoviesSelect();
        }
        public static DataTable GetAllIDWiseMoviesDetials(string Id)
        {
            return MoviesDataLayer.GetAllIDWiseMoviesDetials(Id);
        }
        public static DataTable GetAllIDWisebookedSeat(string Id)
        {
            return MoviesDataLayer.GetAllIDWisebookedSeat(Id);
        }
        public static string DeleteMoviesDetials(string Id)
        {
            return MoviesDataLayer.DeleteMoviesDetials(Id);
        }
    }

    public class bookingLogicLayer
    {

        string _BookingId, _PayamentStatus, _EntryDate, _EntryBy, _UserId;

        public bookingLogicLayer()
        {
            _BookingId = "  ";
            _PayamentStatus = "  ";
            _EntryDate = "  ";
            _EntryBy = "  ";
            _UserId = "  ";


        }
        public string BookingId { get { return _BookingId; } set { _BookingId = value; } }
        public string PayamentStatus { get { return _PayamentStatus; } set { _PayamentStatus = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }


        public static string InsertbookingDetials(bookingLogicLayer bookingDetail)
        {
            return bookingDataLayer.InsertbookingDetials(bookingDetail);
        }

        public static string updatebookingDetials(bookingLogicLayer bookingDetail)
        {
            return bookingDataLayer.UpdatebookingDetials(bookingDetail);
        }

        public static DataTable GetAllbookingDetials()
        {
            return bookingDataLayer.GetAllbookingDetials();
        }

        public static DataTable GetAllIDWisebookingDetials(String Id)
        {
            return bookingDataLayer.GetAllIDWisebookingDetials(Id);
        }

        public static DataTable GetAllIDWisebookingDetialswithUserId(String UserId)
        {
            return bookingDataLayer.GetAllIDWisebookingDetialswithUserId(UserId);
        }
        public static DataTable GetAllIDWisebookingDetialsseatwithUserId(String UserId)
        {
            return bookingDataLayer.GetAllIDWisebookingDetialsseatwithUserId(UserId);
        }
        public static string CancelwithBookingseatId(String UserId)
        {
            return bookingDataLayer.CancelwithBookingseatId(UserId);
        }
        public static string CancelwithBookingId(String UserId)
        {
            return bookingDataLayer.CancelwithBookingId(UserId);
        }
        public static string ReSudulewithBookingId(String UserId)
        {
            return bookingDataLayer.ReSudulewithBookingId(UserId);
        }

    }

    public class BookingCateenLogicLayer
    {

        string _BookingCateend, _BookingId, _ProductId, _Qty, _Rate, _EntryBy, _EntryDate, _UserId, _Type;

        public BookingCateenLogicLayer()
        {
            _BookingCateend = "  ";
            _BookingId = "  ";
            _ProductId = "  ";
            _Qty = "  ";
            _Rate = "  ";
            _EntryBy = "  ";
            _EntryDate = "  ";
            _UserId = "  ";
            _Type = "  ";

        }
        public string BookingCateend { get { return _BookingCateend; } set { _BookingCateend = value; } }
        public string BookingId { get { return _BookingId; } set { _BookingId = value; } }
        public string ProductId { get { return _ProductId; } set { _ProductId = value; } }
        public string Qty { get { return _Qty; } set { _Qty = value; } }
        public string Rate { get { return _Rate; } set { _Rate = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public string Type { get { return _Type = "  "; ; } set { _Type = value; } }


        public static string InsertBookingCateenDetials(BookingCateenLogicLayer BookingCateenDetail)
        {
            return BookingCateenDataLayer.InsertBookingCateenDetials(BookingCateenDetail);
        }

        public static string updateBookingCateenDetials(BookingCateenLogicLayer BookingCateenDetail)
        {
            return BookingCateenDataLayer.UpdateBookingCateenDetials(BookingCateenDetail);
        }

        public static DataTable GetAllBookingCateenDetials()
        {
            return BookingCateenDataLayer.GetAllBookingCateenDetials();
        }

        public static DataTable GetAllIDWiseBookingCateenDetials(String Id)
        {
            return BookingCateenDataLayer.GetAllIDWiseBookingCateenDetials(Id);
        }

        public static string DeleteIDWiseBookingCateenDetials(String Id)
        {
            return BookingCateenDataLayer.DeleteIDWiseBookingCateenDetials(Id);
        }

    }

    public class BookingSeatLogicLayer
    {

        string _BookingDate, _BookingTime, _BookingSeetId, _BookingId, _MovieId, _BookingType, _SeatNo, _Rate, _EntryBy, _EntryDate, _UserId;

        public BookingSeatLogicLayer()
        {
            _BookingSeetId = "  ";
            _BookingId = "  ";
            _MovieId = "  ";
            _BookingType = "  ";
            _SeatNo = "  ";
            _Rate = "  ";
            _EntryBy = "  ";
            _EntryDate = "  ";
            _UserId = "  ";
            _BookingDate = " ";
            _BookingTime = " ";


        }
        public string BookingDate { get { return _BookingDate; } set { _BookingDate = value; } }
        public string BookingTime { get { return _BookingTime; } set { _BookingTime = value; } }
        public string BookingSeetId { get { return _BookingSeetId; } set { _BookingSeetId = value; } }
        public string BookingId { get { return _BookingId; } set { _BookingId = value; } }
        public string MovieId { get { return _MovieId; } set { _MovieId = value; } }
        public string BookingType { get { return _BookingType; } set { _BookingType = value; } }
        public string SeatNo { get { return _SeatNo; } set { _SeatNo = value; } }
        public string Rate { get { return _Rate; } set { _Rate = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }


        public static string InsertBookingSeatDetials(BookingSeatLogicLayer BookingSeatDetail)
        {
            return BookingSeatDataLayer.InsertBookingSeatDetials(BookingSeatDetail);
        }

        public static string updateBookingSeatDetials(BookingSeatLogicLayer BookingSeatDetail)
        {
            return BookingSeatDataLayer.UpdateBookingSeatDetials(BookingSeatDetail);
        }

        public static DataTable GetAllBookingSeatDetials()
        {
            return BookingSeatDataLayer.GetAllBookingSeatDetials();
        }

        public static DataTable GetAllIDWiseBookingSeatDetials(String Id)
        {
            return BookingSeatDataLayer.GetAllIDWiseBookingSeatDetials(Id);
        }
        public static DataTable GetAllIDWiseBookedSeatDetials(String Id)
        {
            return BookingSeatDataLayer.GetAllIDWiseBookedSeatDetials(Id);
        }
        public static DataTable GetAllIDWiseBookedCateenDetials(String Id)
        {
            return BookingSeatDataLayer.GetAllIDWiseBookedCateenDetials(Id);
        }
        public static DataTable GetAllIDWiseBookingSeat(String MovieId, String bookingType, String BookingDate, String BookingTime)
        {
            return BookingSeatDataLayer.GetAllIDWiseBookingSeat(MovieId, bookingType, BookingDate, BookingTime);
        }


    }

    public class TempImageLogicLayer
    {

        string _Id, _image;

        public TempImageLogicLayer()
        {
            _Id = "  ";
            _image = "  ";


        }
        public string Id { get { return _Id; } set { _Id = value; } }
        public string image { get { return _image; } set { _image = value; } }


        public static string InsertTempImageDetials(TempImageLogicLayer TempImageDetail)
        {
            return TempImageDataLayer.InsertTempImageDetials(TempImageDetail);
        }

        public static string updateTempImageDetials(TempImageLogicLayer TempImageDetail)
        {
            return TempImageDataLayer.UpdateTempImageDetials(TempImageDetail);
        }

        public static DataTable GetAllTempImageDetials()
        {
            return TempImageDataLayer.GetAllTempImageDetials();
        }

        public static DataTable GetAllIDWiseTempImageDetials(String Id)
        {
            return TempImageDataLayer.GetAllIDWiseTempImageDetials(Id);
        }



    }

    public class BannerLogicLayer
    {

        string _BannerId, _BannerName, _Image, _IsAcitve, _EntryDate;

        public BannerLogicLayer()
        {
            _BannerId = "  ";
            _BannerName = "  ";
            _Image = "  ";
            _IsAcitve = "  ";
            _EntryDate = "  ";


        }
        public string BannerId { get { return _BannerId; } set { _BannerId = value; } }
        public string BannerName { get { return _BannerName; } set { _BannerName = value; } }
        public string Image { get { return _Image; } set { _Image = value; } }
        public string IsAcitve { get { return _IsAcitve; } set { _IsAcitve = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }


        public static string InsertBannerDetials(BannerLogicLayer BannerDetail)
        {
            return BannerDataLayer.InsertBannerDetials(BannerDetail);
        }

        public static string updateBannerDetials(BannerLogicLayer BannerDetail)
        {
            return BannerDataLayer.UpdateBannerDetials(BannerDetail);
        }

        public static DataTable GetAllBannerDetials()
        {
            return BannerDataLayer.GetAllBannerDetials();
        }
        public static DataTable GetAllBannerDetialsIsAcitveonly()
        {
            return BannerDataLayer.GetAllBannerDetialsIsAcitveonly();
        }
        public static DataTable GetAllIDWiseBannerDetials(String Id)
        {
            return BannerDataLayer.GetAllIDWiseBannerDetials(Id);
        }
        public static string DeleteIDWiseBannerDetials(String Id)
        {
            return BannerDataLayer.DeleteIDWiseBannerDetials(Id);
        }
        public static string GetCount()
        {
            return BannerDataLayer.GetCount();
        }


    }

    public class loginDetailLogicLayer
    {

        string _MobileNo, _TheatresId, _UserId, _ProfileName, _EmailAddress, _Password, _FirstName, _LastName, _Gender, _StreetAddress, _City, _Province, _PostalCode, _MobileNumber, _LandLineNumber, _FullAddress, _Entrydate, _Updatedate, _IsAdmin;

        public loginDetailLogicLayer()
        {
            _MobileNo = " ";
            _TheatresId = " ";
            _UserId = "  ";
            _ProfileName = "  ";
            _EmailAddress = "  ";
            _Password = "  ";
            _FirstName = "  ";
            _LastName = "  ";
            _Gender = "  ";
            _StreetAddress = "  ";
            _City = "  ";
            _Province = "  ";
            _PostalCode = "  ";
            _MobileNumber = "  ";
            _LandLineNumber = "  ";
            _FullAddress = "  ";
            _Entrydate = "  ";
            _Updatedate = "  ";
            _IsAdmin = "  ";


        }
        public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }
        public string TheatresId { get { return _TheatresId; } set { _TheatresId = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public string ProfileName { get { return _ProfileName; } set { _ProfileName = value; } }
        public string EmailAddress { get { return _EmailAddress; } set { _EmailAddress = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        public string StreetAddress { get { return _StreetAddress; } set { _StreetAddress = value; } }
        public string City { get { return _City; } set { _City = value; } }
        public string Province { get { return _Province; } set { _Province = value; } }
        public string PostalCode { get { return _PostalCode; } set { _PostalCode = value; } }
        public string MobileNumber { get { return _MobileNumber; } set { _MobileNumber = value; } }
        public string LandLineNumber { get { return _LandLineNumber; } set { _LandLineNumber = value; } }
        public string FullAddress { get { return _FullAddress; } set { _FullAddress = value; } }
        public string Entrydate { get { return _Entrydate; } set { _Entrydate = value; } }
        public string Updatedate { get { return _Updatedate; } set { _Updatedate = value; } }
        public string IsAdmin { get { return _IsAdmin; } set { _IsAdmin = value; } }


        public static string InsertloginDetailDetials(loginDetailLogicLayer loginDetailDetail)
        {
            return loginDetailDataLayer.InsertloginDetailDetials(loginDetailDetail);
        }

        public static string updateloginDetailDetials(loginDetailLogicLayer loginDetailDetail)
        {
            return loginDetailDataLayer.UpdateloginDetailDetials(loginDetailDetail);
        }
        public static string updateloginDetailDetialsProfile(loginDetailLogicLayer loginDetailDetail)
        {
            return loginDetailDataLayer.updateloginDetailDetialsProfile(loginDetailDetail);
        }
        public static string updateloginDetailDetialsAddress(loginDetailLogicLayer loginDetailDetail)
        {
            return loginDetailDataLayer.updateloginDetailDetialsAddress(loginDetailDetail);
        }
        public static string updatePasswordDetials(loginDetailLogicLayer loginDetailDetail)
        {
            return loginDetailDataLayer.updatePasswordDetials(loginDetailDetail);
        }
        public static string updateEmailAddressDetials(loginDetailLogicLayer loginDetailDetail)
        {
            return loginDetailDataLayer.updateEmailAddressDetials(loginDetailDetail);
        }
        public static DataTable GetAllloginDetailDetials()
        {
            return loginDetailDataLayer.GetAllloginDetailDetials();
        }

        public static DataTable GetAllIDWiseloginDetailDetials(String Id)
        {
            return loginDetailDataLayer.GetAllIDWiseloginDetailDetials(Id);
        }
        public static DataTable GetLoginDataWithEmailId(String Id)
        {
            return loginDetailDataLayer.GetLoginDataWithEmailId(Id);
        }


    }

    public class MenuMasterLogicLayer
    {

        string _MenuId, _MenuName, _EntryBy, _EntryDate, _UpdateBy, _UpdateDate;

        public MenuMasterLogicLayer()
        {
            _MenuId = "  ";
            _MenuName = "  ";
            _EntryBy = "  ";
            _EntryDate = "  ";
            _UpdateBy = "  ";
            _UpdateDate = "  ";


        }
        public string MenuId { get { return _MenuId; } set { _MenuId = value; } }
        public string MenuName { get { return _MenuName; } set { _MenuName = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public string UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }


        public static string InsertMenuMasterDetials(MenuMasterLogicLayer MenuMasterDetail)
        {
            return MenuMasterDataLayer.InsertMenuMasterDetials(MenuMasterDetail);
        }

        public static string updateMenuMasterDetials(MenuMasterLogicLayer MenuMasterDetail)
        {
            return MenuMasterDataLayer.UpdateMenuMasterDetials(MenuMasterDetail);
        }

        public static DataTable GetAllMenuMasterDetials()
        {
            return MenuMasterDataLayer.GetAllMenuMasterDetials();
        }

        public static DataTable GetAllIDWiseMenuMasterDetials(string Id)
        {
            return MenuMasterDataLayer.GetAllIDWiseMenuMasterDetials(Id);
        }
        public static string DeleteIDWiseMenuMasterDetials(string Id)
        {
            return MenuMasterDataLayer.DeleteIDWiseMenuMasterDetials(Id);
        }

        public static DataTable GetUserId(string id)
        {
            return MenuMasterDataLayer.GetUserId(id);
        }

        public static DataTable GetLogin(string id, string password)
        {
            return MenuMasterDataLayer.GetLogin(id, password);
        }

    }

    
    public class AccessoriesProductDetailLogicLayer
    {

        string _AccessoriesProductDetailID, _ProductId, _FeatureHeader, _FeatureSubHeader, _FeatureDescription;

        public AccessoriesProductDetailLogicLayer()
        {
            _AccessoriesProductDetailID = "  ";
            _ProductId = "";
            _FeatureHeader = "";
            _FeatureSubHeader = "";
            _FeatureDescription = "";


        }
        public string AccessoriesProductDetailID { get { return _AccessoriesProductDetailID; } set { _AccessoriesProductDetailID = value; } }
        public string ProductId { get { return _ProductId; } set { _ProductId = value; } }
        public string FeatureHeader { get { return _FeatureHeader; } set { _FeatureHeader = value; } }
        public string FeatureSubHeader { get { return _FeatureSubHeader; } set { _FeatureSubHeader = value; } }
        public string FeatureDescription { get { return _FeatureDescription; } set { _FeatureDescription = value; } }


        public static string InsertAccessoriesProductDetailDetials(AccessoriesProductDetailLogicLayer AccessoriesProductDetailDetail)
        {
            return AccessoriesProductDetailDataLayer.InsertAccessoriesProductDetailDetials(AccessoriesProductDetailDetail);
        }

        public static string updateAccessoriesProductDetailDetials(AccessoriesProductDetailLogicLayer AccessoriesProductDetailDetail)
        {
            return AccessoriesProductDetailDataLayer.UpdateAccessoriesProductDetailDetials(AccessoriesProductDetailDetail);
        }

        public static DataTable GetAllAccessoriesProductDetailDetials()
        {
            return AccessoriesProductDetailDataLayer.GetAllAccessoriesProductDetailDetials();
        }

        public static DataSet GetAllIDWiseAccessoriesProductDetailDetials(string Id)
        {
            return AccessoriesProductDetailDataLayer.GetAllIDWiseAccessoriesProductDetailDetials(Id);
        }
        public static DataSet GetAllProductIDWiseAccessoriesProductDetailDetials(string Id, string PId)
        {
            return AccessoriesProductDetailDataLayer.GetAllProductIDWiseAccessoriesProductDetailDetials(Id, PId);
        }
        public static DataTable GetAllIDWiseAccessoriesProductDetailDetials1(string Id)
        {
            return AccessoriesProductDetailDataLayer.GetAllIDWiseAccessoriesProductDetailDetials1(Id);
        }
        public static string DeleteAccessoriesProductDetail(string Id)
        {
            return AccessoriesProductDetailDataLayer.DeleteAccessoriesProductDetail(Id);
        }

        public static DataTable GetAllProductDetials()
        {
            return AccessoriesProductDetailDataLayer.GetAllProductDetials();
        }

        public static DataTable GetAllProductDetials1()
        {
            return AccessoriesProductDetailDataLayer.GetAllProductDetials1();
        }
        public static DataTable GetAllProductDetials2(string Id)
        {
            return AccessoriesProductDetailDataLayer.GetAllProductDetials2(Id);
        }
    }

    

    public class CityLogicLayer
    {

        string _CityId, _CityName, _EntryBy, _EntryDate, _UpdateBy, _UpdateDate;

        public CityLogicLayer()
        {
            _CityId = "  ";
            _CityName = "  ";
            _EntryBy = "  ";
            _EntryDate = "  ";
            _UpdateBy = "  ";
            _UpdateDate = "  ";


        }
        public string CityId { get { return _CityId; } set { _CityId = value; } }
        public string CityName { get { return _CityName; } set { _CityName = value; } }
        public string EntryBy { get { return _EntryBy; } set { _EntryBy = value; } }
        public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public string UpdateBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public string UpdateDate { get { return _UpdateDate; } set { _UpdateDate = value; } }


        public static string InsertCityDetials(CityLogicLayer CityDetail)
        {
            return CityDataLayer.InsertCityDetials(CityDetail);
        }

        public static string updateCityDetials(CityLogicLayer CityDetail)
        {
            return CityDataLayer.UpdateCityDetials(CityDetail);
        }

        public static DataTable GetAllCityDetials()
        {
            return CityDataLayer.GetAllCityDetials();
        }
        public static DataTable GetAllCitySelect()
        {
            return CityDataLayer.GetAllCitySelect();
        }
        public static DataTable GetAllIDWiseCityDetials(string Id)
        {
            return CityDataLayer.GetAllIDWiseCityDetials(Id);
        }
        public static string DeleteCityDetials(string Id)
        {
            return CityDataLayer.DeleteCityDetials(Id);
        }



    }

    
    public class UserAddressMasterLogicLayer
    {

        string _UserAddressMasterId, _UserAddress, _UserId, _DefultAddress, _entryDate;

        public UserAddressMasterLogicLayer()
        {
            _UserAddressMasterId = "  ";
            _UserAddress = "  ";
            _UserId = "  ";
            _DefultAddress = "  ";
            _entryDate = "  ";


        }
        public string UserAddressMasterId { get { return _UserAddressMasterId; } set { _UserAddressMasterId = value; } }
        public string UserAddress { get { return _UserAddress; } set { _UserAddress = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public string DefultAddress { get { return _DefultAddress; } set { _DefultAddress = value; } }
        public string entryDate { get { return _entryDate; } set { _entryDate = value; } }


        public static string InsertUserAddressMasterDetials(UserAddressMasterLogicLayer UserAddressMasterDetail)
        {
            return UserAddressMasterDataLayer.InsertUserAddressMasterDetials(UserAddressMasterDetail);
        }

        public static string updateUserAddressMasterDetials(UserAddressMasterLogicLayer UserAddressMasterDetail)
        {
            return UserAddressMasterDataLayer.UpdateUserAddressMasterDetials(UserAddressMasterDetail);
        }

        public static DataTable GetAllUserAddressMasterDetials()
        {
            return UserAddressMasterDataLayer.GetAllUserAddressMasterDetials();
        }

        public static DataTable GetAllIDWiseUserAddressMasterDetials(String Id)
        {
            return UserAddressMasterDataLayer.GetAllIDWiseUserAddressMasterDetials(Id);
        }
        public static DataTable DeleteUserAddressMasterDetials(String Id)
        {
            return UserAddressMasterDataLayer.DeleteUserAddressMasterDetials(Id);
        }



    }

    public class UserMasterLogicLayer
    {

        string _UserId, _ProfileName, _EmailAddress, _Password, _FirstName, _LastName, _MobileNumber, _LandLineNumber, _Gender, _Entrydate, _Updatedate;

        public UserMasterLogicLayer()
        {
            _UserId = "  ";
            _ProfileName = "  ";
            _EmailAddress = "  ";
            _Password = "  ";
            _FirstName = "  ";
            _LastName = "  ";
            _MobileNumber = "  ";
            _LandLineNumber = "  ";
            _Gender = "  ";
            _Entrydate = "  ";
            _Updatedate = "  ";


        }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public string ProfileName { get { return _ProfileName; } set { _ProfileName = value; } }
        public string EmailAddress { get { return _EmailAddress; } set { _EmailAddress = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string MobileNumber { get { return _MobileNumber; } set { _MobileNumber = value; } }
        public string LandLineNumber { get { return _LandLineNumber; } set { _LandLineNumber = value; } }
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        public string Entrydate { get { return _Entrydate; } set { _Entrydate = value; } }
        public string Updatedate { get { return _Updatedate; } set { _Updatedate = value; } }


        public static string InsertUserMasterDetials(UserMasterLogicLayer UserMasterDetail)
        {
            return UserMasterDataLayer.InsertUserMasterDetials(UserMasterDetail);
        }

        public static string updateUserMasterDetials(UserMasterLogicLayer UserMasterDetail)
        {
            return UserMasterDataLayer.UpdateUserMasterDetials(UserMasterDetail);
        }
        public static string UpdateUserMasterPersonalDetials(UserMasterLogicLayer UserMasterDetail)
        {
            return UserMasterDataLayer.UpdateUserMasterPersonalDetials(UserMasterDetail);
        }
        public static string UpdateUserMasterChangePasswordDetials(UserMasterLogicLayer UserMasterDetail)
        {
            return UserMasterDataLayer.UpdateUserMasterChangePasswordDetials(UserMasterDetail);
        }
        public static string UpdateUserMasterChangeEmailDetials(UserMasterLogicLayer UserMasterDetail)
        {
            return UserMasterDataLayer.UpdateUserMasterChangeEmailDetials(UserMasterDetail);
        }
        public static DataTable GetAllUserMasterDetials()
        {
            return UserMasterDataLayer.GetAllUserMasterDetials();
        }

        public static DataTable GetAllIDWiseUserMasterDetials(String Id)
        {
            return UserMasterDataLayer.GetAllIDWiseUserMasterDetials(Id);
        }
        public static DataTable GetLoginData(UserMasterLogicLayer UserMasterDetail)
        {
            return UserMasterDataLayer.GetLoginData(UserMasterDetail);
        }
        public static DataTable GetLoginDataWithEmailId(UserMasterLogicLayer UserMasterDetail)
        {
            return UserMasterDataLayer.GetLoginDataWithEmailId(UserMasterDetail);
        }




    }

    
}
