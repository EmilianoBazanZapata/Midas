using DAL.DTO;
using System;

namespace DAL.DAO
{
    public class ConsoleLogDAO
    {
        public static void WriteLogConsole(LogConsoleTypeDTO dto,string l)
        {
            if (dto.Message)
            {
                l = l + "message " + DateTime.Now + " " + l;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(l);
                Console.ResetColor();
            }

            if (dto.Warning)
            {
                l = l + "warning " + DateTime.Now + " " + l;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(l);
                Console.ResetColor();
            }

            if (dto.Error)
            {
                l = l + "error " + DateTime.Now + " " + l;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(l);
                Console.ResetColor();
            }
        }
    }
}