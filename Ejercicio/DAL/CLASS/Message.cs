using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CLASS
{
    internal class Message
    {
        public static string message = "";
        internal static string MessageLog(string l, DTO.LogConsoleTypeDTO dto)
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
            return message;
        }
    }
}