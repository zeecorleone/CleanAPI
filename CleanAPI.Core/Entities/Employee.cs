
namespace CleanAPI.Core.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string Email { get; set; } = null;
    public string Phone { get; set; } = null;
}
