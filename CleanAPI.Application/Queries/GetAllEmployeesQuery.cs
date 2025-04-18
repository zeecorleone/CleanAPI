
using CleanAPI.Core.Entities;
using CleanAPI.Core.Interfaces;
using MediatR;

namespace CleanAPI.Application.Queries;

public record GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>;


public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;
    public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository = null)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployees();
    }

}
