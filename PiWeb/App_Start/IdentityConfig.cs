using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Exam.Domain.Entities;
using Exam.Data;
using System;

namespace WebApi
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<Utilisateur, int>
    {
        public ApplicationUserManager(IUserStore<Utilisateur, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<Utilisateur, int>(context.Get<ExamContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Utilisateur, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<Utilisateur, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        private class UserStore<T1, T2> : IUserStore<Utilisateur, int>
        {
            private ExamContext examContext;

            public UserStore(ExamContext examContext)
            {
                this.examContext = examContext;
            }

            public Task CreateAsync(Utilisateur user)
            {
                throw new NotImplementedException();
            }

            public Task DeleteAsync(Utilisateur user)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public Task<Utilisateur> FindByIdAsync(int userId)
            {
                throw new NotImplementedException();
            }

            public Task<Utilisateur> FindByNameAsync(string userName)
            {
                throw new NotImplementedException();
            }

            public Task UpdateAsync(Utilisateur user)
            {
                throw new NotImplementedException();
            }
        }
       
    }
}
