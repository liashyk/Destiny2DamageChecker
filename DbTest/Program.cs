using Microsoft.EntityFrameworkCore;
using Destiny2DataLibrary.DataAccess;
namespace DbTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql("Host=localhost;Port=5432;Database=Destiny2DataBase;Username=postgres;Password=10524");
            using (var context = new Destiny2DataContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}