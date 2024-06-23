using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Kategoria név")]
        [MaxLength(20)]
        public string Name { get; set; }

        [DisplayName("Megjelenítési sorrend")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
