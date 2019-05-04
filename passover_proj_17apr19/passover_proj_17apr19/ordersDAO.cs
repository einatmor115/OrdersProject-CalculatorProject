using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    class ordersDAO : Iorder
    {
        public void AddNewOrder(products o, customer c)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@customer_number", c.cust_id));
            cmd.Parameters.Add(new SqlParameter("@product_number", o.product_number));
            cmd.Parameters.Add(new SqlParameter("@orders_amount", o.amount));
            cmd.Parameters.Add(new SqlParameter("@total_price", o.price));
            cmd.Parameters.Add(new SqlParameter("@prodct_name", o.product_name));

            cmd.CommandText = ("insert into  orders(customer_number, product_number, orders_amount, total_price, prodct_name)" +
              "values(@customer_number, @product_number, @orders_amount, @total_price, @prodct_name)'");

            Console.WriteLine("edding new order went well(:");

        }
    }
}
