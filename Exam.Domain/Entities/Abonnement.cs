using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Abonnement
    {
        public int Id { get; set; }
        public DateTime DateCretion { get; set; }
        public DateTime DateExpiration { get; set; }
        public string TypeAbonnement { get; set; }
        public Utilisateur User { get; set; }
    }
}
