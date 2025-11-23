using FluentValidation;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Validators
{
    public class ChangeLeaveRequestApprovalDtoValidator : AbstractValidator<ChangeLeaveRequestApprovalDto>
    {
        public ChangeLeaveRequestApprovalDtoValidator()
        {
            RuleFor(p => p.Approved)
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
