using DAL.DAO;
using DAL.DTO;
using System;

namespace BLL
{
    public class LogDataBaseBLL
    {
        public static void CreateLogValue(LogMessageDTO dto, LogConsoleTypeDTO logConsoleTypeDTO)
        {
           SqlLogDAO.CreateLogValue(dto, logConsoleTypeDTO);  
        }
    }
}
