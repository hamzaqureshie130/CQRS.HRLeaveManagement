using FluentValidation;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before End Date.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("{PropertyName} must be after Start Date.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await _leaveRequestRepository.Exist(id);
                    return !leaveTypeExist;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}