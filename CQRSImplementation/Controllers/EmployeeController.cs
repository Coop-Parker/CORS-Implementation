using CQRSImplementation.Data;
using CQRSImplementation.Data.Command;
using CQRSImplementation.Models;
using CQRSImplementation.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator )
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());
            return employeeList;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<Employee> GetEmployeeById([FromRoute] int id )
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            return employee;
        }

        [HttpPost]
        public async Task<Employee> CreateEmployee([FromBody]Employee employee)
        {
            var employeePost = await _mediator.Send(new CreateEmployeeCommand(employee.Name,employee.Address,employee.Email,employee.Phone));
            return employeePost;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<int> UpdateEmployeeById([FromRoute]int id, [FromBody] Employee employee)
        {
            var updateEmployee = await _mediator.Send(new UpdateEmployeeCommand(id,employee.Name,employee.Address,employee.Email,employee.Phone));
            return updateEmployee;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<int> Delete([FromRoute] int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand() { Id=id});
        }

    }
}
