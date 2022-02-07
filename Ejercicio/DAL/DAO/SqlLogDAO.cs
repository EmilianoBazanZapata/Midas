using DAL.CLASS;
using DAL.DATABASE;
using DAL.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class SqlLogDAO
    {
        public static void CreateLogValue(LogMessageDTO dto, 
                                          LogConsoleTypeDTO logConsoleTypeDTO,
                                          BDConnectionStringDTO BD)
        {
            string connectionString = @"Data Source="+BD.Server+";Initial Catalog="+BD.DataBasename+";User ID="+BD.UserName+";Password="+BD.Password+"";
            int t = 0;
            if (logConsoleTypeDTO.Message)
            {
                t = 1;
            }

            if (logConsoleTypeDTO.Error)
            {
                t = 2;
            }

            if (logConsoleTypeDTO.Warning)
            {
                t = 3;
            }
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string Consulta = @"EXEC UP_AGREGAR_LOG @MESSAGETEXT , @DATAMESSAGE";
                //CREO UNA INSTANCIA NUEVA DE UN DATATABLE
                DataTable tb = new DataTable();
                //creo una variable reader para capturar los datos
                SqlDataReader MyReader;
                using (SqlCommand myCommand = new SqlCommand(Consulta, sqlConnection))
                {
                    myCommand.Parameters.AddWithValue("@MESSAGETEXT", dto.MessageText);
                    myCommand.Parameters.AddWithValue("@DATAMESSAGE", t.ToString());
                    MyReader = myCommand.ExecuteReader();
                    //cierro las conexiones
                    MyReader.Close();
                    sqlConnection.Close();
                }
                Console.WriteLine("Message Registered In Database Successfully");
            }
            catch (Exception ex)
            {  
                Console.WriteLine("The Database does not exist, then it will be xcreated so you can try again");
                try
                {
                    DataBaseContent db = new DataBaseContent();
                    StoredProcedures up = new StoredProcedures();
                    TablesDataBase tbl = new TablesDataBase();
                    db.CreateDataBase(BD);
                    tbl.CreateTable(BD);
                    up.CreateStoreProcedure(BD);

                }
                catch (Exception ex1)
                {
                    Console.WriteLine("Database was successfully created");
                    Console.WriteLine(ex1.ToString());
                }
            }
        }
    }
}