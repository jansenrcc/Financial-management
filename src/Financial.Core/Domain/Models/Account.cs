using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Core.Domain.Models.Base;

namespace Financial.Core.Domain.Models
{
    public class Account : Entity
    {        
        public double CurrentBalance { get; set; }

        //FKs
        public Guid UserId { get; set; }
        
        // Propriedade de navegação
        public ApplicationUser User { get; set; }
        
    }
}