using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Emprunt
    {
        [Key]
        public int EmpruntId { get; set; }

        [ForeignKey("Etudiant")]
        [Column(Order = 1)]
        public int EtudiantId { get; set; }

        [ForeignKey("Livre")]
        [Column(Order = 2)]
        public int LivreId { get; set; }

        public DateTime DateEmprunt { get; set; }

        public DateTime DateRetour { get; set; }
    }
}