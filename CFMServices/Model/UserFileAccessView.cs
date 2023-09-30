using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Model
{
    public class UserFileAccessView
    {
        public int ID { get; set; }
        public int UserFileID { get; set; }
        public int UserID { get; set; }
        public string UsermailID { get; set; }
    }
}
