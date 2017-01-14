using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Business
    {
        [Key]
        public int businessID { get; set; }
        public string businessName { get; set; }
        public Image businessThumb { get; set; }
        public List<Image> businessGallery { get; set; }
        public List<ApplicationUser> ourTeam { get; set; }
        public List<Reviews> reviews { get; set; }
        public List<ApplicationUser> followers { get; set; }
        public List<Item> products { get; set; }
    }

    public class Reviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewID { get; set; }
        public string review { get; set; }
        public ApplicationUser user { get; set; }
    }

    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int imageID { get; set; }
        public string imageUrl { get; set; }
    }
}
