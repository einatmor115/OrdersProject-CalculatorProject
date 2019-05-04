using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    interface Iproducts
    {
        products GetProductbyName(string pName);
        void addExistingPoduct(string productName, int amountOfProducts);
        void AddNewProduct(string product_name, supplier s);
        void removeProduct(string productName, int amountOfProducts);
    }
}
