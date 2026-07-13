using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.IO;
namespace Relationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new Data.DataContext();

            DatabaseSeeder(context);
        }
        static void DatabaseSeeder(Data.DataContext context)
        {


            for (int i = 1; i <= 10; i++)
            {
                var character = new Models.Character
                {
                    Name = $"Character {i}",
                    Backpack = new Models.Backpack
                    {
                        Description = $"Backpack for Character {i}"
                    }
                };

                context.Characters.Add(character);
            }

            context.SaveChanges();
        }
    }




}