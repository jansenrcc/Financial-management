using Financial.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Financial.Core.Data.Mappings
{
    public class BudgetMapping : IEntityTypeConfiguration<Budget>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Budget> builder)
        {
            // Definir nome da tabela
            builder.ToTable("Budgets");

            // Configurar chave primária
            builder.HasKey(b => b.Id);

            // Configurar propriedade BudgetLimit
            builder.Property(b => b.BudgetLimit)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)"); // Configuração para valores monetários

            // Configurar relação com Category
            builder.HasOne(b => b.Category) 
                   .WithOne(c => c.Budget) 
                   .HasForeignKey<Budget>(b => b.CategoryId) // FK obrigatória
                   .OnDelete(DeleteBehavior.Restrict); // Não permite exclusão em cascata

            // Configurar relação com ApplicationUser
            builder.HasOne(b => b.User)
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // Excluir budgets ao excluir usuário
        }
    }
}
