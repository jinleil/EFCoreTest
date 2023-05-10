using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WpfApp.Repository;
using System.Configuration;

namespace WpfApp
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            string connectionString = ConfigurationManager.AppSettings["sqliteConnDev"];

            var builder = new DbContextOptionsBuilder<MyDbContext>()
                    .UseSqlite(connectionString);

            return new MyDbContext(builder.Options);
        }
    }
}