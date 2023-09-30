using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CloudFileManager.Models.Account
{
    public class RegisterView
    {
        [Required(ErrorMessage ="Please enter user mail")]
        [StringLength(50)]
        [Display(Name = "User mail")]
        [EmailAddress(ErrorMessage ="Invalid mail id")]
        public string UserMail { get; set; }
        
        [Required(ErrorMessage = "Please enter user name")]
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Please choose gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        
        [Required(ErrorMessage = "Please choose birth date")]
        [Display(Name ="Date of birth")]
        [Range(typeof(DateTime),"01-01-1910","31-12-2099")]
        [DisplayFormat(DataFormatString ="dd-MM-yyyy", ApplyFormatInEditMode=true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password",ErrorMessage ="Password and confirm password field didn't match")]
        [StringLength(50)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }       
        //public IFormFile Profile { get; set; }
    }
}
