using DAL.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class SqlLogDAO
    {
        public static void CreateLogValue(LogMessageDTO dto, LogConsoleTypeDTO logConsoleTypeDTO)
        {
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
                string connectionString = @"Data Source=DESKTOP-5KJPFCB\SQLEXPRESS;Initial Catalog=Midas;Integrated Security=True";
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

                Console.WriteLine(ex.ToString()); ;
            }
        }
    }
}