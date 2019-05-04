using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_project_1
{
    class calculator
    {
        public void InsertValuseIntoReasultTable(int x, int y)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=passover_project;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"insert into results (x, y, operations) select {x}, {y}, ooperations.operations " +
                "from ooperations ");

            SqlDataReader reader1 = cmd.ExecuteReader(CommandBehavior.Default);

            cmd.Connection.Close();
        }

        public void InsertReasultsColumn(int x, int y)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=passover_project;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ($"update results set results = {x}+{y} where operations ='+'");
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
            cmd.Connection.Close();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=passover_project;Integrated Security=True");
            cmd1.Connection.Open();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = ($"update results set results = {x}-{y} where operations ='-'");
            SqlDataReader reader1 = cmd1.ExecuteReader(CommandBehavior.Default);
            cmd1.Connection.Close();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=passover_project;Integrated Security=True");
            cmd2.Connection.Open();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = ($"update results set results = {x}*{y} where operations ='*'");
            SqlDataReader reader2 = cmd2.ExecuteReader(CommandBehavior.Default);
            cmd2.Connection.Close();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=passover_project;Integrated Security=True");
            cmd3.Connection.Open();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = ($"update results set results = {x}/{y} where operations ='/'");
            SqlDataReader reader3 = cmd3.ExecuteReader(CommandBehavior.Default);
            cmd3.Connection.Close();
        }
    }
}
