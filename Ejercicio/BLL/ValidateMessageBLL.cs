using DAL.DTO;
using System;
using System.IO;
namespace BLL
{
    public class ValidateMessageBLL
    {
        public static void ParamsLogMessage(string messageText, bool message, bool error, bool warning, LoggerTypeDTO dto)
        {
            messageText.Trim();
            if (messageText == null || messageText.Length == 0)
            {
                throw new Exception("Fill Messagge");
            }
            if (!dto.logToConsole && !dto.logToFile && !dto.logToDatabase)
            {
                throw new Exception("Invalid configuration");
            }
            if ((!dto.logError && !dto.logMessage && !dto.logWarning) || (!message && !warning && !error))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }
        }
    }
}
