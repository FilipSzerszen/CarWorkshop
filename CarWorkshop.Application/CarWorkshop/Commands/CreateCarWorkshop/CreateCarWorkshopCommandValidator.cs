using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop");
                    }
                })
                .NotEmpty()
                .MinimumLength(3).WithMessage("Name should have minimum 3 characters")
                .MaximumLength(30).WithMessage("Name should have maximum 30 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description should not have been empty");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8).WithMessage("Phone number should have minimum 8 characters")
                .MaximumLength(13).WithMessage("Phone number should have maximum 13 characters");
        }
    }
}
