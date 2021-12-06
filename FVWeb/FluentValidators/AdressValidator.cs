using FluentValidation;
using FVWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVWeb.FluentValidators
{
    public class AdressValidator:AbstractValidator<Adress>
    {
        private string NotEmptyMessage { get; } = "{PropertyName} alanı boş geçilemez";
        public AdressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMessage).MaximumLength(5).WithMessage("{PropertyName} alanı {MaxLength} karakter olmalıdır");
        }
    }
}
