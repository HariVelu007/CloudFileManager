using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFMDomainModel
{
    public class UserFileAccess
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public bool Status { get; set; }//0- pending, 1 - accepted

        [ForeignKey("UserFile")] 
        public int UserFileID { get; set; }
        
        public UserFile UserFile { get; set; }

    }
}
