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
        public string Name { get; set; }

        [DisplayName("Megjelenítési sorrend")]
        public int DisplayOrder { get; set; }
    }
}
