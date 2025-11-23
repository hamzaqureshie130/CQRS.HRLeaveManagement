using HRLeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto
    {
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public int NumberOfDays { get; set; }
        public string EmployeeId { get; set; }
    }
}
