﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Formation
    {
        [Key]
        public int IDFormation { get; set; }
        public string NomFormation { get; set; }
        public DateTime DatetFormation { get; set; }
        public string Capacite { get; set; }
        public virtual Categorie_Formation categorie { get; set; }
        public string AdresseLocal { get; set; }
        //le formateur
        public virtual Profil_Santé Profil_Santé { get; set; }
        //liste des participants a la formation
        public virtual List<Patient> Patients { get; set; }
        //l'administrateur qui a valider la formation
        public virtual Admin Admin { get; set; }
    }
}
