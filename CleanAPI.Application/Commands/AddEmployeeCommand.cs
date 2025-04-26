
using CleanAPI.Application.Events;
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using MediatR;

namespace CleanAPI.Application.Commands;

public record AddEmployeeCommand(Employee employee) : IRequest<Employee>;


public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPublisher _publisher;
    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IPublisher publisher)
    {
        _employeeRepository = employeeRepository;
        _publisher = publisher;
    }

    public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.AddEmployeeAsync(request.employee);
        await _publisher.Publish(new EmployeeCreatedEvent(employee));
        return employee;
    }

}