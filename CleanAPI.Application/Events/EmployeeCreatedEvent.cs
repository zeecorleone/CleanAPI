

using CleanAPI.Core.Entities;
using MediatR;

namespace CleanAPI.Application.Events;

public record EmployeeCreatedEvent(Employee Employee) : INotification;
