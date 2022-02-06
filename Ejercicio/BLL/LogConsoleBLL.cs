using DAL.DTO;
using DAL.DAO;

namespace BLL
{
    public class LogConsoleBLL
    {
        public static void WriteLogConsole(LogConsoleTypeDTO dto,string l)
        {
            ConsoleLogDAO.WriteLogConsole(dto,l);
        }
    }
}