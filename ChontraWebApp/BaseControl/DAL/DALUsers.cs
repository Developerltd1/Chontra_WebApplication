using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCode.DAL
{
    public class DALUsers
    {
        public DataTable AuthenticateUser(string UserName, string Password, out bool _Status, out string _StatusDetails)
        {
            DataTable dt = new DataTable();
            _Status = false;
            _StatusDetails = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(Utilities.dbConnection.GetConnectionString());
                cmd = new SqlCommand("membership_AuthenticateUser", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@in_UserName", UserName);
                cmd.Parameters.AddWithValue("@in_Password", Password);
                SqlParameter _StatusParm = new SqlParameter("@_Status", SqlDbType.Bit);
                _StatusParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusParm);

                SqlParameter _StatusDetailsParm = new SqlParameter("@_StatusDetails", SqlDbType.VarChar, 100);
                _StatusDetailsParm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_StatusDetailsParm);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
                _Status = (bool)_StatusParm.Value;
                _StatusDetails = (string)_StatusDetailsParm.Value;
                if (dt.Rows.Count > 0)
                {
                    _Status = true;
                }
            }
            catch (Exception ex)
            {
                _Status = false;
                _StatusDetails = ex.Message;

            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
            return dt;
        }

    }
}
