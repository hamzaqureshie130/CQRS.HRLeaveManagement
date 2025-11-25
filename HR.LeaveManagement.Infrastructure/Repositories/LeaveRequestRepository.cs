using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Infrastructure.Repositories;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ChangeApproval(LeaveRequest leaveRequest, bool approved)
        {
            var leaveReq = await _dbContext.LeaveRequests.FirstOrDefaultAsync(q => q.Id == leaveRequest.Id);
           
            if (leaveReq != null)
            {
                leaveReq.Approved = approved;
                leaveReq.DateActioned = DateTime.Now;
               
            }
            return true;

        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
               .Include(q => q.LeaveType)
               .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest;
        }
    }
}
