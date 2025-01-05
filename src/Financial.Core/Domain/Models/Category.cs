using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Core.Domain.Models.Base;
using Financial.Core.Domain.Models.Enums;

namespace Financial.Core.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public CategoryStatus Status { get; set; }

        // Propriedades de navegação
        public ICollection<Transaction> Transactions { get; set; }
        public Budget Budget { get; set; }
        
    }
}