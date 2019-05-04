using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    interface Isupplier
    {
        List<supplier> supplierList();
        void addNewSupplier();
        List<products> viewAllMyProducts(supplier s);
        void AddNewProduct(supplier s);
    }
}
