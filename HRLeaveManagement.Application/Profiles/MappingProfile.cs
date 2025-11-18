using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          CreateMap<Domain.LeaveType, DTOs.LeaveTypeDto>().ReverseMap();
          CreateMap<Domain.LeaveAllocation, DTOs.LeaveAllocationDto>().ReverseMap();
          CreateMap<Domain.LeaveRequest, LeaveRequestDto>().ReverseMap();
          CreateMap<Domain.LeaveRequest, LeaveRequestListDto>().ReverseMap();
        }
    }
}
