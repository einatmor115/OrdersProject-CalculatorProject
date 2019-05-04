using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    class products 
    {
        public int product_number { get; set; }
        public string product_name { get; set; }
        public int supplier_number { get; set; }
        public int price { get; set; }
        public int amount { get; set; }


        public override int GetHashCode()
        {
            return (int)product_number;
        }

        public override string ToString()
        {
            return $"{product_number} {product_name} {supplier_number} {price} {amount} ";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            products other = obj as products;
            if (other == null)
                return false;

            return this.product_number == other.product_number;
        }


        public void addPoduct()
        {
            throw new NotImplementedException();
        }

        public void removeProduct()
        {
            throw new NotImplementedException();
        }

    }
}
