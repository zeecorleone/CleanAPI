using CleanAPI.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAPI.Application.Commands;

public record DeleteEmployeeCommand(Guid id) : IRequest<bool>;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        return _employeeRepository.DeleteEmployeeAsync(request.id);
    }
}
