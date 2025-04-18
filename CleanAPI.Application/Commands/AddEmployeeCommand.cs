
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using MediatR;

namespace CleanAPI.Application.Commands;

public record AddEmployeeCommand(Employee employee) : IRequest<Employee>;


public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;
    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.AddEmployeeAsync(request.employee);
    }

}