using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using PlayMovieskp.Controller;
using Microsoft.ApplicationBlocks.Data;
using PlayMovieskp.LogicalLayers;
/// <summary>
/// Summary description for DataLayers
/// </summary>
/// 
namespace PlayMovieskp.DataLayer
{
    public class DataLayers
    {
        public DataLayers()
        {

            //
            // TODO: Add constructor logic here
            //
        }

    }
    public class TheatresDataLayer
    {
        public static string InsertTheatresDetials(TheatresLogicLayer TheatresDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLTheatresDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(TheatresDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, TheatresDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLTheatresDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TheatresDetails", strXMLTheatresDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertTheatresDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Theatres Name successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Theatres Name already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateTheatresDetials(TheatresLogicLayer TheatresDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLTheatresDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(TheatresDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, TheatresDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLTheatresDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TheatresDetails", strXMLTheatresDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateTheatresDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Theatres Name successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;


            }
        }
        public static DataTable GetAllTheatresDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllTheatresDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllTheatresSelect()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SelectTheatresDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllTheatresSelectId(string CityName)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Cityid", CityName, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SelectTheatresDetialsCity", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseTheatresDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseTheatresDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteTheatresDetials(string Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteTheatresDetials", paramsToStore).ToString();
                return "Company Name successfully Delete...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return GetAllDetail;
        }
    }
    public class ScreenDataLayer
    {
        public static string InsertScreenDetials(ScreenLogicLayer ScreenDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLScreenDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ScreenDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ScreenDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLScreenDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ScreenDetails", strXMLScreenDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertScreenDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Screen Name successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Screen Name already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateScreenDetials(ScreenLogicLayer ScreenDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLScreenDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ScreenDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ScreenDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLScreenDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ScreenDetails", strXMLScreenDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateScreenDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Screen Name successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;


            }
        }
        public static DataTable GetAllScreenDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllScreenDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllScreenSelect()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SelectScreenDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllScreenSelecttherters(string TID)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", TID, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SelectScreenDetialsTid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseScreenDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseScreenDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteScreenDetials(string Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteScreenDetials", paramsToStore).ToString();
                return "Company Name successfully Delete...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return GetAllDetail;
        }
    }
    public class CateenMasterDataLayer
    {


        public static string InsertCateenMasterDetials(CateenMasterLogicLayer CateenMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCateenMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(CateenMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, CateenMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCateenMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CateenMasterDetails", strXMLCateenMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                string str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "usp_InsertCateenMasterDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;// "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateCateenMasterDetials(CateenMasterLogicLayer CateenMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCateenMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(CateenMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, CateenMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCateenMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CateenMasterDetails", strXMLCateenMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateCateenMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }
        public static DataTable GetAllCateenMasterDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCateenMasterDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllCateenMasterDetialsTID(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCateenMasterDetialsT", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllCateenMasterSelect()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SelectCateenMasterDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseCateenMasterDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseCateenMasterDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseCateenMasterDetialsT(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseCateenMasterDetialsT", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseCateenMasterDetialsFoodName(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Bookingid", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Usp_GetFoodName", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseCateenMasterDetialsFoodNameQtyRate(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Usp_GetFoodNamerate", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseCateenMasterFillGrid(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Bookingid", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetAllIDWiseCateenMasterFillGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteCateenMasterDetials(string Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteCateenMasterDetials", paramsToStore).ToString();
                return "Company Name successfully Delete...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return GetAllDetail;
        }


    }
    public class MoviesDataLayer
    {


        public static string InsertMoviesDetials(MoviesLogicLayer MoviesDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLMoviesDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(MoviesDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, MoviesDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLMoviesDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MoviesDetails", strXMLMoviesDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                string Str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "usp_InsertMoviesDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return Str;// "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateMoviesDetials(MoviesLogicLayer MoviesDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLMoviesDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(MoviesDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, MoviesDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLMoviesDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MoviesDetails", strXMLMoviesDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateMoviesDetail", paramsToStore);
                trn.Commit();   
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }
        public static DataTable GetAllMoviesDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllMoviesDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllMoviesDetialsWithThertresId(string TId)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", TId, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllMoviesDetialsThertres", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllMoviesDetialsWithCity(string City)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", City, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseMoviesDetialsWithCity", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllMoviesDetialsWithTheatres(string Theatres)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Theatres, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseMoviesDetialsWithTheatresId", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllMoviesDetialsWithTheatresupcoming(string Theatres)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Theatres, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseMoviesDetialsWithTheatresIdcoming", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllMoviesSelect()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SelectMoviesDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseMoviesDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseMoviesDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWisebookedSeat(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MovieId", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Usp_BookedSeet", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteMoviesDetials(string Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteMoviesDetials", paramsToStore).ToString();
                return "Company Name successfully Delete...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return GetAllDetail;
        }


    }
    public class bookingDataLayer
    {


        public static string InsertbookingDetials(bookingLogicLayer bookingDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLbookingDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(bookingDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, bookingDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLbookingDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@bookingDetails", strXMLbookingDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                string str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "usp_InsertbookingDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;// "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdatebookingDetials(bookingLogicLayer bookingDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLbookingDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(bookingDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, bookingDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLbookingDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@bookingDetails", strXMLbookingDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdatebookingDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }
        public static DataTable GetAllbookingDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllbookingDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWisebookingDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisebookingDetials",paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWisebookingDetialswithUserId(String UserId)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", UserId, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisebookingDetialsWithUserId", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWisebookingDetialsseatwithUserId(String UserId)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", UserId, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBookedDeatilWithUserId", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string CancelwithBookingseatId(String UserId)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", UserId, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_GetBookedSeatWithId", paramsToStore).ToString();
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string CancelwithBookingId(String UserId)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", UserId, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_GetBookedWithId", paramsToStore).ToString();
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string ReSudulewithBookingId(String UserId)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", UserId, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_GetBookedCancelWithId", paramsToStore).ToString();
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }

    public class BookingCateenDataLayer
    {


        public static string InsertBookingCateenDetials(BookingCateenLogicLayer BookingCateenDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBookingCateenDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BookingCateenDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BookingCateenDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBookingCateenDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BookingCateenDetails", strXMLBookingCateenDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertBookingCateenDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateBookingCateenDetials(BookingCateenLogicLayer BookingCateenDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBookingCateenDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BookingCateenDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BookingCateenDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBookingCateenDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BookingCateenDetails", strXMLBookingCateenDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateBookingCateenDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                return ex.Message;
            }
        }
        public static DataTable GetAllBookingCateenDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBookingCateenDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseBookingCateenDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBookingCateenDetials",paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteIDWiseBookingCateenDetials(String Id)
        {
            String GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeletelIDWiseBookingCateenDetials", paramsToStore).ToString();
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class BookingSeatDataLayer
    {


        public static string InsertBookingSeatDetials(BookingSeatLogicLayer BookingSeatDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBookingSeatDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BookingSeatDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BookingSeatDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBookingSeatDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BookingSeatDetails", strXMLBookingSeatDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertBookingSeatDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateBookingSeatDetials(BookingSeatLogicLayer BookingSeatDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBookingSeatDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BookingSeatDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BookingSeatDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBookingSeatDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BookingSeatDetails", strXMLBookingSeatDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateBookingSeatDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }
        public static DataTable GetAllBookingSeatDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBookingSeatDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseBookingSeatDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBookingSeatDetials",paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseBookedSeatDetials(String Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBookedDeatil", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseBookedCateenDetials(String Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetProductDataForbooked", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseBookingSeat(String MovieId, String bookingType, String BookingDate, String BookingTime)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MovieId", MovieId, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@bookingType", bookingType, SqlDbType.BigInt);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BookingDate", BookingDate, SqlDbType.Date);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@BookingTime", BookingTime, SqlDbType.BigInt);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBookingSeat", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }
    public class TempImageDataLayer
    {


        public static string InsertTempImageDetials(TempImageLogicLayer TempImageDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLTempImageDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(TempImageDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, TempImageDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLTempImageDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TempImageDetails", strXMLTempImageDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                string msg = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "usp_InsertTempImageDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return msg;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateTempImageDetials(TempImageLogicLayer TempImageDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLTempImageDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(TempImageDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, TempImageDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLTempImageDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TempImageDetails", strXMLTempImageDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateTempImageDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static DataTable GetAllTempImageDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllTempImageDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseTempImageDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseTempImageDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }

    public class BannerDataLayer
    {


        public static string InsertBannerDetials(BannerLogicLayer BannerDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBannerDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BannerDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BannerDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBannerDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BannerDetails", strXMLBannerDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                string Str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "usp_InsertBannerDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return Str;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateBannerDetials(BannerLogicLayer BannerDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBannerDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BannerDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BannerDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBannerDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BannerDetails", strXMLBannerDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                string Str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_UpdateBannerDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return Str;

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static DataTable GetAllBannerDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBannerDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllBannerDetialsIsAcitveonly()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBannerDetialsIsActive").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseBannerDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBannerDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteIDWiseBannerDetials(String Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteIDWiseBannerDetials", paramsToStore).ToString();
                return "Banner Successfully Delete....";
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string GetCount()
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_GetCount").ToString();
                return GetAllDetail;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
    public class loginDetailDataLayer
    {


        public static string InsertloginDetailDetials(loginDetailLogicLayer loginDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLloginDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(loginDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, loginDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLloginDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@loginDetailDetails", strXMLloginDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertloginDetailDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "successfully Create New User...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateloginDetailDetials(loginDetailLogicLayer loginDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLloginDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(loginDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, loginDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLloginDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@loginDetailDetails", strXMLloginDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateloginDetailDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Profile Detail successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static string updateloginDetailDetialsProfile(loginDetailLogicLayer loginDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLloginDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(loginDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, loginDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLloginDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@loginDetailDetails", strXMLloginDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateloginDetailDetailProfile", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static string updateloginDetailDetialsAddress(loginDetailLogicLayer loginDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLloginDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(loginDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, loginDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLloginDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@loginDetailDetails", strXMLloginDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateloginDetailDetailAddress", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static string updatePasswordDetials(loginDetailLogicLayer loginDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLloginDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(loginDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, loginDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLloginDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@loginDetailDetails", strXMLloginDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateChangePasswordDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Password successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static string updateEmailAddressDetials(loginDetailLogicLayer loginDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLloginDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(loginDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, loginDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLloginDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@loginDetailDetails", strXMLloginDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateChangeEmailAddressDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Email Address successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static DataTable GetAllloginDetailDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Usp_GetRegisterUser").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetLoginDataWithEmailId(String Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetEmailloginDetailDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseloginDetailDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseloginDetailDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }
    public class MenuMasterDataLayer
    {


        public static string InsertMenuMasterDetials(MenuMasterLogicLayer MenuMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLMenuMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(MenuMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, MenuMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLMenuMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MenuMasterDetails", strXMLMenuMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertMenuMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();
                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateMenuMasterDetials(MenuMasterLogicLayer MenuMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLMenuMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(MenuMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, MenuMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLMenuMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MenuMasterDetails", strXMLMenuMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateMenuMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static DataTable GetAllMenuMasterDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllMenuMasterDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseMenuMasterDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseMenuMasterDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteIDWiseMenuMasterDetials(string Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteIDWiseMenuMasterDetials").ToString();
                return "Details successfully Delete...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static DataTable GetUserId(string id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@id", id, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UPS_GetUserId", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetLogin(string id, string password)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", id, SqlDbType.VarChar);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@password", password, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UPS_GetLoginIdPassword", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }

    

    public class AccessoriesProductDetailDataLayer
    {


        public static string InsertAccessoriesProductDetailDetials(AccessoriesProductDetailLogicLayer AccessoriesProductDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAccessoriesProductDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AccessoriesProductDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AccessoriesProductDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAccessoriesProductDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AccessoriesProductDetailDetails", strXMLAccessoriesProductDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertAccessoriesProductDetailDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateAccessoriesProductDetailDetials(AccessoriesProductDetailLogicLayer AccessoriesProductDetailDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAccessoriesProductDetailDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AccessoriesProductDetailDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AccessoriesProductDetailDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAccessoriesProductDetailDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AccessoriesProductDetailDetails", strXMLAccessoriesProductDetailDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateAccessoriesProductDetailDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }
        public static DataTable GetAllAccessoriesProductDetailDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllAccessoriesProductDetailDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataSet GetAllIDWiseAccessoriesProductDetailDetials(string Id)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseAccessoriesProductDetailDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataSet GetAllProductIDWiseAccessoriesProductDetailDetials(string Id, string PId)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@PId", PId, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllProductIdAndFeatureHeaderWiseAccessoriesProductDetail", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseAccessoriesProductDetailDetials1(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAccessoriesIDWiseAccessoriesProductDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteAccessoriesProductDetail(string Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteAccessoriesIDWiseAccessoriesProductDetails", paramsToStore).ToString();
                return "Details successfully Deleted...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DataTable GetAllProductDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[USP_GetAllAssProductMasterDetials]").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllProductDetials1()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[USP_GetAllAssProductMasterDetialsSearch1]").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllProductDetials2(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[USP_GetAllAssProductMasterDetialsSearch2]", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }

    
    public class CityDataLayer
    {
        public static string InsertCityDetials(CityLogicLayer CityDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCityDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(CityDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, CityDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCityDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CityDetails", strXMLCityDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertCityDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "City Name successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "City Name already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateCityDetials(CityLogicLayer CityDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCityDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(CityDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, CityDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCityDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CityDetails", strXMLCityDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateCityDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "City Name successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;


            }
        }
        public static DataTable GetAllCityDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCityDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllCitySelect()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SelectCityDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseCityDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseCityDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string DeleteCityDetials(string Id)
        {
            string GetAllDetail = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_DeleteCityDetials", paramsToStore).ToString();
                return "Company Name successfully Delete...";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return GetAllDetail;
        }
    }
    
    public class UserAddressMasterDataLayer
    {


        public static string InsertUserAddressMasterDetials(UserAddressMasterLogicLayer UserAddressMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUserAddressMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UserAddressMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UserAddressMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUserAddressMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserAddressMasterDetails", strXMLUserAddressMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertUserAddressMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateUserAddressMasterDetials(UserAddressMasterLogicLayer UserAddressMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUserAddressMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UserAddressMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UserAddressMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUserAddressMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserAddressMasterDetails", strXMLUserAddressMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateUserAddressMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static DataTable GetAllUserAddressMasterDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUserAddressMasterDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseUserAddressMasterDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseUserAddressMasterDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable DeleteUserAddressMasterDetials(String Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_DeleteUserAddressMasterDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }

    public class UserMasterDataLayer
    {


        public static string InsertUserMasterDetials(UserMasterLogicLayer UserMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUserMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UserMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UserMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUserMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserMasterDetails", strXMLUserMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertUserMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateUserMasterDetials(UserMasterLogicLayer UserMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUserMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UserMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UserMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUserMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserMasterDetails", strXMLUserMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateUserMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static string UpdateUserMasterPersonalDetials(UserMasterLogicLayer UserMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUserMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UserMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UserMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUserMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserMasterDetails", strXMLUserMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdatepersonalDetailUserMasterDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static string UpdateUserMasterChangePasswordDetials(UserMasterLogicLayer UserMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUserMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UserMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UserMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUserMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserMasterDetails", strXMLUserMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdatePassword", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static string UpdateUserMasterChangeEmailDetials(UserMasterLogicLayer UserMasterDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUserMasterDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UserMasterDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UserMasterDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUserMasterDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserMasterDetails", strXMLUserMasterDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateEmailAddress", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {
                return ex.Message;
                trn.Rollback();
                con.Close();


            }
        }
        public static DataTable GetAllUserMasterDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUserMasterDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseUserMasterDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseUserMasterDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetLoginData(UserMasterLogicLayer UserMasterDetail)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@EmailAddress", UserMasterDetail.EmailAddress, SqlDbType.VarChar);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Password", UserMasterDetail.Password, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetLoginDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetLoginDataWithEmailId(UserMasterLogicLayer UserMasterDetail)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@EmailAddress", UserMasterDetail.EmailAddress, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetLoginDetailWithEmail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }
    
}

