using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CarMaintenanceAPI.Models;
using System.Linq;

namespace CarMaintenanceAPI.Controllers
{
    [Route("api/MaintenanceType")]
    public class MaintenanceTypeController : Controller
    {
        private readonly MainContext _context;

        public MaintenanceTypeController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MaintenanceType> GetAll()
        {
            return _context.MaintenanceTypes.ToList();
        }

        [HttpGet("{id}", Name = "GetMaintenanceTypes")]
        public IActionResult GetById(int id)
        {
            var item = _context.MaintenanceTypes.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MaintenanceType item)
        {
            if (item == null)
                return BadRequest();

            _context.MaintenanceTypes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMaintenanceType", new { id = item.Id }, item);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] MaintenanceType item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            var type = _context.MaintenanceTypes.FirstOrDefault(x => x.Id == id);
            type.Description = item.Description;
            
            _context.MaintenanceTypes.Update(type);
            _context.SaveChanges();
            return new NoContentResult();
        } 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var type = _context.MaintenanceTypes.FirstOrDefault(x => x.Id == id);
            if (type == null)
                return NotFound();

            _context.MaintenanceTypes.Remove(type);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}