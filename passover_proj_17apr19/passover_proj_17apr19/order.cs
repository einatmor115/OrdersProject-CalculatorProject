using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    class order
    {
        public int order_number { get; set; }
        public int customer_number { get; set; }
        public int product_number { get; set; }
        public int orders_amount { get; set; }
        public int total_price { get; set; }
        public string prodct_name { get; set; }


        public override int GetHashCode()
        {
            return (int)order_number;
        }

        public override string ToString()
        {
            return $"{order_number} {customer_number} {product_number} {orders_amount} {total_price} {prodct_name}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            order other = obj as order;
            if (other == null)
                return false;

            return this.order_number == other.order_number;
        }

    }
}
