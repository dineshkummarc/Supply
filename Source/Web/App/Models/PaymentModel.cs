using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;

namespace MvcMovie.Models
{


    public class PaymentModel
    {
        public string Number { get; set; }

        public string NameOnCard { get; set; }
        public string Ccv { get; set; }
        public string Issuer { get; set; } // ex Visa, Mastercard, American Express
        public string ExpirationDate { get; set; }
    }

    [Validator(typeof(PersonalModelValidator))]
    public class PersonalModel 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; } 
    }
    public class PersonalModelValidator : AbstractValidator<PersonalModel>
    {
        public PersonalModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotEqual("Name");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Required").EmailAddress().WithMessage("Please enter a valid email address (ex. joe@test.com)");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary Required").GreaterThan(0) ; ; 
        }
    }
     
    //public class BaseClass
    //{
    //    public IList<string> Errors = new List<string>();
    //    public bool IsValid()
    //    {
    //        Errors.Clear();
    //        Validate(this);
    //        return Errors.Count == 0;
    //    }

    //    public virtual void Validate(dynamic item) { } 

    //    //validation methods
    //    public virtual bool ValidatesPresenceOf(object value, string message = "Required")
    //    {
    //        if (value == null)
    //            Errors.Add(message);
    //        if (String.IsNullOrEmpty(value.ToString()))
    //        {
    //            Errors.Add(message);
    //            return false;
    //        }
    //        return true;
    //    } 
    //}

     
}