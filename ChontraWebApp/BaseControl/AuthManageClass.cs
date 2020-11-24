using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode
{
    public class AuthManageClass
    {
        public static List<DAL.ClsWebPages> GetSideMenusByRoleID()  //(int in_RoleID  = 1)storeprocedureChanges
        {
            // DataTable Declaration
            DataTable dt = new DataTable();
            List<DAL.ClsWebPages> Menus = new List<DAL.ClsWebPages>(); //List
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                
                string ConnectionString = MyCode.Utilities.dbConnection.GetConnectionString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetSideMenusByRoleID", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@in_RoleID", 1);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
                DataTable distinctValues = new DataView(dt).ToTable(true, "WebPageID", "PageTitle", "ControllerName", "ViewName", "AreaName", "Parent_ID", "PageIcon", "HasInsert", "HasUpdate", "HasDelete", "MenuTitle", "IsHorizantal", "MenuColor");


                foreach (DataRow dr in distinctValues.Rows)  //asign from distint to Rows
                {
                    //In Foreach loop Values Assign to Model from distint Table Rows.
                    DAL.ClsWebPages p = new DAL.ClsWebPages();
                    p.WebPageID = (int)dr["WebPageID"].ToInt32();
                    p.PageTitle = (string)dr["PageTitle"].ToString2();
                    p.MenuTitle = (string)dr["MenuTitle"].ToString2();
                    p.ControllerName = (string)dr["ControllerName"].ToString2();
                    p.ViewName = (string)dr["ViewName"].ToString2();
                    p.AreaName = (string)dr["AreaName"].ToString2();
                    p.Parent_ID = (int)dr["Parent_ID"].ToInt32();
                    p.PageIcon = (string)dr["PageIcon"].ToString2();
                    p.HasInsert = (bool)dr["HasInsert"].ToBool();
                    p.HasUpdate = (bool)dr["HasUpdate"].ToBool();
                    p.HasDelete = (bool)dr["HasDelete"].ToBool();
                    p.MenuColor = (string)dr["MenuColor"].ToString2();
                    p.IsHorizantal = (bool)dr["IsHorizantal"].ToBool();
                    p.Urls = new List<string>();

                    // Check Where if dt compare to model.WebPageID then Get URL Base on model.WebpageID And Assign to Model.Url List<>
                    p.Urls = dt.AsEnumerable().Where(d => d.Field<int>("WebPageID") == p.WebPageID)
                                                     .Select(s => s.Field<string>("Url"))
                                                     .Distinct()
                                                     .ToList();
                    //Assign Values to List
                    Menus.Add(p);
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
            return Menus;
        }
    }
}
