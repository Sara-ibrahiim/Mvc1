using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Enitities
{
    public class ApplicationRole : IdentityRole
    {
        public DateTime CreatedAt { get; set; } =DateTime.Now;
    }
}
