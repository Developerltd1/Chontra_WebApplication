using BusinessLayerLibrary.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLibrary.ManagClass
{
    public class MngEdit
    {
        private Entities objContext;


        public int DeleteCustomer(int id)
        {
            using (objContext = new Entities())
            {
               Customer m = new Customer();
               m = objContext.Customer.First(t => t.CustomerID.Equals(id));
               m.isActive = false;
               return objContext.SaveChanges();
            }
        }

        public ClsMainModel.ClsCustomer UpdateCustomer(int id)
        {
            using (objContext = new Entities())
            {
                Customer dbm = new Customer();
                dbm = objContext.Customer.FirstOrDefault(t => t.CustomerID.Equals(id));

                CustomModels.ClsMainModel.ClsCustomer m = new ClsMainModel.ClsCustomer();
                m.CustomerID = dbm.CustomerID;
                m.CustomerName = dbm.CustomerName;
                m.CustomerCNIC = dbm.CustomerCNIC;
                m.CustomerConact = dbm.CustomerConact;
                m.CustomerAddress = dbm.CustomerAddress;
                return m;
            }
        }

    }
}
