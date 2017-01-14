using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemID { get; set; }
        public Image itemThumb { get; set; }
        public List<Image> itemGallery { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public decimal itemPrice { get; set; }
        public List<Attributes> itemAttributes { get; set; }
    }

    public class Attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int attributeID { get; set; }
        public string attributeKey { get; set; }
        public string attributeValue { get; set; }
    }
}