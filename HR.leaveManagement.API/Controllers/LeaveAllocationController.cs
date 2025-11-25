using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveAllocation.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.leaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
           var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest()
           {
               Id = id
           });
              return Ok(leaveAllocation);

        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocationDto)
        {
            var command = new CreateLeaveAllocationCommand()
            {
                LeaveAllocationDto = leaveAllocationDto
            };
         var response = await _mediator.Send(command);
         return Ok(response);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put( [FromBody] UpdateLeaveAllocationDto leaveAllocationDto)
        {
            var command = new UpdateLeaveAllocationCommandRequest()
            {
                LeaveAllocationDto = leaveAllocationDto
            };
            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand()
            {
                Id = id
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
