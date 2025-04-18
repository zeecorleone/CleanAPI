

using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using MediatR;

namespace CleanAPI.Application.Commands;

public record UpdateEmployeeCommand(Guid id, Employee Employee) : IRequest<Employee>;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository _employRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employRepository)
    {
        _employRepository = employRepository;
    }

    public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _employRepository.UpdateEmployeeAsync(request.id, request.Employee);
    }

}
