

using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using MediatR;

namespace CleanAPI.Application.Queries;

public record GetEmployeeByIdQuery(Guid id) : IRequest<Employee>;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeById(request.id);
    }
}
