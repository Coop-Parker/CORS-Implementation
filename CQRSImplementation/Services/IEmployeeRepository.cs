using CQRSImplementation.Models;

namespace CQRSImplementation.Services
{
    public interface IEmployeeRepository
    {
        // Query Operations
        public Task<List<Employee>> GetEmployeeListAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        
        // Command Operations
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int id);
    }
}
