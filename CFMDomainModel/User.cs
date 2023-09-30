using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFMDomainModel
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName ="NVARCHAR(50)")]
        public string UserMail { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(10)")]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public byte[] HashSalt { get; set; }
        public int NoOfFailedAttempts { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public byte[] Profile { get; set; }

        //[ForeignKey("UserFile")]
        //public int? UserFileID { get; set; }
        public ICollection<UserFile> UserFile { get; set; }
    }
}