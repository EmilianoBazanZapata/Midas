using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class BDConnectionStringDTO
    {
        public string Server { get; set; }
        public string DataBasename { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
