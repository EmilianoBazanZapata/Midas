using DAL.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DATABASE
{
    public class DataBaseContent
    {
        public void CreateDataBase(BDConnectionStringDTO BD)
        {
            string str;
            string connectionString = @"Data Source=" + BD.Server + ";Integrated security=SSPI;Initial Catalog= master;";
            SqlConnection myConn = new SqlConnection(connectionString);

            str = "CREATE DATABASE " +BD.DataBasename+"";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine("DataBase is Created Successfully");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}