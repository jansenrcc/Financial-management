using Financial.Core.Data.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Financial.Core.Extensions
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Financial.Api");

            // Verifica se o caminho é válido
            if (!Directory.Exists(basePath))
            {
                throw new DirectoryNotFoundException($"Diretório não encontrado: {basePath}");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // Caminho base para o appsettings.json
                .AddJsonFile("appsettings.json") // Arquivo de configuração
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada no appsettings.json.");
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}