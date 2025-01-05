using Financial.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Financial.Core.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
        {
            // Definir nome da tabela
            builder.ToTable("ApplicationUsers");
            
            // Configurar chave primária
            builder.HasKey(u => u.Id);

            // Configurar relação com IdentityUser 
            builder.HasOne(u => u.UserIdentity)
                   .WithMany()
                   .HasForeignKey("UserIdentityId")
                   .OnDelete(DeleteBehavior.Cascade); // Deleta ApplicationUser ao excluir IdentityUser

            // Configurar AccountId como obrigatório
            builder.Property(u => u.AccountId)
                   .IsRequired();
        }
    }
}