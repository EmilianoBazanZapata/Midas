using DAL.DAO;
using DAL.DTO;
using System;

namespace BLL
{
    public class LogBLL
    {
        public static void CreateLogValue(LogDTO dto)
        {
           LogDAO.CreateLogValue(dto);  
        }
    }
}
