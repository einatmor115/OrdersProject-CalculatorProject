using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    class Program
    {
        static void Main(string[] args)
        {
           customerDAO dao = new customerDAO();
           suppliersDAO dao1 = new suppliersDAO();

            string supplier_userName = null;
            int supplier_password = 0;

            string customer_userName = null;
            int customer_password = 0;

            Console.WriteLine("Supplier or Customer?" +
                "\n====For customer enter 1 for supplier enter 2====");
        
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == 1)
            {
                Console.WriteLine("===========for new customer press 1==========\n" +
                    "============for existing customer press 2=========");
                int newOrOld = Convert.ToInt32(Console.ReadLine());

                if (newOrOld == 1)
                {
                    dao.NewCustomer();
                }
                else 
                {
                    Console.WriteLine("please enter a user name:");
                    customer_userName = Console.ReadLine();

                    Console.WriteLine("please enter your password:");
                    customer_password = Convert.ToInt32(Console.ReadLine());
                    exsitingCustomer(customer_userName, customer_password);
                }
            }
            else
            {
                Console.WriteLine("===========for new supplier press 1==========\n" +
                    "============for existing supplier press 2=========");
                int newOrOld = Convert.ToInt32(Console.ReadLine());

                if (newOrOld == 1)
                {
                    dao1.addNewSupplier();
                }
                else
                {
                    Console.WriteLine("please enter a user name:");
                    supplier_userName = Console.ReadLine();

                    Console.WriteLine("please enter your password:");
                    supplier_password = Convert.ToInt32(Console.ReadLine());

                    exsitingSupplier(supplier_userName, supplier_password);
                }
            }


            // test for suppliers view
            // supliers s = new supliers() ;
            //  List<object> supplierProductView = new List<object>();         
            // s.viewAllMyProducts(supplierProductView);


            // checkPasswordAndUserName(userName, password, suppliers, customers);
        }

        /*  public static void checkPasswordAndUserName(string userName,int password, List<suppliers> suppliers, List<customers>cust)
          {
              customerDAO dao1 = new customerDAO();
              if (dao1.checkForPassword(userName, cust) == true)
              {

              }
          }  */

        // this it the supplier class functions:

        static public customer exsitingCustomer(string userName, int password)
        {
            string newProduct = null;
            int amountOfProducts = 0 ;
            customer custLogIn = null;

            customerDAO dao2 = new customerDAO();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"select * from Customers where password = {password} and user_Name = '{userName}'");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                custLogIn = new customer
                {
                    cust_id = (int)reader["cust_id"],
                    user_name = (string)reader["user_name"],
                    password = (int)reader["password"],
                    first_name = (string)reader["first_name"],
                    surname = (string)reader["surname"],
                    cradit_number = (int)reader["cradit_number"],
                };

                Console.WriteLine("===================menu:============== " +
                "\n 1.To view all my shooping list press number 1" +
                "\n 2.To watch all products press number 2" +
                "\n 3. For new order press number 3");
               cmd.CommandText = ("");

                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == 1)
                {
                    dao2.viewAllMyShoopingList(custLogIn);
                }
                else if (answer == 2)
                {
                    dao2.watchAllProducts();
                }
                else if (answer == 3)
                {
                    dao2.orderNewProduct(custLogIn);
                }
            }
            cmd.Connection.Close();
            return custLogIn;


        }

        static public supplier exsitingSupplier(string userName, int password)
        {
            supplier supplierLogIn = null;

            suppliersDAO dao2 = new suppliersDAO();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=DBschool;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"select * from suppliers where password = {password} and user_Name = '{userName}'");

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            while (reader.Read() == true)
            {
                supplierLogIn = new supplier
                {
                    supplier_number = (int)reader["supplier_number"],
                    user_name = (string)reader["user_name"],
                    password = (int)reader["password"],
                    company_name = (string)reader["company_name"],
                };

                Console.WriteLine("===================menu:============== " +
                "\n 1.To Add new product to stock press 1" +
                "\n 2.To watch all products press number 2");
                cmd.CommandText = ("");

                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == 1)
                {
                    dao2.AddNewProduct(supplierLogIn);
                }
                else if (answer == 2)
                {
                    dao2.viewAllMyProducts(supplierLogIn);
                }
            }
            return supplierLogIn;
        }
    }
}
