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
        
    }
}
