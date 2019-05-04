using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace passover_proj_17apr19
{
   class customerDAO : Icustomer
    {   
        public List<order> viewAllMyShoopingList(customer c)
        {
            customerDAO dao2 = new customerDAO();

            List<order> results = new List<order>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@custId", c.cust_id));
            cmd.CommandText = ($"select * from orders o join Customers c on o.customer_number = c.cust_id where c.cust_id = @custId");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                Console.WriteLine($"order amount:{reader["orders_amount"]} total price: {reader["total_price"]} product: {reader["prodct_name"]}");

                 order e = new order
                    {
                    order_number = (int)reader["order_number"],
                    customer_number = (int)reader["customer_number"],
                    product_number = (int)reader["product_number"],
                    orders_amount = (int)reader["orders_amount"],
                    total_price = (int)reader["total_price"],
                    prodct_name = (string)reader["prodct_name"],

                 };
                results.Add(e);
            }

            cmd.Connection.Close();
            dao2.CalculateTotal(c);
            return results;
        }

        public void CalculateTotal(customer c)
        {
            int total=0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"select sum(total_price) as total from orders where customer_number = {c.cust_id})");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    total = (int)cmd.ExecuteScalar();

                }
                Console.WriteLine($"Total price of all product that you order: {total}");

                cmd.Connection.Close();
            
        }

        public List<products> watchAllProducts()
        {
            List<products> results = new List<products>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("SELECT * FROM products INNER JOIN suppliers ON products.supplier_number = suppliers.supplier_number");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"product_number: {reader["product_number"]}, product_name: {reader["product_name"]}, price: {reader["price"]} how many in stock: {reader["amount"]}");

                products e = new products
                {
                    product_number = (int)reader["product_number"],
                    product_name = (string)reader["product_name"],
                    supplier_number = (int)reader["supplier_number"],
                    price = (int)reader["price"],
                    amount = (int)reader["amount"],
                };
                list.Add(e);
            }

            cmd.Connection.Close();

            return results;

        }

        public void orderNewProduct(customer c)
        {
            productDAO dao = new productDAO();
            ordersDAO dao2 = new ordersDAO();

            int amountOfProducts;

            Console.WriteLine("======New order menu:======" +
                                 "\n enter product name:");
           string newProduct = Console.ReadLine();

            products selectedP = dao.GetProductbyName(newProduct);

            if (selectedP.amount > 0)
            {
                Console.WriteLine("How may of those do you want?");
                amountOfProducts = Convert.ToInt32(Console.ReadLine());

                if (amountOfProducts <= selectedP.amount && amountOfProducts > 0)
                {
                    dao.removeProduct(newProduct, amountOfProducts);
                    dao2.AddNewOrder(selectedP, c);
                    Console.WriteLine("order went well(:");
                }
                else
                {
                    Console.WriteLine($"we dont have {amountOfProducts} in stock");
                }
            }
            else
            {
                Console.WriteLine("dont have this product");
            }
        }

        public List<customer> customerslist()
        {
            List<customer> results = new List<customer>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM customers";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
            Console.WriteLine($" {reader["cust_id"]} {reader["user_name"]} {reader["password"]} {reader["first_name"]} {reader["surname"]} {reader["first_name"]}");
                customer e = new customer
                {
                    cust_id = (int)reader["cust_id"],
                    user_name = (string)reader["user_name"],
                    password = (int)reader["password"],
                    first_name = (string)reader["first_name"],
                    surname = (string)reader["surname"],
                    cradit_number = (int)reader["cradit_number"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();

            return results;
        }

        public void NewCustomer()
        {
            Console.WriteLine("please enter a user name");
            string user_name = Console.ReadLine();

            Console.WriteLine("please enter your password");
            int password = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("please enter your first name");
            string first_name = Console.ReadLine();

            Console.WriteLine("please enter your surname");
            string surname = Console.ReadLine();

            Console.WriteLine("please enter a credit card number (up to 9 digits)");
            int credit_number = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"insert into Customers(user_name, password, first_name, surname, cradit_number)" +
                $"values('{user_name}', {password}, '{first_name}', '{surname}', {credit_number})");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            cmd.Connection.Close();
        }

    }
}