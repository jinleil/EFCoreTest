using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WpfApp.Repository;

namespace WpfApp
{
    public class AutoMigrationHelper
    {
        public static async Task Migration(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>()
               .UseSqlite(connectionString);

            using MyDbContext dbContext = new MyDbContext(builder.Options);

            //执行迁移
            //如果数据库存在并且包含任何表，则不执行任何操作。 不执行任何操作来确保数据库架构与实体框架模型兼容。
            //如果数据库存在但没有任何表，则使用实体框架模型创建数据库架构。
            //如果数据库不存在，则创建数据库并使用实体框架模型创建数据库架构。
            //await dbContext.Database.EnsureCreatedAsync();

            //执行迁移，相当于执行了Update-Database
            await dbContext.Database.MigrateAsync();
        }
    }
}