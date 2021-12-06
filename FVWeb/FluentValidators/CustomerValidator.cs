using FluentValidation;
using FVWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVWeb.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        private string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Yaş aralığı 18 ve 60 arasında olmalıdır");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x=> {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaş aralığınız 18 ve 60 arasında olmalıdır");
            RuleForEach(x => x.Adresses).SetValidator(new AdressValidator());
            //Adress propertyi git adres validatorunu ver dedik
        }
    }
}
