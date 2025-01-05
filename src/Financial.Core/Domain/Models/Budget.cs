using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Core.Domain.Models.Base;

namespace Financial.Core.Domain.Models
{
    public class Budget : Entity
    {
        public double BudgetLimit { get; set; }

        // FKs
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        // Propriedades de navegação
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }

    }
}