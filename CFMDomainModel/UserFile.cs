using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFMDomainModel
{
    public class UserFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string FileExtension { get; set; }
        public decimal FileSize { get; set; }
        public int Visibility { get; set; } = 0; //0 : public, 1: provate 2:Specific people
        public DateTime CreatedDate { get; set; } 

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }        
        public ICollection<UserFileAccess> UserFileAccesses { get; set; }
    }
}
