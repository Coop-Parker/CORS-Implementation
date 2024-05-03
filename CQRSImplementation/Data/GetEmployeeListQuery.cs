using CQRSImplementation.Models;
using MediatR;

namespace CQRSImplementation.Data
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
