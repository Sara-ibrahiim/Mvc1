using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Enitities
{
    public class Department : BaseEntity
    {
      //  public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string? Name { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
