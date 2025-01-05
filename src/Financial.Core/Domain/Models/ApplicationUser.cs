using Financial.Core.Domain.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace Financial.Core.Domain.Models

{
    public class ApplicationUser : Entity
    {
        
        //FKs
        public Guid AccountId { get; set; }

        // Propriedade de navegação para Account
        public Account Account { get; set; }
        public IdentityUser UserIdentity { get; set; }

    }
}