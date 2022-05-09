#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterAPI.AnimalDomain.Models;
using AnimalShelterAPI.Data;
using System.Net.Http.Headers;
using AnimalShelterAPI.AnimalDomain.Services;
using AnimalShelterAPI.AnimalDomain.SearchParams;

namespace AnimalShelterAPI.AnimalDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IAnimalRepository _repository;

        public AnimalsController(Context context, IAnimalRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/Animals
        [HttpGet]
        public ActionResult <IEnumerable<AnimalView>> GetAnimals()
        {
            //return await _context.Animals.Include(x=>x.User).Include(x=>x.User.Contact).ToListAsync();
            var query = _repository.GetAllAnimals();
            query = query.OrderByDescending(x => x.Published);
            return Ok(query);
        }

        // GET: api/Animals/filter
        [HttpPost("filter")]
        public ActionResult<IEnumerable<AnimalView>> GetFilteredAnimals([FromBody] AnimalSearchParams searchParams)
        {
            var filters = AnimalEnumsView.ToAnimalEnumsView(searchParams);

            var query = _repository.GetAllAnimals();

            if (filters.male.HasValue || filters.female.HasValue) {
                query = query.Where(x => x.Gender == filters.male || x.Gender == filters.female);
            }
            if (filters.dogs.HasValue || filters.cats.HasValue || filters.other.HasValue || filters.birds.HasValue || filters.fish.HasValue || filters.rodents.HasValue)
            {
                query = query.Where(x => x.Type == filters.dogs || x.Type == filters.cats || x.Type == filters.other || x.Type == filters.birds || x.Type == filters.fish || x.Type == filters.rodents);
            }
            if (filters.young.HasValue || filters.senior.HasValue || filters.adult.HasValue)
            {
                query = query.Where(x => x.Age == filters.young || x.Age == filters.senior || x.Age == filters.adult);
            }
            if (filters.forAdoption.HasValue || filters.found.HasValue || filters.lost.HasValue)
            {
                query = query.Where(x => x.Status == filters.found || x.Status == filters.lost || x.Status == filters.forAdoption);
            }
            if (!string.IsNullOrEmpty(filters.city)){
                query = query.Where(x => x.Contact.City == filters.city);
            }
            query = query.OrderByDescending(x => x.Published);

            return Ok(query);
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
            return NoContent();
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //[HttpPost, DisableRequestSizeLimit]
        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        //var folderName = Path.Combine(Path.GetDirectoryName(file.Name), file.Name);
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(pathToSave, fileName);


        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else { return BadRequest(); }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}
