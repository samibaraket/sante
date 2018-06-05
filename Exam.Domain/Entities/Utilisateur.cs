using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace Exam.Domain.Entities
{
    public class Utilisateur : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public int Num_Tel { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        public DateTime Date_Inscription { get; set; }
        public string Actif { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Utilisateur, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }
    public class CustomUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }

    }
    public class CustomUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
    }
    public class CustomUserClaim : IdentityUserClaim<int>
    {

    }
    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
