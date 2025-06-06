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
            // Backend sets these initial timestamps
            customer.cube_lastupdate = DateTime.UtcNow; // Or DateTime.Now, depending on timezone needs
            customer.cube_lastprocess = DateTime.UtcNow; // Or a specific initial value, or leave if DB default
            // cust_timestamp is handled by EF Core due to [Timestamp]

            _context.customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log ex.InnerException for detailed SQL error
                Console.WriteLine($"DB UPDATE EXCEPTION (POST): {ex.InnerException?.Message}");
                // Handle specific constraint violations if desired, otherwise let global handler catch
                return StatusCode(500, $"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.cube_id_pk }, customer);
        }

        // CustomerController.cs
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(string id, customer customerFromRequest) // Renamed for clarity
        {
            Console.WriteLine($"--- Processing PUT for ID: {id} ---");
            Console.WriteLine($"Received cube_id_pk in body: {customerFromRequest.cube_id_pk}");
            Console.WriteLine($"Received cube_name in body: {customerFromRequest.cube_name}"); // Example field
            // Console.WriteLine($"Received cube_lastupdate in body (before overwrite): {customerFromRequest.cube_lastupdate}");
            // Console.WriteLine($"Received cube_lastprocess in body (problematic): {customerFromRequest.cube_lastprocess}");
            Console.WriteLine($"Received cust_timestamp in body: {Convert.ToBase64String(customerFromRequest.cust_timestamp ?? new byte[0])}");

            if (id != customerFromRequest.cube_id_pk)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            // 1. Fetch the existing entity from the database
            var existingCustomer = await _context.customers.FindAsync(id);

            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            // 2. Apply changes from customerFromRequest to existingCustomer
            // Only update fields that are meant to be editable by the user via this PUT request.
            // Do NOT just assign customerFromRequest to existingCustomer directly if some fields are system-managed.

            existingCustomer.cube_name = customerFromRequest.cube_name;
            existingCustomer.cube_number = customerFromRequest.cube_number;
            existingCustomer.cust_geocode = customerFromRequest.cust_geocode;
            existingCustomer.cust_town = customerFromRequest.cust_town;
            existingCustomer.cust_country = customerFromRequest.cust_country;
            existingCustomer.cust_cubetype = customerFromRequest.cust_cubetype;
            existingCustomer.cust_ostype = customerFromRequest.cust_ostype; // If null from request, this will set it to null if DB allows
            existingCustomer.cust_dbtype = customerFromRequest.cust_dbtype;
            existingCustomer.cust_erptype = customerFromRequest.cust_erptype;
            existingCustomer.cust_connect_str = customerFromRequest.cust_connect_str;
            existingCustomer.cube_ftpuser = customerFromRequest.cube_ftpuser;
            existingCustomer.cube_ftppasswd = customerFromRequest.cube_ftppasswd;
            existingCustomer.cust_refreshfrq = customerFromRequest.cust_refreshfrq;
            existingCustomer.cust_refreshfrqmonth = customerFromRequest.cust_refreshfrqmonth;
            existingCustomer.cust_charseparator = customerFromRequest.cust_charseparator;
            existingCustomer.cust_limitrdlfilter = customerFromRequest.cust_limitrdlfilter;
            existingCustomer.cust_rdlinterwidlen = customerFromRequest.cust_rdlinterwidlen;
            existingCustomer.cube_identity = customerFromRequest.cube_identity;
            existingCustomer.cust_language = customerFromRequest.cust_language;
            existingCustomer.cube_nbproddatasources = customerFromRequest.cube_nbproddatasources;
            existingCustomer.cube_proddatasource_prefix = customerFromRequest.cube_proddatasource_prefix;
            existingCustomer.cust_beginmonthfiscal = customerFromRequest.cust_beginmonthfiscal;
            existingCustomer.cust_rdlcurrencyformat = customerFromRequest.cust_rdlcurrencyformat;
            existingCustomer.cube_dailytasktrigger = customerFromRequest.cube_dailytasktrigger;
            existingCustomer.cube_localcubgenerate = customerFromRequest.cube_localcubgenerate;
            existingCustomer.cube_optimratio = customerFromRequest.cube_optimratio;
            existingCustomer.cube_nbdimtimevcol = customerFromRequest.cube_nbdimtimevcol;
            existingCustomer.cube_nbdimgeovcol = customerFromRequest.cube_nbdimgeovcol;
            existingCustomer.cust_internalnotes = customerFromRequest.cust_internalnotes;
            existingCustomer.cust_externalnotes = customerFromRequest.cust_externalnotes;
            existingCustomer.cust_contact1 = customerFromRequest.cust_contact1;
            existingCustomer.cust_contact2 = customerFromRequest.cust_contact2;
            existingCustomer.cust_contact3 = customerFromRequest.cust_contact3;
            existingCustomer.cust_showfiscmeasureandset = customerFromRequest.cust_showfiscmeasureandset;
            existingCustomer.cust_showpctdifferencebase100 = customerFromRequest.cust_showpctdifferencebase100;
            existingCustomer.cube_dimtimepkmanager = customerFromRequest.cube_dimtimepkmanager;
            existingCustomer.cube_globalperspective = customerFromRequest.cube_globalperspective;
            existingCustomer.cube_scope_mdxinstruction = customerFromRequest.cube_scope_mdxinstruction;
            existingCustomer.cube_drillthroughnbrows = customerFromRequest.cube_drillthroughnbrows;
            existingCustomer.cube_factcoldefaultmeasure = customerFromRequest.cube_factcoldefaultmeasure;
            existingCustomer.cube_distinctcountpartition = customerFromRequest.cube_distinctcountpartition;
            existingCustomer.cube_typenormalreplica = customerFromRequest.cube_typenormalreplica;
            existingCustomer.cube_paramwhenreplica = customerFromRequest.cube_paramwhenreplica;
            existingCustomer.cube_comments = customerFromRequest.cube_comments;

            // 3. Set system-managed fields
            existingCustomer.cube_lastupdate = DateTime.UtcNow;
            // existingCustomer.cube_lastprocess remains untouched (its value from DB is preserved)

            // 4. IMPORTANT: Set the timestamp for concurrency check.
            // EF Core needs the original timestamp from the client to compare against the DB.
            // The customerFromRequest object has the timestamp sent by the client.
            // We need to apply this to the entity EF Core is tracking for the concurrency check.
            _context.Entry(existingCustomer).Property("cust_timestamp").OriginalValue = customerFromRequest.cust_timestamp;
            // Note: If you have `[Timestamp]` on cust_timestamp, EF Core might handle this automatically
            // when you attach and save, but explicitly setting OriginalValue is safer for concurrency.
            // Alternatively, some people map DTOs to entities using libraries like AutoMapper, which can handle this.

            // _context.Entry(existingCustomer).State = EntityState.Modified; // Not strictly needed if you modify properties on a tracked entity

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // This check is fine, but the initial FindAsync should have caught if it's truly gone.
                // This is more for if it was modified between your FindAsync and SaveChangesAsync.
                if (!_context.customers.Any(e => e.cube_id_pk == id)) // Re-check just in case
                     return NotFound($"Customer with ID {id} was deleted during the update process.");
                else
                {
                    Console.WriteLine($"DB UPDATE CONCURRENCY EXCEPTION (PUT) for ID: {id}");
                    return Conflict("The record you attempted to edit was modified by another user or process after you loaded the data. Please refresh and try again.");
                }
            }
            catch (DbUpdateException ex) // Catches other update errors like constraint violations
            {
                Console.WriteLine($"DB UPDATE EXCEPTION (PUT) for ID {id}: {ex.ToString()}"); // Log full exception
                // Check for specific inner exceptions if possible
                var sqlException = ex.InnerException as Microsoft.Data.SqlClient.SqlException;
                if (sqlException != null)
                {
                    return StatusCode(500, $"Database error (Code: {sqlException.Number}): {sqlException.Message}");
                }
                return StatusCode(500, $"Database error: {ex.InnerException?.Message ?? ex.Message}");
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