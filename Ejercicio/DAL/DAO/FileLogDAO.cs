using System.IO;
using System.Collections.Generic;
using DAL.DTO;
using DAL.CLASS;
using System;

namespace DAL.DAO
{
    public class FileLogDAO
    {
        public static string message = "";
        public static void SaveLogInFile(Dictionary<string, string> dbParams,
                                         string l,
                                         LogConsoleTypeDTO dto)
        {
            try
            {
                message = Message.MessageLog(l, dto);

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
                Console.WriteLine("Message Logged Into .txt File Successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("the folder is not created in the directory, it will be created next, so please try again");
                try
                {
                    string folderPath = dbParams["logFileFolder"];
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}