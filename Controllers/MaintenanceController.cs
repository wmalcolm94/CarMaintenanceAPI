using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CarMaintenanceAPI.Models;
using System.Linq;
namespace CarMaintenanceAPI.Models
{
    [Route("api/maintenance")]
    public class MaintenanceController : Controller
    {
        private readonly MainContext _context;

        public MaintenanceController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Maintenance> GetAll()
        {
            return _context.Maintenances.ToList();
        }

        [HttpGet("{id}", Name = "GetMaintenance")]
        public IActionResult GetById(int id)
        {
            var item = _context.Maintenances.FirstOrDefault(x => x.Id == id); 
            if (item == null)
                return NotFound();
            
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Maintenance item)
        {
            if (item == null)
                return BadRequest();

            _context.Maintenances.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMaintenance", new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Maintenance item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            var main = _context.Maintenances.FirstOrDefault(x => x.Id == id);
            main.CarId = item.CarId;
            main.Date = item.Date;
            main.Description = item.Description;
            main.ExpiryDate = item.ExpiryDate;
            main.TypeId = item.TypeId;
            
            _context.Maintenances.Update(main);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var main = _context.Maintenances.FirstOrDefault(x => x.Id == id);
            if (main == null)
                return NotFound();

            _context.Maintenances.Remove(main);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }

}