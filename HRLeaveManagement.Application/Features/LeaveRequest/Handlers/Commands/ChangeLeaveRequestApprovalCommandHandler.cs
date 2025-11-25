using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveRequest.Validators;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public ChangeLeaveRequestApprovalCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangeLeaveRequestApprovalDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ChangeLeaveRequestApprovalDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var leaveRequest = await _leaveRequestRepository.Get(request.ChangeLeaveRequestApprovalDto.Id);

            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.ChangeLeaveRequestApprovalDto.Id);
            }

            leaveRequest.Approved = request.ChangeLeaveRequestApprovalDto.Approved;

            await _leaveRequestRepository.Update(leaveRequest);

            //await _leaveRequestRepository.ChangeApproval(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);

            return Unit.Value;
        }
    }
}
