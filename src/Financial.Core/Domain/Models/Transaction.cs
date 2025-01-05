using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Core.Domain.Models.Base;
using Financial.Core.Domain.Models.Enums;

namespace Financial.Core.Domain.Models
{
    public class Transaction : Entity
    {
        
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }

        // FKs
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        // Propriedades de navegação
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
        
    }
}