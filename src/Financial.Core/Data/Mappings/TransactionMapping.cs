using Financial.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Core.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // Definir nome da tabela
            builder.ToTable("Transactions");

            // Configurar a chave primária
            builder.HasKey(t => t.Id);

            // Configurar a propriedade Description
            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(255); 

            // Configurar a propriedade Amount
            builder.Property(t => t.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)"); 

            // Configurar a propriedade TransactionDate
            builder.Property(t => t.TransactionDate)
                   .IsRequired();

            // Configurar a propriedade TransactionType como enum
            builder.Property(t => t.TransactionType)
                   .IsRequired()
                   .HasConversion<int>(); 

            // Configurar o relacionamento com Category
            builder.HasOne(t => t.Category)
                   .WithMany(c => c.Transactions) 
                   .HasForeignKey(t => t.CategoryId) 
                   .OnDelete(DeleteBehavior.Restrict); 

            // Configurar o relacionamento com ApplicationUser
            builder.HasOne(t => t.User)
                   .WithMany() 
                   .HasForeignKey(t => t.UserId) 
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}