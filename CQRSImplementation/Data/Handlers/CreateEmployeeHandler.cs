using CQRSImplementation.Data.Command;
using CQRSImplementation.Models;
using CQRSImplementation.Services;
using MediatR;

namespace CQRSImplementation.Data.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee emp = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone,
            };
            return await _employeeRepository.AddEmployeeAsync(emp);
        }
    }
}
