using BLL;
using DAL.DTO;
using System.Collections.Generic;

namespace ConsoleApp.Entities
{
    internal class LoggerService
    {
        public void LogService(LoggerTypeDTO dto,
                               LogMessageDTO messageDTO,
                               LogConsoleTypeDTO logConsoleTypeDTO,
                               Dictionary<string, string> dbParamsMap,
                               BDConnectionStringDTO BD)
        {
            if (dto.logToFile)
            {
                LogFileBLL.SaveLogInFile(dbParamsMap,messageDTO.MessageText, logConsoleTypeDTO);
            }
            if (dto.logToConsole)
            {
                LogConsoleBLL.WriteLogConsole(logConsoleTypeDTO,messageDTO.MessageText);
            }
            if (dto.logToDatabase)
            {
                var dtoLog = new LogMessageDTO();
                dtoLog.MessageText = messageDTO.MessageText;
                LogDataBaseBLL.CreateLogValue(dtoLog, logConsoleTypeDTO,BD);
            }
        }
    }
}