using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommandRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if (leaveType == null)
            {
                return false;
            }
            await _leaveTypeRepository.Delete(leaveType);

            return true;

        }
    }
}
