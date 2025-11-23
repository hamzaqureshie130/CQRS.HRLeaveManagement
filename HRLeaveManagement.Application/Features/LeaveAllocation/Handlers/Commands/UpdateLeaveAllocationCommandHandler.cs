using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationReopository _leaveAllocationRepository;

        public UpdateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationReopository leaveAllocationReopository)
        {
            _leaveAllocationRepository = leaveAllocationReopository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
           
            if (leaveAllocation == null)
            {
                throw new Exception($"Leave Allocation with Id {request.LeaveAllocationDto.Id} not found.");
            }

            var mappedLeaveAllocation = _mapper.Map(request.LeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(mappedLeaveAllocation);
            return Unit.Value;

        }
    }
}
