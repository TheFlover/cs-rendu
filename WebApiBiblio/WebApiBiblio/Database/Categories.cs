using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }

        [MaxLength(50)]
        public string Nom { get; set; } = string.Empty;
    }
}
