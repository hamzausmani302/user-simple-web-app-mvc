using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models;
namespace WebApplication1.Context
{
    public class DataContext : DbContext
    {
        

        public DbSet<User>? Users { get; set; }
        private readonly IConfiguration configuration;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration config , Microsoft.AspNetCore.Hosting.IHostingEnvironment environment) : base(options)
        {
            _environment = environment;
            configuration = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            List<string> availableServers = new() { "DevelopmentDB", "ProdDB" };
            // in memory database used for simplicity, change to a real db for production applications
            string serverAlias = availableServers[0];
            if (!_environment.IsDevelopment())
            {
                serverAlias = availableServers[1];
            }
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(serverAlias));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
