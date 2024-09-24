using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/originatedProject")]
    public class ProjectsAndLocationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConnectionMultiplexer _redis;

        public ProjectsAndLocationController(AppDbContext context, IConnectionMultiplexer redis)
        {
            _context = context;
            _redis = redis;
        }

        // GET: api/originatedProject/dropdownValues
        [HttpGet("dropdownValues")]
        public async Task<IActionResult> GetDropdownValues()
        {
            // Redis cache key
            string cacheKey = "dropdownValues";

            // Connect to Redis
            var database = _redis.GetDatabase();

            // Check if the data exists in the cache
            var cachedData = await database.StringGetAsync(cacheKey);
            if (!cachedData.IsNullOrEmpty)
            {
                // If cache hit, return the cached data
                return Ok(JsonSerializer.Deserialize<object>(cachedData!));
            }

            // Cache miss: Query the ProjectCoordinatorTbl
            var coordinatorDropdowns = await _context.ProjectCordinatortbl
                .Select(pc => new
                {
                    pc.Id,
                    pc.DropdownValues,
                    pc.DropDownLabel
                })
                .ToListAsync();

            // Query the ProjectPlanningTbl
            var planningDropdowns = await _context.projectPlanningtbl
                .Select(pp => new
                {
                    pp.Id,
                    pp.DropdownValues,
                    pp.DropDownLabel,
                    pp.dropDownNumber
                })
                .ToListAsync();

            // Create a combined result with "projectCordinator" and "projectManager" keys
            var combinedResult = new
            {
                projectCordinator = coordinatorDropdowns,
                projectManager = planningDropdowns
            };

            // Serialize the result and store it in Redis cache with an expiration time (e.g., 10 minutes)
            await database.StringSetAsync(cacheKey, JsonSerializer.Serialize(combinedResult), TimeSpan.FromMinutes(10));

            return Ok(combinedResult);
        }

        // Other endpoints for projects and location table...

        // GET: api/originatedProject/projects
        [HttpGet("projects")]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);
        }

        // GET: api/originatedProject/projects/5
        [HttpGet("projects/{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // POST: api/originatedProject/projects
        [HttpPost("projects")]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        // PUT: api/originatedProject/projects/5
        [HttpPut("projects/{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.Id || project == null)
            {
                return BadRequest();
            }

            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.ProcessType = project.ProcessType;
            existingProject.ProjectName = project.ProjectName;
            existingProject.Description = project.Description;
            existingProject.ProblemStatement = project.ProblemStatement;
            existingProject.ProposedSolution = project.ProposedSolution;
            existingProject.Assumptions = project.Assumptions;
            existingProject.Constraints = project.Constraints;
            existingProject.Benefits = project.Benefits;
            existingProject.ProjectCode = project.ProjectCode;
            existingProject.OriginatorROM = project.OriginatorROM;

            _context.Projects.Update(existingProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/originatedProject/projects/5
        [HttpDelete("projects/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ----------- LOCATION TABLE API ENDPOINTS -----------

        // GET: api/originatedProject/locationTable
        [HttpGet("locationTable")]
        public async Task<IActionResult> GetLocationTable()
        {
            var locations = await _context.LocationTable.ToListAsync();
            return Ok(locations);
        }

        // GET: api/originatedProject/locationTable/{id}
        [HttpGet("locationTable/{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _context.LocationTable.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // GET: api/originatedProject/locationTable/facility/{lookupFacilityLocId}
        [HttpGet("locationTable/facility/{lookupFacilityLocId}")]
        public async Task<IActionResult> GetLocationByFacilityLocId(int lookupFacilityLocId)
        {
            var locations = await _context.LocationTable
                .Where(l => l.LookupFacilityLocId == lookupFacilityLocId)
                .ToListAsync();

            if (locations == null || !locations.Any())
            {
                return NotFound();
            }

            return Ok(locations);
        }
    }
}