using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CLASS
{
    public class TablesDataBase
    {
        public void CreateTable(BDConnectionStringDTO BD)
        {
            string str;
            string connectionString = @"Data Source=" + BD.Server + ";Initial Catalog=" + BD.DataBasename + ";User ID=" + BD.UserName + ";Password=" + BD.Password + "";
            SqlConnection myConn = new SqlConnection(connectionString);

            str = "CREATE TABLE Log_Values(" +
                  "[id][int] IDENTITY(1, 1) NOT NULL," +
                  "[MESSAGETEXT] [nvarchar](50) NULL," +
                  "[DATAMESSAGE] [nvarchar](50) NULL)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine("The Table is Created Successfully");
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
