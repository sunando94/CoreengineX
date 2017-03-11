using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreenginex.Models
{
    public class ApplicationUser:IdentityUser
    {
       public ApplicationUser() : base() { }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Location location { get; set; }
        public string profilepicUrl { get; set; }
        public Address permanentAddress { get; set; }
        public Address currentAddress { get; set; }

        public List<StoreApplicationUser> watch { get; set; }

    }
    public class StoreApplicationUser
    {
        [ForeignKey("User")]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("store")]
        public int storeID { get; set; }
        public Store store { get; set; }
    }
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }
        public String StreetName { get; set; }
        public String  locality{ get; set; }
        public String city { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String PhoneNumber { get; set; }
        public String email { get; set; }
    }
   
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int locationID { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}
