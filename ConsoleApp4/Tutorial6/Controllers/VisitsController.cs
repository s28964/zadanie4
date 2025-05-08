using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [Route("api/animals/{animalID}/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVisitsForAnimal(int animalID)
        {
            var visits = Database.Visits.Where(x => x.AnimalID == animalID);
            return Ok(visits);
        }

        [HttpPost]
        public IActionResult AddVisit(int animalID, [FromBody] Visit visit)
        {
            if (!Database.Animals.Any(x => x.ID == animalID))
                return NotFound($"No animal with ID {animalID} exists.");
            
            visit.AnimalID = animalID;
            Database.Visits.Add(visit);
            return Created("", visit);
        }
    }
}