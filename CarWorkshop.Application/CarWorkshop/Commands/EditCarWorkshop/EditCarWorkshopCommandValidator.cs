using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description should not have been empty");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8).WithMessage("Phone number should have minimum 8 characters")
                .MaximumLength(13).WithMessage("Phone number should have maximum 13 characters");
        }
    }
}
