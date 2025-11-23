using FluentValidation;
using HRLeaveManagement.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Validators
{
    public class CreateLeaveTypeValidatorDto : AbstractValidator<LeaveTypeDto>
    {
        public CreateLeaveTypeValidatorDto()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
            RuleFor(x => x.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");
        }
    }
}
