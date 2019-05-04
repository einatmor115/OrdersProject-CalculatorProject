using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            calculator calc = new calculator();
            int x=1;
            int y=1;

            do 
            {
                Console.WriteLine("enter x:");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter y");
                y = Convert.ToInt32(Console.ReadLine());

                if (x > 0 && y > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=passover_project;Integrated Security=True");
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@x", x));
                    cmd.CommandText = ("insert into Table_x values (@x)");
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    cmd.Connection.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=passover_project;Integrated Security=True");
                    cmd1.Connection.Open();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.Add(new SqlParameter("@y", y));
                    cmd1.CommandText = ("insert into Table_y values (@y)");
                    SqlDataReader reader1 = cmd1.ExecuteReader(CommandBehavior.Default);
                    cmd1.Connection.Close();

                    calc.InsertValuseIntoReasultTable(x, y);
                    calc.InsertReasultsColumn(x, y);
                }
            }
            while (x > 0 && y > 0);
            Console.WriteLine("not valid!");
        }      
    }
}
