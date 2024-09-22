using MyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/originatedProject")]
    public class ProjectsAndLocationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsAndLocationController(AppDbContext context)
        {
            _context = context;
        }

        // ----------- NEW API FOR DROPDOWN VALUES FROM BOTH TABLES -----------

        // GET: api/originatedProject/dropdownValues
        [HttpGet("dropdownValues")]
        public async Task<IActionResult> GetDropdownValues()
        {
            // Query the ProjectCoordinatorTbl
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

            return Ok(combinedResult);
        }

        // ----------- PROJECTS API ENDPOINTS -----------

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

        // POST: api/originatedProject/locationTable

        // DELETE: api/originatedProject/locationTable/{id}

        // ----------- NEW API TO GET LOCATIONS BY lookup_facility_loc_id -----------

        // GET: api/originatedProject/locationTable/facility/{lookupFacilityLocId}
        [HttpGet("locationTable/facility/{lookupFacilityLocId}")]
        public async Task<IActionResult> GetLocationByFacilityLocId(int lookupFacilityLocId)
        {
            var locations = await _context.LocationTable
                .ToListAsync();

            if (locations == null || !locations.Any())
            {
                return NotFound();
            }

            return Ok(locations);
        }
    }
}
