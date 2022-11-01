using Microsoft.EntityFrameworkCore;
using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;
using Destiny2DataLibrary.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace DbTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context=new Destiny2DataContext())
            {
                var archetype = new Archetype()
                {

                };
            }
        }
    }
}