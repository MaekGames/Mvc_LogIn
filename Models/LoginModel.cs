using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppTask.Models
{
    public class LoginModel
    {
        [Required, Key]
        [RegularExpression(@"^\b[\dA-Za-z]+\b$", ErrorMessage = "Please use only letters and digits without any spaces")]
        [Display(Name = "User Login")]
        public string? Username { get; set; }


        [Required, RegularExpression(@"^[^\s]+$", ErrorMessage = "Please do not use spaces"),]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Date Modified")]
        public DateTime ModifyDate { get; set; }
    }
}
