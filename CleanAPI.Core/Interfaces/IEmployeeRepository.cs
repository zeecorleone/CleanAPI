

using CleanAPI.Core.Entities;

namespace CleanAPI.Core.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee> GetEmployeeById(Guid id);
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Guid employeeId, Employee entity);
    Task<bool> DeleteEmployeeAsync(Guid employeeId);
}
