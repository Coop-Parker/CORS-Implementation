using CQRSImplementation.Data;
using CQRSImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSImplementation.Services
{
    public class EmployeeRepository : IEmployeeRepository  
    {
        private readonly DataContext _dbContext;

        public EmployeeRepository(DataContext dbContext)
        {
            
            this._dbContext = dbContext;
            Employee employee = new Employee();
            
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        
        
        {
            var result = _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            Console.WriteLine(employee);
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var filteredData = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            _dbContext.Employees.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var filteredData = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return filteredData;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            var filteredData = await _dbContext.Employees.ToListAsync();
            return filteredData;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
