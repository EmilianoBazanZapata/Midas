using DAL.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DAO
{
    public class LogDAO
    {
        public static void CreateLogValue(LogDTO dto)
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
                myCommand.Parameters.AddWithValue("@DATAMESSAGE", dto.DataMessage);
                MyReader = myCommand.ExecuteReader();
                //cierro las conexiones
                MyReader.Close();
                sqlConnection.Close();
            }
        }
    }
}