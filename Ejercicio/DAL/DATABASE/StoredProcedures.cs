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
    public class StoredProcedures
    {
        public void CreateStoreProcedure(BDConnectionStringDTO BD)
        {
            string str;
            string connectionString = @"Data Source=" + BD.Server + ";Initial Catalog=" + BD.DataBasename + ";User ID=" + BD.UserName + ";Password=" + BD.Password + "";
            SqlConnection myConn = new SqlConnection(connectionString);

            str = " CREATE PROCEDURE [dbo].[UP_AGREGAR_LOG] " +
                 " @MESSAGETEXT NVARCHAR(50), " +
                 " @DATAMESSAGE NVARCHAR(50) " +
                 " AS " +
                 " DECLARE @FECHA_DE_ULTIMA_ODIFICACION DATETIME " +
                 " SET @FECHA_DE_ULTIMA_ODIFICACION = GETDATE() " +
                 " BEGIN " +
                 " BEGIN TRY " +
                 " BEGIN TRANSACTION " +
                 " INSERT INTO [dbo].[Log_Values] " +
                 " VALUES " +
                 " (@MESSAGETEXT " +
                 " ,@DATAMESSAGE) " +
                 " COMMIT TRANSACTION " +
                 " END TRY	" +
                 " BEGIN CATCH" +
                 " ROLLBACK TRANSACTION " +
                 " DECLARE @ErrorMessage NVARCHAR(4000);  " +
                 " DECLARE @ErrorSeverity INT;  " +
                 " DECLARE @ErrorState INT;  " +
                 " SELECT   " +
                 " @ErrorMessage = ERROR_MESSAGE(),  " +
                 " @ErrorSeverity = ERROR_SEVERITY(),  " +
                 " @ErrorState = ERROR_STATE();  " +
                 " RAISERROR (@ErrorMessage, " +
                 " @ErrorSeverity,  " +
                 " @ErrorState   " +
                 " );  " +
                 " END CATCH " +
                 " END" +
                 "";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine("Store Procedure is Created Successfully");
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
