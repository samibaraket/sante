using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Participation
    {
        public int Id { get; set; }
        public DateTime DateValidation { get; set; }
        public Boolean Etat { get; set; }
        public Utilisateur User { get; set; }
        public Evenement IdEvenement { get; set; }
    }
}
