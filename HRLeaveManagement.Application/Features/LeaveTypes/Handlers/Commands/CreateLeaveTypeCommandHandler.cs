using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Validators;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using MediatR;
using HRLeaveManagement.Application.Responses;


namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new CreateLeaveTypeValidatorDto();
                var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    return response;
                }

                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
                var result = await _leaveTypeRepository.Add(leaveType);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveType.Id;

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = new List<string> { ex.Message };
                return response;
            }
        }
    }
}
