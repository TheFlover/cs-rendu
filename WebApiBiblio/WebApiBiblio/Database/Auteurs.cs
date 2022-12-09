using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class Auteur
    {
        [Key]
        public int AuteurId { get; set; }

        [MaxLength(50)]
        public string Nom { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Prenom { get; set; } = string.Empty;

        public DateTime Naissance { get; set; }
    }
}