using Microsoft.EntityFrameworkCore;
using TesteAPI.Model;

namespace TesteAPI.Infra
{
	public class ConnectionContext : DbContext
	{
		public DbSet<Usuarios> Usuarios { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
				optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Sistema;Trusted_Connection=True;Encrypt=false");
			}
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder =>
					{
						builder.WithOrigins("http://127.0.0.1:5500")
							   .AllowAnyHeader()
							   .AllowAnyMethod();
					});
			});

		}
	}
}
