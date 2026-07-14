using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.IO;
using Relationen.Data;
using Relationen.Models;
namespace Relationen
{
    public class Program
    {
        static void Main(string[] args)
        {
            // using Microsoft.EntityFrameworkCore;

            using var dbContext = new Data.DataContext();

            var c = dbContext.Characters.Find(1);
            Console.WriteLine(c?.Name);
            Console.WriteLine(c?.Id);


            // neuen Character erstellen und in die DB speichern

            // var cIN = new Character { Name = "Test" };
            // dbContext.Characters.Add(cIN);
            // dbContext.SaveChanges();
            // Console.WriteLine("Character added to the database.");
            // Console.WriteLine(cIN.Name);
            // Console.WriteLine(cIN.Id);

            // Neuen Backback erstellen und mit Character verknüpfen

            // var bin = new Backpack { Description = "Eastpack", CharacterId = 1 };
            // dbContext.Backpacks.Add(bin);
            // dbContext.SaveChanges();
            // Console.WriteLine(bin.Description);
            // Console.WriteLine(bin.Id);

            var allCharacters = dbContext.Characters.Include(c => c.Backpack).ToList();
            foreach (var character in allCharacters)
            {
                Console.WriteLine($"ID: {character.Id}, Name: {character.Name} Backpack Description: {character.Backpack?.Description}");

            }

            // var kleinsteId = dbContext.Characters.Min(c => c.Id);
            // Console.WriteLine($"Kleinste ID: {kleinsteId}");

            // var groessteId = dbContext.Characters.Max(c => c.Id);
            // Console.WriteLine($"Größte ID: {groessteId}");

            // var allBackpacks = dbContext.Backpacks.ToList();
            // foreach (var backpack in allBackpacks)
            // {
            //     Console.WriteLine($"ID: {backpack.Id}, Description: {backpack.Description}, CharacterId: {backpack.CharacterId}");
            // }
            // Alle Characters mit ihren zugehörigen Backpacks abrufen
            // var allWeapons = dbContext.Weapons.Include(w => w.Character).ToList();
            // foreach (var weapon in allWeapons)
            // {
            //     Console.WriteLine($"ID: {weapon.Id}, Name: {weapon.Name}, CharacterId: {weapon.CharacterId}, Character Name: {weapon.Character?.Name}");
            // }
            // Alle Characters mit ihren zugehörigen Weapons abrufen
            // var allCharactersWithWeapons = dbContext.Characters.Include(c => c.Weapons).ToList();
            // foreach (var character in allCharactersWithWeapons)
            // {
            //     Console.WriteLine($"ID: {character.Id}, Name: {character.Name}");
            //     foreach (var weapon in character.Weapons ?? Enumerable.Empty<Weapons>())
            //     {
            //         Console.WriteLine($"  Weapon ID: {weapon.Id}, Name: {weapon.Name}");
            //     }
            // }

            // 20 neue Characters mit zufälligen Namen erstellen
            var random = new Random();
            var firstNames = new[] { "Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas", "Henry", "Alexander",
                "Mason", "Michael", "Ethan", "Daniel", "Jacob", "Logan", "Jackson", "Levi", "Sebastian", "Mateo",
                "Jack", "Owen", "Theodore", "Aiden", "Samuel", "Joseph", "John", "David", "Wyatt", "Matthew",
                "Luke", "Asher", "Carter", "Julian", "Grayson", "Leo", "Jayden", "Gabriel", "Isaac",
                // Füge hier weitere Namen hinzu, um die Liste auf 100 zu erweitern
                // ...
            };

            for (int i = 0; i < 20; i++)
            {
                var randomName = firstNames[random.Next(firstNames.Length)];
                var newCharacter = new Character { Name = randomName };
                dbContext.Characters.Add(newCharacter);
            }
            dbContext.SaveChanges();
            Console.WriteLine("20 neue Characters wurden hinzugefügt.");

            // var random = new Random();
            // var weaponNames = new[] { "Sword", "Bow", "Axe", "Dagger", "Staff", "Mace", "Spear", "Crossbow", "Hammer", "Flail", "Katana", "Scimitar", "Rapier", "Halberd", "Whip", "Club", "Morning Star", "Trident", "Throwing Knives", "Blowgun" };

            // for (int i = 0; i < 20; i++)
            // {
            //     var randomName = weaponNames[random.Next(weaponNames.Length)];
            //     var randomCharacterId = dbContext.Characters.OrderBy(c => Guid.NewGuid()).Select(c => c.Id).FirstOrDefault();
            //     var newWeapon = new Weapons { Name = randomName, CharacterId = randomCharacterId };
            //     dbContext.Weapons.Add(newWeapon);
            // }
            // dbContext.SaveChanges();
            // Console.WriteLine("20 neue Weapons wurden hinzugefügt.");

            // var random = new Random();
            // var backpackDescriptions = new[] { "Eastpack", "Northface", "Deuter", "Osprey", "Fjällräven", "Gregory", "Patagonia", "Arc'teryx", "The North Face", "Columbia" };
            // for (int i = 0; i < 20; i++)
            // {
            //     var randomDescription = backpackDescriptions[random.Next(backpackDescriptions.Length)];
            //     var randomCharacterId = dbContext.Characters.OrderBy(c => Guid.NewGuid()).Select(c => c.Id).FirstOrDefault();
            //     var newBackpack = new Backpack { Description = randomDescription, CharacterId = randomCharacterId };
            //     dbContext.Backpacks.Add(newBackpack);
            // }
            // dbContext.SaveChanges();
            // Console.WriteLine("20 neue Backpacks wurden hinzugefügt.");

            // Jedem Character einen Backpack zuweisen
            // var backpackDescriptions = new[] { "Eastpack", "Northface", "Deuter", "Osprey", "Fjällräven", "Gregory", "Patagonia", "Arc'teryx", "Columbia", "Salewa" };
            // var random = new Random();
            // var charactersWithoutBackpack = dbContext.Characters.Where(c => c.Backpack == null).ToList();

            // foreach (var character in charactersWithoutBackpack)
            // {
            //     var randomDescription = backpackDescriptions[random.Next(backpackDescriptions.Length)];
            //     var newBackpack = new Backpack { Description = randomDescription, CharacterId = character.Id };
            //     dbContext.Backpacks.Add(newBackpack);
            // }
            // dbContext.SaveChanges();
            // Console.WriteLine($"{charactersWithoutBackpack.Count} Characters wurden Backpacks zugewiesen.");

            // var allCharactersWithBackpacks = dbContext.Characters.Include(c => c.Backpack).ToList();
            // foreach (var character in allCharactersWithBackpacks)
            // {
            //     Console.WriteLine($"ID: {character.Id}, Name: {character.Name}, Backpack Description: {character.Backpack?.Description}");
            // }
            // Console.WriteLine();
            // Console.WriteLine("Alle Characters mit ihren zugehörigen Backpacks wurden abgerufen.");

            // var allWeapons = dbContext.Weapons.Include(w => w.Character).ToList();
            // foreach (var weapon in allWeapons)
            // {
            //     Console.WriteLine($"ID: {weapon.Id}, Name: {weapon.Name}, CharacterId: {weapon.CharacterId}, Character Name: {weapon.Character?.Name}");
            // }
            // Console.WriteLine();

            // // Update: Alle Backpacks mit "Eastpack" umbenennen in "Updatepack"
            // var backpacksToUpdate = dbContext.Backpacks.Where(b => b.Description == "Eastpack").ToList();
            // foreach (var backpack in backpacksToUpdate)
            // {
            //     backpack.Description = "Updatepack";
            // }
            // dbContext.SaveChanges();
            // Console.WriteLine($"{backpacksToUpdate.Count} Backpacks wurden aktualisiert.");
            // Console.WriteLine();

            // Remove: Alle Backpacks mit "Wastpack" löschen
            // var backpacksToDelete = dbContext.Backpacks.Where(b => b.Description == "Eastpack").ToList();
            // foreach (var backpack in backpacksToDelete)
            // {
            //     dbContext.Backpacks.Remove(backpack);
            // }
            // dbContext.SaveChanges();
            // Console.WriteLine($"{backpacksToDelete.Count} Backpacks wurden gelöscht.");
            // Console.WriteLine();

            // var allBackpacksAfterUpdate = dbContext.Backpacks.ToList();
            // foreach (var backpack in allBackpacksAfterUpdate)
            // {
            //     Console.WriteLine($"ID: {backpack.Id}, Description: {backpack.Description}, CharacterId: {backpack.CharacterId}");
            // }


            // var characterDelete = dbContext.Characters.FirstOrDefault(c => c.Name == "Test");
            // if (characterDelete != null)
            // {
            //     dbContext.Characters.Remove(characterDelete);
            //     dbContext.SaveChanges();
            //     Console.WriteLine($"Character with Name 'Test' wurde gelöscht.");
            // }

            // Doppelte Einträge löschen (behalte nur einen pro Name)
            //         var groupedCharacters = dbContext.Characters
            // .ToList()
            // .GroupBy(c => c.Name)
            // .Where(g => g.Count() > 1)
            // .ToList();

            //         foreach (var group in groupedCharacters)
            //         {
            //             var characterToKeep = group.First();
            //             var charactersToDelete = group.Skip(1).ToList();

            //             foreach (var character in charactersToDelete)
            //             {
            //                 var weapons = dbContext.Weapons
            //                     .Where(w => w.CharacterId == character.Id)
            //                     .ToList();

            //                 foreach (var weapon in weapons)
            //                 {
            //                     weapon.CharacterId = characterToKeep.Id;
            //                 }

            //                 dbContext.Characters.Remove(character);
            //             }
            //         }

            //         dbContext.SaveChanges();

            var allCharactersAfterDeletion = dbContext.Characters.ToList();
            Console.WriteLine("Alle Characters nach dem Löschen von Duplikaten:");
            foreach (var character in allCharactersAfterDeletion)
            {
                Console.WriteLine($"ID: {character.Id}, Name: {character.Name}");
            }
        }

    }




}