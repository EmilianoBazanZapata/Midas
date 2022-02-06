using DAL.CLASS;
using DAL.DTO;
using System;

namespace DAL.DAO
{
    public class ConsoleLogDAO
    {
        private static string message = "";
        public static void WriteLogConsole(LogConsoleTypeDTO dto, string l)
        {
            message = Message.MessageLog(l, dto);

            if (dto.Message)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            if (dto.Warning)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            if (dto.Error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}