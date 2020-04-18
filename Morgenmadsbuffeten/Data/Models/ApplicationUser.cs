using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool IsChild { get; set; }
    }
}
