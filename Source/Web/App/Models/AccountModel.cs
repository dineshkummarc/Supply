using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;

namespace Web.Models
{

    [Validator(typeof(ForgotPasswordModelValidator))]
    public class ForgotPasswordModel
    {  
        public string Email { get; set; } 
    }
    public class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPasswordModelValidator()
        { 
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email must be provided");
        }
    }
    
    [Validator(typeof(LogOnModelValidator))]
    public class LogOnModel
    {  
        public string UserName { get; set; } 
        public string Password { get; set; } 
        public bool RememberMe { get; set; }
    } 
    public class LogOnModelValidator : AbstractValidator<LogOnModel>
    {
        public LogOnModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty() ;
            RuleFor(x => x.Password).NotEmpty();
        }
    }
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }


    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
