

using CleanAPI.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        _logger.LogInformation($"Email sent to {to} with subject: {subject}. Body:\n{body}");
        await Task.CompletedTask;
    }
}
