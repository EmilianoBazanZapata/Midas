using DAL.DAO;
using DAL.DTO;

namespace BLL
{
    public class LogDataBaseBLL
    {
        public static void CreateLogValue(LogMessageDTO dto, LogConsoleTypeDTO logConsoleTypeDTO,BDConnectionStringDTO BD)
        {
           SqlLogDAO.CreateLogValue(dto, logConsoleTypeDTO,BD);  
        }
    }
}