using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Profil_Santé : Utilisateur
    {
        public virtual Categorie_Profil_Santé categorie { get; set; }
        public virtual ICollection<RDV> RDVs { get; set; }
    }
}
