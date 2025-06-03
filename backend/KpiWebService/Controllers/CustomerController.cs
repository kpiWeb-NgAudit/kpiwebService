using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KpiWebService.Models;
using KpiWebService.Data;

namespace KpiWebService.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly KPIW_1_5Context _context;

        public CustomerController(KPIW_1_5Context context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<customer>>> GetCustomers()
        {
            try
            {
                // Utilise l'entité customer et le DbContext simplifiés
                var customers = await _context.customers.Take(10).ToListAsync(); // Take(10) pour limiter les données
                return Ok(customers);
            }
            catch (Exception ex)
            {
                // Logguez l'exception complète pour voir la stack trace détaillée
                Console.WriteLine($"ERROR IN GetCustomers: {ex.ToString()}");
                // Vous pouvez mettre un point d'arrêt ici pour inspecter ex
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Customer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<customer>> GetCustomer(string id)
        {
            var customer = await _context.customers.FindAsync(id);

            if (customer == null)
                return NotFound();

            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<customer>> PostCustomer(customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.cube_id_pk }, customer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(string id, customer customer)
        {
            if (id != customer.cube_id_pk)
                return BadRequest();

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.customers.Any(e => e.cube_id_pk == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
                return NotFound();

            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}