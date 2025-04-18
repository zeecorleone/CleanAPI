using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace CleanAPI.Infrastructure.Repositories;

public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await context.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(Guid id)
    {
        return await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        employee.Id = Guid.NewGuid();
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateEmployeeAsync(Guid employeeId, Employee entity)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(entity => entity.Id == employeeId);
        if(employee is not null)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.Phone = entity.Phone;
            //context.Employees.Update(employee);
            await context.SaveChangesAsync();

            return employee;
        }
        return entity;

    }

    public async Task<bool> DeleteEmployeeAsync(Guid employeeId)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(entity => entity.Id == employeeId);
        if (employee is not null)
        {
            context.Employees.Remove(employee);
            return await context.SaveChangesAsync() > 0;

        }
        return false;
    }
}
