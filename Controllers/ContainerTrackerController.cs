using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContainerTracker.Models;

namespace ContainerTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerTrackerController : ControllerBase
    {
        private readonly ContainerTrackerContext _context;

        public ContainerTrackerController(ContainerTrackerContext context)
        {
            _context = context;
        }

        // GET: api/ContainerTracker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Container>>> GetContainers()
        {
            return await _context.Containers.ToListAsync();
        }

        // GET: api/ContainerTracker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Container>> GetContainer(long id)
        {
            var container = await _context.Containers.FindAsync(id);

            if (container == null)
            {
                return NotFound();
            }

            return container;
        }

        // PUT: api/ContainerTracker/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer(long id, Container container)
        {
            if (id != container.Id)
            {
                return BadRequest();
            }

            _context.Entry(container).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
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

        // POST: api/ContainerTracker
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Container>> PostContainer(Container container)
        {
            _context.Containers.Add(container);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContainer", new { id = container.Id }, container);
        }

        // DELETE: api/ContainerTracker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(long id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContainerExists(long id)
        {
            return _context.Containers.Any(e => e.Id == id);
        }
    }
}
