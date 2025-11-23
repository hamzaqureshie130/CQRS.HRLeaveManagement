using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var getLeaveType =  await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
            if (getLeaveType == null)
            {
                return default;
            }
            var leaveType = _mapper.Map(request.LeaveTypeDto, getLeaveType);
            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;


        }
    }
}
