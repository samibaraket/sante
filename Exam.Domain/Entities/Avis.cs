using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Avis
    {
        public int Id { get; set; }
        public string AvisContent { get; set; }
        public int AvisValue { get; set; }
        public DateTime DateCreation { get; set; }
        public Utilisateur User { get; set; }
        public Formation IdFormation { get; set; }
        public Produit_Medicaux IdProduit_Medicaux { get; set; }
        public Evenement IdEvenement { get; set; }
    }
}
