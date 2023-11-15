using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string? Name { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
