using System;
using ApkgEditor;
using ApkgEditor.Structure;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;

namespace MNVideoCardPatch
{
    class Program
    {
        static void Main(string[] args)
        {

            string path;
            Console.WriteLine("Give me file");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = Console.ReadLine();
            else
            {
                path = Regex.Replace(Console.ReadLine(), @"\\([^ ])", "$1");
                path = Regex.Replace(path, @"(?<!\\) ", "");
            }
            FileInfo file = new FileInfo(path);
            try
            {
                AnkiPkg package = new AnkiPkg(file.FullName, null);
                package.Load();
                var optionsBuilder = new DbContextOptionsBuilder<Anki2Context>();
                optionsBuilder.UseSqlite($"Data Source={package.Database.FullName}");
                using (var context = new Anki2Context(optionsBuilder.Options))
                {

                    foreach (Note note in context.Notes)
                    {
                        note.Flds=Regex.Replace(note.Flds, "<video.*?src=\"(.*?)\"[^\\>]+>.*?</video>", "[sound:$1]");
                        Console.WriteLine(note.Flds);
                    }
                    context.SaveChanges();
                }
                
                package.Export(Path.Combine(file.DirectoryName, Path.GetFileNameWithoutExtension(file.Name)+"_patched.apkg"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("执行成功，按回车离开");

        }
    }
}
