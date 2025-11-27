using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.leaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest()
            {
               Id = id
            });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new CreateLeaveTypeCommand()
            {
                LeaveTypeDto = leaveTypeDto
            };
           var response = await _mediator.Send(command);
            return Ok(response);

        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new UpdateLeaveTypeCommandRequest()
            {
                LeaveTypeDto = leaveTypeDto
            };
           
            var response =  await _mediator.Send(command);
            
            return Ok(response);
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommandRequest()
            {
                Id = id
            };
            var response = await _mediator.Send(command);
            return Ok(response);

        }
    }
}
