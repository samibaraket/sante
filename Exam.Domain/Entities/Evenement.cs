using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Evenement
    {
        public int Id { get; set; }
        public string NomEvenement { get; set; }
        public string Description { get; set; }
        public Utilisateur IdProfilSante { get; set; }
        public Boolean Actif { get; set; }
        public DateTime DateEvenement { get; set; }
        public DateTime DateCreation { get; set; }
        public int NbrParticipants { get; set; }

    }
}
