using Exam.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public  class ExamContext : IdentityDbContext<Utilisateur, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {


        public ExamContext():base("name=BibDB")
        {

        }
        

        public DbSet<RDV> RDV { get; set; }
        public DbSet<Commentaire> Commentaire { get; set; }
        public DbSet<Formation> Formation { get; set; }
        public DbSet<Abonnement> Abonnement { get; set; }
        public DbSet<Avis> Avis { get; set; }
        public DbSet<Participation> Participation { get; set; }
        public DbSet<Evenement> Evenement { get; set; }
        public DbSet<Document> Document { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
        }
    }
}
