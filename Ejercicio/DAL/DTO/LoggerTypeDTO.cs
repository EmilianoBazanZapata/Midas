using System.Collections;

namespace DAL.DTO
{
    public class LoggerTypeDTO
    {
        public  bool logToFile { get; set; }
        public  bool logToConsole { get; set; }
        public  bool logMessage { get; set; }
        public  bool logWarning { get; set; }
        public  bool logError { get; set; }
        public  bool logToDatabase { get; set; }
        public  IDictionary dbParams { get; set; }
    }
}
