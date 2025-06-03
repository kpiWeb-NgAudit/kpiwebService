namespace KpiWebService.Models.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public decimal Salary { get; set; }
}