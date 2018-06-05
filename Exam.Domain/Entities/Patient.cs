using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Patient : Utilisateur
    {
        public virtual ICollection<Commentaire> Commentaires { get; set; }
        public virtual ICollection<RDV> RDVs { get; set; }
    }
}
