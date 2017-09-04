using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CarMaintenanceAPI.Models;
using System.Linq;

namespace CarMaintenanceAPI.Controllers 
{
    [Route("api/Owner")]
    public class OwnerController : Controller
    {
        private readonly MainContext _context;

        public OwnerController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }

        [HttpGet("{id}", Name = "GetOwner")]
        public IActionResult GetById(int id)
        {
            var item = _context.Owners.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Owner item)
        {
            if (item == null)
                return BadRequest();

            _context.Owners.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetOwner", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Owner item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            var owner = _context.Owners.FirstOrDefault(x => x.Id == id);
            owner.Name = item.Name;
            
            _context.Owners.Update(owner);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var owner = _context.Owners.FirstOrDefault(x => x.Id == id);
            if (owner == null)
                return NotFound();

            _context.Owners.Remove(owner);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}