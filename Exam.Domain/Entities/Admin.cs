using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Admin : Utilisateur
    {
        public int? FormationsId { get; set; }
        public int? PrdtMedicsId { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }
        public virtual ICollection<Produit_Medicaux> PrdtMedics { get; set; }
    }
}
