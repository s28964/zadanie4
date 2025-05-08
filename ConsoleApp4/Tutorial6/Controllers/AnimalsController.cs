using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        //http://localhost:5103/api/animals
        [HttpGet]
        public IActionResult GetAll() => Ok(Database.Animals);
        
        //http://localhost:5103/api/animals/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.ID == id);
            return animal == null ? NotFound() : Ok(animal);
        }
        
        //http://localhost:5103/api/animals/search?name=doggo
        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var result = Database.Animals.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            return Ok(result);
        }
        
        
        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            animal.ID = Database.Animals.Max(x => x.ID) + 1;
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.ID }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Animal AnimalUpdated)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.ID == id);
            if (animal == null) return NotFound();
            animal.Name = AnimalUpdated.Name;
            animal.Category = AnimalUpdated.Category;
            animal.Weight = AnimalUpdated.Weight;
            animal.FurColor = AnimalUpdated.FurColor;
            return NoContent();
        }
        
        //http://localhost:5103/api/animals/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.ID == id);
            if (animal == null) return NotFound();
            Database.Animals.Remove(animal);
            return NoContent();
        }
    }
}