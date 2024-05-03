using CQRSImplementation.Data.Command;
using CQRSImplementation.Models;
using CQRSImplementation.Services;
using MediatR;
using System.Diagnostics.Contracts;

namespace CQRSImplementation.Data.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int  >// vedio 19:41
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }


        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
