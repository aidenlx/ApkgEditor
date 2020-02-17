using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using ApkgEditor.Structure;
using ApkgEditor;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AnkiPkg package = new AnkiPkg(@"C:\Users\AidenPC\Desktop\解剖");
            package.Load();
            var optionsBuilder = new DbContextOptionsBuilder<Anki2Context>();
            optionsBuilder.UseSqlite($"Data Source={package.Database.FullName}");
            using (var context = new Anki2Context(optionsBuilder.Options))
            {
                long index = 1;
                var col=context.Col.Find(index);
                Console.WriteLine(col.Decks[0].Name);
                col.Decks[0].Name = "Haha";
                context.SaveChanges();
            }
            Console.WriteLine("write test");

        }
    }
}
