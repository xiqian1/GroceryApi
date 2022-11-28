using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryApi.Models;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        private readonly GroceryAPIDBContext _context;
        private Response GroceryResponse;

        public GroceryController(GroceryAPIDBContext context)
        {
            _context = context;
            GroceryResponse = new Response();
        }

        // GET: api/Grocery
        [HttpGet]
        public async Task<ActionResult<Response>> GetGroceryItems()
        {
            var info = await _context.ItemInfo.ToListAsync();
            var grocery = await _context.GroceryItems.ToListAsync();
            GroceryResponse.statusCode = 200;
            GroceryResponse.statusDescription = "Grocery Returned";
            GroceryResponse.groceries = grocery;
            return GroceryResponse;
        }

        // GET: api/Grocery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetGrocery(int id)
        {
            var info = await _context.ItemInfo.ToListAsync();
            var grocery = await _context.GroceryItems.FindAsync(id);

            if (grocery == null)
            {
                GroceryResponse.statusCode = 404;
                GroceryResponse.statusDescription = "Grocery not Returned";
                return GroceryResponse;
            }
            GroceryResponse.statusCode = 200;
            GroceryResponse.statusDescription = "Grocery Item Returned";
            GroceryResponse.grocery = grocery;
            return GroceryResponse;
        }

        // PUT: api/Grocery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Response> PutGrocery(int id, Grocery grocery)
        {
            //var info = await _context.ItemInfo.ToListAsync();
            if (id != grocery.ItemId)
            {
                GroceryResponse.statusCode = 400;
                GroceryResponse.statusDescription = "Grocery failed to update";
                return GroceryResponse;
            }

            _context.Entry(grocery).State = EntityState.Modified;
            _context.Entry(grocery.Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(id))
                {
                    GroceryResponse.statusCode = 404;
                    GroceryResponse.statusDescription = "Grocery failed to update";
                    return GroceryResponse;
                }
                else
                {
                    throw;
                }
            }
            GroceryResponse.statusCode = 200;
            GroceryResponse.statusDescription = "Grocery Item Updated";
            return GroceryResponse;
        }

        // POST: api/Grocery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostGrocery(Grocery grocery)
        {
            _context.GroceryItems.Add(grocery);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                GroceryResponse.statusCode = 400;
                GroceryResponse.statusDescription = "Grocery cannot be created";
            }
            GroceryResponse.statusCode = 200;
            GroceryResponse.statusDescription = "Grocery Item created";
            GroceryResponse.grocery = grocery;
            return GroceryResponse;
            //CreatedAtAction("GetGrocery", new { id = grocery.ItemId }, grocery);
        }

        // DELETE: api/Grocery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrocery(int id)
        {
            var grocery = await _context.GroceryItems.Include(c => c.Info).FirstOrDefaultAsync(c => c.ItemId == id);
            if (grocery == null)
            {
                return NotFound();
            }

            _context.GroceryItems.Remove(grocery);

            var info = await _context.ItemInfo.FirstOrDefaultAsync(e => e.InfoId == grocery.Info.InfoId);

            _context.ItemInfo.Remove(info);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroceryExists(int id)
        {
            return _context.GroceryItems.Any(e => e.ItemId == id);
        }
    }
}
