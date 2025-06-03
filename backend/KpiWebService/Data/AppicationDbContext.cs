using KpiWebService.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class AppicationDbContext : DbContext
{
    public AppicationDbContext(DbContextOptions<AppicationDbContext> options) :  base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}