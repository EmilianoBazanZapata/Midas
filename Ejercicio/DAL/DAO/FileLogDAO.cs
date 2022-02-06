using System.IO;
using System.Collections.Generic;
using DAL.DTO;
using System;

namespace DAL.DAO
{
    public class FileLogDAO
    {
        public static string message { get; set; }
        public static void SaveLogInFile(Dictionary<string, string> dbParams, 
                                         string l,
                                         LogConsoleTypeDTO dto)
        {
            if (dto.Error)
            {
                message = message + "error " + DateTime.Now + " " + l;
            }

            if (dto.Warning)
            {
                message = message + "warning " + DateTime.Now + " " + l;
            }

            if (dto.Message)
            {
                message = message + "message " + DateTime.Now + " " + l;
            }
            bool exists = File.Exists(dbParams["logFileFolder"] + "/logFile.txt");
            StreamWriter file = null;
            if (!exists)
            {
                file = File.CreateText(dbParams["logFileFolder"] + "/logFile.txt");
            }
            if (file == null)
            {
                file = File.CreateText(dbParams["logFileFolder"] + "/logFile.txt");
            }
            file.WriteLine(message);
            file.Close();
        }
    }
}