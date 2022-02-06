using DAL.DAO;
using DAL.DTO;
using System.Collections.Generic;
namespace BLL
{
    public class LogFileBLL
    {
        public static void SaveLogInFile(Dictionary<string, string> dbParamsMap,
                                         string l,
                                         LogConsoleTypeDTO dto)
        {
            FileLogDAO.SaveLogInFile(dbParamsMap,l,dto);
        }
    }
}
