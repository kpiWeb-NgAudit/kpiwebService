using Microsoft.AspNetCore.Mvc;

namespace KpiWebService.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppicationDbContext _context;
    public EmployeeController(AppicationDbContext context)
    {
        this._context = context;
    }
    
    
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        
        var allEmployees = _context.Employees.ToList();
        return Ok(allEmployees);
    }
    
}