using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.Models;
using RestApiOrders.Models.Contexts;

namespace RestApiOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasurementController : ControllerBase
    {
        private readonly CompanyContext _context;

        public UnitOfMeasurementController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/UnitOfMeasurement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasurement>>> GetUnitOfMeasurements()
        {
          if (_context.UnitOfMeasurements == null)
          {
              return NotFound();
          }
            return await _context.UnitOfMeasurements.ToListAsync();
        }

        // GET: api/UnitOfMeasurement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasurement>> GetUnitOfMeasurement(int id)
        {
          if (_context.UnitOfMeasurements == null)
          {
              return NotFound();
          }
            var unitOfMeasurement = await _context.UnitOfMeasurements.FindAsync(id);

            if (unitOfMeasurement == null)
            {
                return NotFound();
            }

            return unitOfMeasurement;
        }

        // PUT: api/UnitOfMeasurement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitOfMeasurement(int id, UnitOfMeasurement unitOfMeasurement)
        {
            if (id != unitOfMeasurement.IdUnitOfMeasurement)
            {
                return BadRequest();
            }

            _context.Entry(unitOfMeasurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitOfMeasurementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UnitOfMeasurement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitOfMeasurement>> PostUnitOfMeasurement(UnitOfMeasurement unitOfMeasurement)
        {
          if (_context.UnitOfMeasurements == null)
          {
              return Problem("Entity set 'CompanyContext.UnitOfMeasurements'  is null.");
          }
            _context.UnitOfMeasurements.Add(unitOfMeasurement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitOfMeasurementExists(unitOfMeasurement.IdUnitOfMeasurement))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnitOfMeasurement", new { id = unitOfMeasurement.IdUnitOfMeasurement }, unitOfMeasurement);
        }

        // DELETE: api/UnitOfMeasurement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitOfMeasurement(int id)
        {
            if (_context.UnitOfMeasurements == null)
            {
                return NotFound();
            }
            var unitOfMeasurement = await _context.UnitOfMeasurements.FindAsync(id);
            if (unitOfMeasurement == null)
            {
                return NotFound();
            }

            _context.UnitOfMeasurements.Remove(unitOfMeasurement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitOfMeasurementExists(int id)
        {
            return (_context.UnitOfMeasurements?.Any(e => e.IdUnitOfMeasurement == id)).GetValueOrDefault();
        }
    }
}
