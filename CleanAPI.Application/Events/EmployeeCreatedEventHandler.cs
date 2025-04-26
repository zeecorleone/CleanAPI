
using CleanAPI.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Application.Events;

public class EmployeeCreatedEventHandler : INotificationHandler<EmployeeCreatedEvent>
{
    private readonly ILogger<EmployeeCreatedEventHandler> _logger;
    private readonly IEmailService _emailService;

    public EmployeeCreatedEventHandler(ILogger<EmployeeCreatedEventHandler> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }

    public async Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        await Task.Delay(2000);
        _logger.LogInformation($"Employee created: {notification.Employee.Id} - {notification.Employee.FirstName} {notification.Employee.LastName}");

        await Task.Delay(2000);
        await _emailService.SendEmailAsync(notification.Employee.Email, 
            "Welcome to Xyz COmpnay!",
            $"Dear {notification.Employee.FirstName}, welcome to Xyz Company. We are glad to have you on board.");
    }
}
