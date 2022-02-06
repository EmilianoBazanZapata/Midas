using System;
using System.Collections;
using System.Collections.Generic;
using BLL;
using ConsoleApp.Entities;
using DAL.DTO;
namespace ConsoleApp
{
    class Program
    {
        #region
        static string messageTetx = "";
        static int OptionAvalible = 0;
        static int TypeAvalible = 0;
        static bool message = false;
        static bool error = false;
        static bool warning = false;
        static LogConsoleTypeDTO LogConsoleTypeDTO = new LogConsoleTypeDTO();
        static LoggerTypeDTO LoggerTypeDTO = new LoggerTypeDTO();
        static LogMessageDTO LogMessageDTO = new LogMessageDTO();
        #endregion
        static void Main(string[] args)
        {
            Dictionary<string, string> dbParamsMap = new Dictionary<string, string>();
            dbParamsMap.Add("logFileFolder", @"C:\Temp");

            // Ask the user to message
            Console.WriteLine("Please, Add a Message");
            messageTetx = Console.ReadLine();

            // Ask the user to what gets logged
            Console.WriteLine("Please... Select a option avalible : 1,2 or 3");
            Console.WriteLine("1: Add Message");
            Console.WriteLine("2: Add Warning ");
            Console.WriteLine("3: Add Error");
            #region
            try
            {
                OptionAvalible = Convert.ToInt32(Console.ReadLine());
                switch (OptionAvalible)
                {
                    case 1:
                        message = true;
                        error = false;
                        warning = false;
                        break;
                    case 2:
                        message = false;
                        error = true;
                        warning = false;
                        break;
                    case 3:
                        message = false;
                        error = false;
                        warning = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
            // Ask the user how to register.
            Console.WriteLine("Please... Select an option to record the available message: 1,2 or 3");
            Console.WriteLine("1: with .txt");
            Console.WriteLine("2: with Console ");
            Console.WriteLine("3: with  SQL Server");
            #region
            try
            {
                TypeAvalible = Convert.ToInt32(Console.ReadLine());
                switch (TypeAvalible)
                {
                    case 1:
                        LoggerTypeDTO.logToFile = true;
                        LoggerTypeDTO.logToConsole = false;
                        LoggerTypeDTO.logToDatabase = false;
                        break;
                    case 2:
                        LoggerTypeDTO.logToFile = false;
                        LoggerTypeDTO.logToConsole = true;
                        LoggerTypeDTO.logToDatabase = false;
                        break;
                    case 3:
                        LoggerTypeDTO.logToFile = false;
                        LoggerTypeDTO.logToConsole = false;
                        LoggerTypeDTO.logToDatabase = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            LoggerTypeDTO.logMessage = message;
            LoggerTypeDTO.logWarning = warning;
            LoggerTypeDTO.logError = error;
            LoggerTypeDTO.dbParams = dbParamsMap;
            LogMessageDTO.MessageText = messageTetx;
            LogConsoleTypeDTO.Message = message;
            LogConsoleTypeDTO.Error = error;
            LogConsoleTypeDTO.Warning = warning;

            LogMessageBLL.ParamsLogMessage(messageTetx, message, error, warning, LoggerTypeDTO);
            LoggerService lg = new LoggerService();
            lg.LogService(LoggerTypeDTO, LogMessageDTO, LogConsoleTypeDTO, dbParamsMap);
            Console.ReadKey();
        }
    }
}