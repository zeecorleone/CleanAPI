using CleanAPI.Application.Commands;
using CleanAPI.Application.Queries;
using CleanAPI.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] Employee employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await sender.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEmployeeByIdAsnyc(Guid id)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(id));
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeAsync(Guid id, [FromBody] Employee employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(id, employee));
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid id)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(id));
            if (result is false)
                return NotFound();
            return Ok(result);
        }
    }
}
