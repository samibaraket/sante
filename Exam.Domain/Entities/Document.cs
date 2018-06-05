using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DatePublication { get; set; }
        public Utilisateur IdPatient { get; set; }
        public Utilisateur IdProfilSante { get; set; }
    }
}
