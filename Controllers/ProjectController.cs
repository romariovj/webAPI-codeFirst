using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CodeFirst.Data;
using WebAPI_CodeFirst.Data.Models;
using WebAPI_CodeFirst.ViewModels;

namespace WebAPI_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _projectContext;

        public ProjectController(ProjectContext projectContext) 
        {
            _projectContext = projectContext;
        }

        [HttpGet(Name = "GetProject")]
        public IActionResult Get()
        {
            return Ok(_projectContext.Projects.ToList());
        }

        [HttpPut(Name = "UpdateProject")]
        public async Task<IActionResult> Update(int id, ProjectVm vm) 
        {
            Project? model = _projectContext.Projects.
                                    FirstOrDefault(project => project.Id.Equals(id));

            if(model == null)
                return NotFound(id);

            model.Name = vm.Name;
            model.Status = vm.Status;

            _projectContext.Projects.Update(model);
            await _projectContext.SaveChangesAsync();
            return Ok(id);
        }

        [HttpPost(Name = "CreateProject")]
        public async Task<IActionResult> Create(CreateProjectVm vm)
        {
            Project model = new Project();
            model.Name = vm.Name;
            model.Status = vm.Status;

            _projectContext.Projects.Add(model);
            await _projectContext.SaveChangesAsync();
            return Ok(model.Id);
        }
    }
}
