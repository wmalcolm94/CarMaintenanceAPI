using CarMaintenanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenanceAPI.Controllers
{
    [Route("api/Car")]
    public class CarController : Controller
    {
        private readonly MainContext _context;

        public CarController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult GetById(int id)
        {
            var item = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Car item)
        {
            if (item == null)
                return BadRequest();

            _context.Cars.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCar", new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id, [FromBody] Car item)
        {
            if (item == null || item.Id != id)
                return BadRequest();
            
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            car.Description = item.Description;
            car.OwnerId = item.OwnerId;
            car.TypeId = item.TypeId;

            _context.Cars.Update(car);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public IActionResult Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
                return NotFound();

            _context.Cars.Remove(car);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}