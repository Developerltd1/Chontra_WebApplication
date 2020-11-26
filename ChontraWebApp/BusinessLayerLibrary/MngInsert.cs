using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLibrary
{
    public class MngInsert
    {

        public int  Admin_InsertAllCustomer(CustomModels.ClsMainModel.ClsCustomer m)
        {
            using (ChontraEntityModel objContext = new ChontraEntityModel())
            {
                BusinessLayerLibrary.Customer dbm = new BusinessLayerLibrary.Customer();
                //dbm.CustomerID = m.CustomerID;
                dbm.CustomerName = m.CustomerName;
                dbm.CustomerConact = m.CustomerConact;
                dbm.CustomerCNIC = m.CustomerCNIC;
                dbm.CustomerAddress = m.CustomerAddress;
                dbm.isActive = m.isActive;
                dbm.CreatedByUser_ID = 1;
                dbm.EntryDate = Convert.ToDateTime("2020-10-24 21:02:27.877");

        objContext.Customers.Add(dbm);
                objContext.SaveChanges();
               return dbm.CustomerID;
              
            }

        }


    }
}
