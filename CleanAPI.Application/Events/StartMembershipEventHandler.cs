
using CleanAPI.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Application.Events;


/// <summary>
/// When Employee is created, this event is published.
/// </summary>
public class StartMembershipEventHandler : INotificationHandler<EmployeeCreatedEvent>
{
    private readonly ILogger<EmployeeCreatedEventHandler> _logger;
    private readonly IEmailService _emailService;

    public StartMembershipEventHandler(ILogger<EmployeeCreatedEventHandler> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }

    public async Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        await Task.Delay(2000);
        _logger.LogInformation($"Membeship enabled for employee: {notification.Employee.Id} - {notification.Employee.FirstName} {notification.Employee.LastName}");

    }
}
