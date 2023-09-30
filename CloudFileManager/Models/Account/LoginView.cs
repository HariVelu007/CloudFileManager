using System.ComponentModel.DataAnnotations;

namespace CloudFileManager.Models.Account
{
    public class LoginView
    {
        [Required(ErrorMessage ="Please enter userid")]
        [StringLength(50,ErrorMessage ="Userid must not exceed 50 character")]
        [EmailAddress(ErrorMessage ="Invalid email")]
        [Display(Name ="User mail")]
        
        public string UserMail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(50, ErrorMessage = "Password must not exceed 50 character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;
    }
}
