using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreenginex.Models
{
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int businessID { get; set; }
        public string businessName { get; set; }
        public string alias { get; set; }
        public String Type { get; set; }
        public Category category { get; set; }
        public SubCategory subCategory { get; set; }

        public Image logo { get; set; }
        public virtual List<Store> Store { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual List<Department> departments { get; set; }
    }

    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }
        public String DepartmentName { get; set; }
        public virtual ApplicationUser Poc { get; set; }
      //  public virtual List<ApplicationUser> ourTeam { get; set; }
        

    }
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int storeID { get; set; }
        public Image storeThumb { get; set; }
        public List<Image> storeGallery { get; set; }
        public Location location { get; set; }
        public List<Reviews> reviews { get; set; }
        public string openingTime { get; set; }
        public string closingTime { get; set; }
        public String status { get; set; } = "Active";
        public decimal totalRating { get; set; }
        public virtual List<StoreApplicationUser> followers { get; set; }
        public List<Item> products { get; set; }
    }
    /// <summary>
    /// Stores user reviews
    /// </summary>
    public class Reviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int reviewID { get; set; }
        public string review { get; set; }
        public decimal rating { get; set; }
        public ApplicationUser user { get; set; }
    }
    /// <summary>
    /// For storing images in image table
    /// </summary>
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int imageID { get; set; }
        public string imageUrl { get; set; }
    }
}
