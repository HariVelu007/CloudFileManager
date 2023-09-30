using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Model
{
    public class UserFileView
    {
        public int ID { get; set; }
        public string UserMail { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public decimal FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
