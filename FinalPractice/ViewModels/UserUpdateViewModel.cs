using DomainLayer.Models;
using Infracstructure.DAL;
using System.Collections.Generic;

namespace FinalPractice.ViewModels
{
    public class UserUpdateViewModel
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    Mapper.Map<ApplicationUser, UserUpdateViewModel>(this);
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}

        public ApplicationUser User { get; set; }

        public List<Country> Countries { get; set; }
        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public string Address1 { get; set; }

        //public string Address2 { get; set; }

        //public string City { get; set; }

        //public string State { get; set; }

        //public string Country { get; set; }

        //public string Logo { get; set; }

        //public DateTime? DOB { get; set; }
    }
}