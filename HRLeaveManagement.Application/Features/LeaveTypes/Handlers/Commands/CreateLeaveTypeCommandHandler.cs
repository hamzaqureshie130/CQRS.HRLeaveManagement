using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Validators;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using MediatR;


namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var validator = new CreateLeaveTypeValidatorDto();
                var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult);
                }
                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
                var response = await _leaveTypeRepository.Add(leaveType);
                return response.Id;

            }

            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
