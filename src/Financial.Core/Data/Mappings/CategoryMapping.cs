using Financial.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Financial.Core.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            // Definir nome da tabela
            builder.ToTable("Categories");

            // Chave primária
            builder.HasKey(c => c.Id);

            // Propriedade Name
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Propriedade Status
            builder.Property(c => c.Status)
                   .IsRequired()
                   .HasConversion<int>();

            // Relação 1:N com Transaction
            builder.HasMany(c => c.Transactions)
                   .WithOne(t => t.Category) 
                   .HasForeignKey(t => t.CategoryId) 
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
