using System;
using System.Linq;
using OrmLiteExample.DataModels;

namespace OrmLiteExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var repo = new Repositories.NoteRepository())
            {
                // Create new
                repo.Save(
                    new Note
                    {
                        SchemaUri = "tcm:0-0-0",
                        NoteText = "Hello world",
                        LastUpdated = new DateTime(2013, 5, 20),
                        UpdatedBy = "RC"
                    });


                // Read all
                var notes = repo.FindAll();
                foreach (Note note in notes)
                {
                    Console.WriteLine("note id = " + note.Id + ", noteText = " + note.NoteText);
                }
            }

            Console.ReadLine();
        }
    }
}
