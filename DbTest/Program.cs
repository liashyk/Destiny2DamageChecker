using Microsoft.EntityFrameworkCore;
using Destiny2DataLibrary.DataAccess;
namespace DbTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Destiny2DataContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}