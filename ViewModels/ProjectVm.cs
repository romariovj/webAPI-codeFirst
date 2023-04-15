using System.ComponentModel.DataAnnotations;

namespace WebAPI_CodeFirst.ViewModels
{
    public class ProjectVm: CreateProjectVm
    {
        public int Id { get; set; }
    }

    public class CreateProjectVm
    {
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
