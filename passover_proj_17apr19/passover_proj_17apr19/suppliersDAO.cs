using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    class suppliersDAO
    {
        public List<supplier> supplierList()
        {
            List<supplier> results = new List<supplier>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM suppliers";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
             Console.WriteLine($" {reader["supplier_number"]} {reader["user_name"]} {reader["password"]} {reader["company_name"]}");


                supplier e = new supplier
                {
                    supplier_number = (int) reader["supplier_number"],
                    user_name = (string)reader["user_name"],
                    password =(int) reader["password"],
                    company_name =(string) reader["company_name"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();

            return results;
        }

        public void addNewSupplier()
        {
                Console.WriteLine("please enter a user name");
                string user_name = Console.ReadLine();

                Console.WriteLine("please enter your password");
                int password = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("please enter your company name");
                string company_name = Console.ReadLine();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"insert into suppliers(user_name, password, company_name)" +
                $"values('{user_name}', {password}, '{company_name}')");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            cmd.Connection.Close();
        }
       
        public List<products> viewAllMyProducts(supplier s)
        {
            List<products> results = new List<products>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@supId", s.supplier_number));
            cmd.CommandText = "SELECT * FROM products INNER JOIN suppliers ON products.supplier_number = suppliers.supplier_number where suppliers.supplier_number = @supId";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                Console.WriteLine($" product_number: {reader["product_number"]} product_name: {reader["product_name"]} price: {reader["price"]} amount: {reader["amount"]}");
                products e = new products
                {
                    product_number = (int)reader["product_number"],
                    product_name = (string)reader["product_name"],
                    supplier_number = (int)reader["supplier_number"],
                    price = (int)reader["price"],
                    amount = (int)reader["amount"]
                };
                results.Add(e);
            }

            cmd.Connection.Close();

            return results;
        }

        public void AddNewProduct(supplier s)
        {
            products e = new products();
            productDAO dao = new productDAO();

            Console.WriteLine("enter the name of the product you want to Add");
            string product = Console.ReadLine();
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@product", product));
            cmd.CommandText = $"SELECT * FROM products where product_name = '{product}'";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            if (reader.Read() == true)
            {              
                {
                    e.product_number = (int)reader["product_number"];
                    e.product_name = (string)reader["product_name"];
                    e.supplier_number = (int)reader["supplier_number"];
                    e.price = (int)reader["price"];
                    e.amount = (int)reader["amount"];
                };

                if (e.supplier_number == s.supplier_number)
                {
                    Console.WriteLine("How many product do you want to Add to stock?");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    dao.addExistingPoduct(product, amount);
                }
                else
                {
                    Console.WriteLine("product exist at another supplier stock");
                }
            }
            else
            {
                dao.AddNewProduct(product, s);
            }

            cmd.Connection.Close();
        }

    }
}


