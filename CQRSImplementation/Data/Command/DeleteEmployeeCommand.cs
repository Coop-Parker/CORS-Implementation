using CQRSImplementation.Models;
using MediatR;
namespace CQRSImplementation.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
