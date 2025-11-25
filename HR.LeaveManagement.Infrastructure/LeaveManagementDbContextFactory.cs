using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HR.LeaveManagement.Infrastructure
{
    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementDbContext>
    {
        public LeaveManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../HR.leaveManagement.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
            var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new LeaveManagementDbContext(builder.Options);
        }
    }
}
