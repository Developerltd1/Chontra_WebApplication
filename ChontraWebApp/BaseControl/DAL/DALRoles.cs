using MyCode.DAL;
using MyCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyCode.Utilities;

namespace MyCode.DAL
{
    public class DALRoles
    {
        public List<ClsDALRoles> GetAllRoles(ClsDALRoles u)
        {
            List<ClsDALRoles> list = new List<ClsDALRoles>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(dbConnection.GetConnectionString());
                cmd = new SqlCommand("membership_GetAllRoles", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
//                cmd.Parameters.AddWithValue("@Organization_ID", u.Organization_ID);
                conn.Open();
                DataTable dt = new DataTable();
                Adapter.Fill(dt);
                conn.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    u = new ClsDALRoles();
                    u.RoleID = dr["RoleID"].ToInt32();
                    u.RoleName = dr["RoleName"].ToString();
                   // u.Organization_ID = dr["Organization_ID"].ToInt32();
                    u.IsActive = dr["IsActive"].ToBool();
                    list.Add(u);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
            return list;
        }
        public ClsDALRoles GetRoleByID(int RoleID= 1)  //RoleID)  //StaticChange
        {
            ClsDALRoles ob = new ClsDALRoles();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(Utilities.dbConnection.GetConnectionString());
                cmd = new SqlCommand("membership_GetRoleByID", conn);
                cmd.Parameters.AddWithValue("@RoleID", RoleID);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                conn.Open();
                DataSet ds = new DataSet();
                Adapter.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    ob.RoleID = row["RoleID"].ToInt32();
                    ob.RoleName = row["RoleName"].ToString2();
                    ob.RoleWebPages = new List<ClsRoleWebPages>();
                }
                DataRow[] Parents = ds.Tables[1].Select("Parent_ID=0");

                foreach (DataRow dr in Parents)
                {
                    ClsRoleWebPages p = new ClsRoleWebPages();

                    p.WebPageID = dr["WebPageID"].ToInt32();
                    p.PageTitle = dr["PageTitle"].ToString2();
                    p.Parent_ID = dr["Parent_ID"].ToInt32();
                    p.PageIcon = dr["PageIcon"].ToString2();
                    p.HasInsert = dr["HasInsert"].ToBool();
                    p.HasUpdate = dr["HasUpdate"].ToBool();
                    p.HasDelete = dr["HasDelete"].ToBool();
                    if (p.HasInsert || p.HasUpdate || p.HasDelete)
                    {
                        p.IsChecked = true;
                    }
                    else
                    {
                        p.IsChecked = false;
                    }

                    p.Childs = new List<ClsRoleWebPages>();
                    DataRow[] Childs = ds.Tables[1].Select("Parent_ID=" + p.WebPageID);
                    foreach (DataRow c in Childs)
                    {
                        ClsRoleWebPages ch = new ClsRoleWebPages();

                        ch.WebPageID = c["WebPageID"].ToInt32();
                        ch.PageTitle = c["PageTitle"].ToString2();
                        ch.Parent_ID = c["Parent_ID"].ToInt32();
                        ch.HasInsert = c["HasInsert"].ToBool();
                        ch.HasUpdate = c["HasUpdate"].ToBool();
                        ch.HasDelete = c["HasDelete"].ToBool();
                        if (ch.HasInsert || ch.HasUpdate || ch.HasDelete)
                        {
                            ch.IsChecked = true;
                        }
                        else
                        {
                            ch.IsChecked = false;
                        }
                        p.Childs.Add(ch);
                    }
                    ob.RoleWebPages.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
            return ob;
        }


        public bool SaveRole(ClsDALRoles u)
        {
            bool result = false;
            int RoleID = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlTransaction transaction = null;
            try
            {
                conn = new SqlConnection(Utilities.dbConnection.GetConnectionString());
                conn.Open();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand("membership_AddRole", conn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleID", u.RoleID).Direction = ParameterDirection.InputOutput;
                cmd.Parameters.AddWithValue("@RoleName", u.RoleName);
                cmd.Parameters.AddWithValue("@CreatedBy", u.CreatedBy);
                cmd.ExecuteNonQuery();

                RoleID = cmd.Parameters["@RoleID"].Value.ToInt32();
                if (RoleID == 0)
                {
                    result = false;
                    return result;
                }
                else
                {
                    cmd.CommandText = "membership_AddRolePages";
                    foreach (ClsRoleWebPages p in u.RoleWebPages)
                    {
                        if (p.HasInsert || p.HasUpdate || p.HasDelete)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@RoleID", RoleID);
                            cmd.Parameters.AddWithValue("@WebPage_ID", p.WebPageID);
                            cmd.Parameters.AddWithValue("@HasInsert", p.HasInsert);
                            cmd.Parameters.AddWithValue("@HasUpdate", p.HasUpdate);
                            cmd.Parameters.AddWithValue("@HasDelete", p.HasDelete);
                            result = cmd.ExecuteNonQuery().ToBool();
                        }
                    }
                    transaction.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;

            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }
    }
}
