using AutoMapper;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Display mapping
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();

            // Create mapping
            CreateMap<LeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
        }
    }
}
