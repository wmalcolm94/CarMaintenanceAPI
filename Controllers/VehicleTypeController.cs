using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CarMaintenanceAPI.Models;
using System.Linq;

namespace CarMaintenanceAPI.Controllers
{
    [Route("api/VehicleType")]
    public class VehicleTypeController : Controller
    {
        private readonly MainContext _context;

        public VehicleTypeController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<VehicleType> GetAll()
        {
            return _context.VehicleTypes.ToList();
        }

        [HttpGet("{id}", Name = "GetVehicleType")]
        public IActionResult GetById(int id)
        {
            var item = _context.VehicleTypes.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VehicleType item)
        {
            if (item == null)
                return BadRequest();

            _context.VehicleTypes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetVehicleType", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] VehicleType item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            var type = _context.VehicleTypes.FirstOrDefault(x => x.Id == id);
            type.Description = item.Description;
            
            _context.VehicleTypes.Update(item);
            _context.SaveChanges();
            
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var type = _context.VehicleTypes.FirstOrDefault(x => x.Id == id);
            if (type == null)
                return NotFound();

            _context.VehicleTypes.Remove(type);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}