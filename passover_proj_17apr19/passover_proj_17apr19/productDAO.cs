
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
    class productDAO : Iproducts

    {
        public products GetProductbyName(string pName)
        {
            products e = new products();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"select * from products where product_name = '{pName}'");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                Console.WriteLine($" {reader["product_number"]} {reader["product_name"]} {reader["supplier_number"]} {reader["price"]} {reader["amount"]}");

                {
                    e.product_number = (int)reader["product_number"];
                    e.product_name = (string)reader["product_name"];
                    e.supplier_number = (int)reader["supplier_number"];
                    e.price = (int)reader["price"];
                    e.amount = (int)reader["amount"];
                };
            }
            return e;
        }

        public void addExistingPoduct(string productName, int amountOfProducts)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd1.Connection.Open();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = ($"UPDATE products SET amount = amount + {amountOfProducts} where product_name = '{productName}'");

            SqlDataReader reader = cmd1.ExecuteReader(CommandBehavior.Default);

            cmd1.Connection.Close();
            Console.WriteLine("Adding products went well(:");

            cmd1.Connection.Close();
        }

        public void AddNewProduct(string product_name, supplier s)
        {                      
            Console.WriteLine("enter price");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter amount");
            int amount = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd1.Connection.Open();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = ($"insert into products (product_name, supplier_number, price , amount) values ('{product_name}', {s.supplier_number}, {price}, {amount})");

            SqlDataReader reader = cmd1.ExecuteReader(CommandBehavior.Default);

            cmd1.Connection.Close();
            Console.WriteLine("Adding new products went well(:");
        }

        public void removeProduct(string productName, int amountOfProducts)
        {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
                cmd1.Connection.Open();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = ($"UPDATE products SET amount = amount - {amountOfProducts} where product_name = '{productName}'");

                SqlDataReader reader = cmd1.ExecuteReader(CommandBehavior.Default);

                cmd1.Connection.Close();
                Console.WriteLine("reduce product went well(:");

            cmd1.Connection.Close();

        }
    }
}
