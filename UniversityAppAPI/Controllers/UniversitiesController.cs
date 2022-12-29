using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAppAPI.Data;
using UniversityAppAPI.Models;

namespace UniversityAppAPI.Controllers
{
    [ApiController]
    [Route("api/universities")]

    public class UniversitiesController : Controller
    {
        
        private readonly ApplicationDbContext _applicationDbContext;

        public UniversitiesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUniversities()
        {
            var universities = await _applicationDbContext.Universities.ToListAsync();
            return Ok(universities);
        }

        [HttpPost]
        public async Task<IActionResult> AddUniversity(University addUniversityRequest)
        {
            addUniversityRequest.Id = Guid.NewGuid();
            await _applicationDbContext.Universities.AddAsync(addUniversityRequest);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(addUniversityRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUniversity([FromRoute] Guid id)
        {
            var university = await _applicationDbContext.Universities.FirstOrDefaultAsync(x => x.Id == id);
            if (university == null)
            {
                return NotFound();
            }
            return Ok(university);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUniversity([FromRoute] Guid id, University updateUniversityRequest)
        {
            var university = await _applicationDbContext.Universities.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            university.Name = updateUniversityRequest.Name;
            university.City = updateUniversityRequest.City;
            university.State = updateUniversityRequest.State;
            university.VC = updateUniversityRequest.VC;
            university.Email = updateUniversityRequest.Email;
            university.Contact = updateUniversityRequest.Contact;

            await _applicationDbContext.SaveChangesAsync();
            return Ok(university);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUniversity([FromRoute] Guid id)
        {
            var university = await _applicationDbContext.Universities.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            _applicationDbContext.Universities.Remove(university);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(university);
        }


    }
}
