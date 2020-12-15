using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLibrary
{
    public class MngInsert
    {

        public int  Admin_InsertAllCustomer(CustomModels.ClsMainModel.ClsCustomer m)
        {
            using (Entities objContext = new Entities())
            {
                BusinessLayerLibrary.Customer dbm = new BusinessLayerLibrary.Customer();
                //dbm.CustomerID = m.CustomerID;
                dbm.CustomerName = m.CustomerName;
                dbm.CustomerConact = m.CustomerConact;
                dbm.CustomerCNIC = m.CustomerCNIC;
                dbm.CustomerAddress = m.CustomerAddress;
                dbm.isActive = true;
                dbm.CreatedByUser_ID = 1;
                dbm.EntryDate = Convert.ToDateTime("2020-10-24 21:02:27.877");

                objContext.Customer.Add(dbm);
                objContext.SaveChanges();
               return dbm.CustomerID;
              
            }

        }



        public void Admin_InsertCustomerEventOrder(int Customer_ID, int Services_ID, int SubServices_ID, int EventType_ID, int PriceMenu_ID, int CreatedByUser_ID, out bool Status, out string StatusDetails)
        {
            Status = false;
            StatusDetails = null;

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("usp_InsertCustomerEventOrder", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Customer_ID", Customer_ID);
                cmd.Parameters.AddWithValue("@Services_ID", 1); //1 == Grand Hall
                cmd.Parameters.AddWithValue("@SubServices_ID", SubServices_ID);
                cmd.Parameters.AddWithValue("@EventType_ID", EventType_ID);
                cmd.Parameters.AddWithValue("@PriceMenu_ID", PriceMenu_ID);
                cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);

                SqlParameter StatusParm = new SqlParameter("@Status", SqlDbType.Bit);
                StatusParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(StatusParm);

                SqlParameter StatusDetailsParm = new SqlParameter("@StatusDetails", SqlDbType.VarChar, 200);
                StatusDetailsParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(StatusDetailsParm);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Status = (bool)StatusParm.Value;
                StatusDetails = (string)StatusDetailsParm.Value;
            }
            catch (Exception ex)
            {
                Status = false;
                StatusDetails = ex.Message;
                return;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }


        public void Admin_InsertSliderOnlyDetails(string SliderTitle, string SliderDecription, string SelecPage, bool isVideo, int User_ID, out bool _Status, out string _StatusDetails, out int SliderID)
        {
            _Status = false;
            _StatusDetails = null;
            SliderID = 0;

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("InsertSliderOnlyDetails", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SliderTitle", SliderTitle);
                cmd.Parameters.AddWithValue("@SliderDecription", SliderDecription);
                cmd.Parameters.AddWithValue("@SelecPage", SelecPage);
                cmd.Parameters.AddWithValue("@isVideo", isVideo);
                cmd.Parameters.AddWithValue("@User_ID", User_ID);

                SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                _StatusParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusParm);

                SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                _StatusDetailsParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusDetailsParm);

                SqlParameter SliderIDParm = new SqlParameter("@SliderID", SqlDbType.Int);
                SliderIDParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(SliderIDParm);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                _Status = (bool)_StatusParm.Value;
                _StatusDetails = (string)_StatusDetailsParm.Value;
                SliderID = (int)SliderIDParm.Value;
            }
            catch (Exception ex)
            {
                _Status = false;
                _StatusDetails = ex.Message;
                SliderID = 0;
                return;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }
        public void Admin_SliderUpdateByID(int SliderID, string SliderImagePath, out bool _Status, out string _StatusDetails)
        {
            _Status = false;
            _StatusDetails = null;

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Slider_UpdateByID", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SliderID", SliderID);
                cmd.Parameters.AddWithValue("@SliderImagePath", SliderImagePath);

                SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                _StatusParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusParm);

                SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                _StatusDetailsParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusDetailsParm);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                _Status = (bool)_StatusParm.Value;
                _StatusDetails = (string)_StatusDetailsParm.Value;
            }
            catch (Exception ex)
            {
                _Status = false;
                _StatusDetails = ex.Message;
                return;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }

        public void Admin_InsertFoodMenu(string PriceMenuTitle, long Price, string PriceMenuPicture, string PriceMenuPictureOnlyPath, int CreatedByUser_ID, out bool _Status, out string _StatusDetails)
        {
            _Status = false;
            _StatusDetails = null;

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("InsertFoodMenu", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PriceMenuTitle", PriceMenuTitle);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@PriceMenuPicture", PriceMenuPicture);
                cmd.Parameters.AddWithValue("@PriceMenuPictureOnlyPath", PriceMenuPictureOnlyPath);
                cmd.Parameters.AddWithValue("@CreatedByUser_ID", CreatedByUser_ID);

                SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                _StatusParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusParm);

                SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                _StatusDetailsParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusDetailsParm);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                _Status = (bool)_StatusParm.Value;
                _StatusDetails = (string)_StatusDetailsParm.Value;
            }
            catch (Exception ex)
            {
                _Status = false;
                _StatusDetails = ex.Message;
                return;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }


    }
}
