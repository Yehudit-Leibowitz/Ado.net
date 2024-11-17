using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net
{
    public class DataAccess
    {
        public int AddCategory (string connectionString)
        {
            string CategoryName;
            Console.WriteLine("insert category name");
            CategoryName = Console.ReadLine();

        
            string query = "INSERT INTO Category (CategoryName)" + "VALUES(@CategoryName)";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            using (SqlCommand cmd =new SqlCommand(query, connection)) 


            {
                cmd.Parameters.Add("@CategoryName", System.Data.SqlDbType.VarChar, 10).Value = CategoryName;
                connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                connection.Close();
                return rowAffected;


            }
        
        }


        public int AddProduct(string connectionString)
        {
            string Catedory_Id, ProductName, ProductDescription, Price, PictuerPath;
  
      
            Console.WriteLine("insert Catedory_Id name");
            Catedory_Id = Console.ReadLine();
            Console.WriteLine("insert ProductName name");
            ProductName = Console.ReadLine();
            Console.WriteLine("insert ProductDescription name");
            ProductDescription = Console.ReadLine();
            Console.WriteLine("insert Price ");

            Price = Console.ReadLine();
            Console.WriteLine("insert Picture path");
            PictuerPath = Console.ReadLine();

            string query = "INSERT INTO Product (Catedory_Id, ProductName, ProductDescription, Price, PictuerPath)" + "VALUES(@Catedory_Id, @ProductName, @ProductDescription, @Price, @PictuerPath)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))


            {
                cmd.Parameters.Add("@Catedory_Id", System.Data.SqlDbType.Int).Value = Catedory_Id;
                cmd.Parameters.Add("@ProductName", System.Data.SqlDbType.VarChar, 20).Value = ProductName;
                cmd.Parameters.Add("@ProductDescription", System.Data.SqlDbType.VarChar, 100).Value = ProductDescription;
                cmd.Parameters.Add("@Price", System.Data.SqlDbType.Int).Value = Price;
                cmd.Parameters.Add("@PictuerPath", System.Data.SqlDbType.VarChar, 10).Value = PictuerPath;
                connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                connection.Close();
                return rowAffected;


            }

        }



        public void getAllProduct(string connectionString)
        {
            

            string query = "select * from Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                using (SqlCommand cmd = new SqlCommand(query, connection))

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        }
                        reader.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                Console.ReadLine();


            }

        }

        public void getAllCategory(string connectionString)
        {


            string query = "select * from Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                Console.ReadLine();


            }

        }


    }
}
