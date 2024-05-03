using CQRSImplementation.Models;
using MediatR;


namespace CQRSImplementation.Data
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
