using Financial.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Core.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            
            builder.ToTable("UserAccounts");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User) 
                  .WithOne(u => u.Account) 
                  .HasForeignKey<Account>(a => a.UserId) 
                  .OnDelete(DeleteBehavior.Cascade); // Deletar account ao excluir usuário

            builder.Property(a => a.CurrentBalance)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)"); // Configuração para valores monetários
        }
    }
}
