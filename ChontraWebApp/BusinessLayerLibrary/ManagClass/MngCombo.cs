using MyCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyCode.Utilities.MyExtensions;

namespace BusinessLayerLibrary.ManagClass
{
    public class MngCombo
    {
        public enum StagesEventType 
        { MehndiStage, 
            BaratStage, 
            WalimaStage 
        }

        public struct ConvertEnum
        {
            public int Value
            {
                get;
                set;
            }
            public String Text
            {
                get;
                set;
            }
        }

        public List<DropDownModal> GetHallName()
        {
            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Combo_GetAllHalls", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                return Utilities.MyExtensions.ToSelectList(dt, "SubServiceID", "SubServiceTitle");
            }
            catch (Exception ex)
            {
                //Return Value
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public List<DropDownModal> GetEventType()
        {
            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Combo_GetAllEventType", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                return Utilities.MyExtensions.ToSelectList(dt, "EventTypeID", "EventType");
            }
            catch (Exception ex)
            {
                //Return Value
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public List<DropDownModal> GetPriceMenu()
        {
            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Combo_GetAllPriceMenu", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                return Utilities.MyExtensions.ToSelectList(dt, "PriceMenuID", "PriceMenuTitle");
            }
            catch (Exception ex)
            {
                //Return Value
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public List<DropDownModal> GetSelectPage()
        {

            DataTable dt1 = new DataTable();
            dt1.Columns.Add(new DataColumn() { ColumnName = "dtSelectPage" });
            dt1.Rows.Add("Home Page");
            dt1.Rows.Add("About Page");

            try
            {
                return Utilities.MyExtensions.ToSelectListIfDistinct(dt1, "dtSelectPage", "dtSelectPage");
            }
            catch (Exception ex)
            {
                //Return Value
                throw ex;
            }
        }
        public DataTable GetAllPriceMenu_ByPriceMenuID(int PriceMenuID)
        {
            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Combo_GetAllPriceMenu_ByPriceMenuID", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@PriceMenuID", PriceMenuID);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
                return dt;
                
            }
            catch (Exception ex)
            {
                //Return Value
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public List<DropDownModal> GetEventTimingType()
        {
            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetAllEventTimingType", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                return Utilities.MyExtensions.ToSelectList(dt, "EventTimingTypeID", "EventTimingType");
            }
            catch (Exception ex)
            {
                //Return Value
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        
    }
}
