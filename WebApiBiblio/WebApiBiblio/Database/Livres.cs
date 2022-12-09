using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Livre
    {
        [Key]
        public int LivreId { get; set; }

        [ForeignKey("Auteur")]
        [Column(Order = 1)]
        public int AuteurId { get; set; }

        [ForeignKey("Categorie")]
        [Column(Order = 2)]
        public int CategorieId { get; set; }

        [MaxLength(50)]
        public string Titre { get; set; } = string.Empty;

        public DateTime DatePublication { get; set; }
    }
}