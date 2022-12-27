using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAppAPI.Data;

namespace UniversityAppAPI.Controllers
{
    [ApiController]
    [Route("api/employees")]

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
    }
}
