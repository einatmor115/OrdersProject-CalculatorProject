using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    interface Icustomer
    {
        List<order> viewAllMyShoopingList(customer c);
        void CalculateTotal(customer c);
        List<products> watchAllProducts();
        void orderNewProduct(customer c);
        List<customer> customerslist();
        void NewCustomer();
    }
}
