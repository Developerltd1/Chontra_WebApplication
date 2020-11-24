using MyCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyCode.Utilities;
using static MyCode.Utilities.MyExtensions;

namespace MyCode.DAL
{
    public class DALCommon
    {
        public List<DropDown> GetActiveRoles(int Organization_ID)
        {
            List<DropDown> ddlList = new List<DropDown>();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(dbConnection.GetConnectionString());
                cmd = new SqlCommand("membership_GetActiveRoles", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Organization_ID", Organization_ID);
                DataTable dt = new DataTable();
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    ddlList.Add(new DropDown()
                    {
                        Value = dr["RoleID"].ToInt32(),
                        Text = dr["RoleName"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
            }

            return ddlList;
        }
    }
}
