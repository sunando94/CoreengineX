using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Location location { get; set; }
        public string profilepicUrl { get; set; }
    }

    public class Location
    {
        [Key]
        public int locationID { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
    }
}
