using System;
using ServiceStack.DataAnnotations;

namespace OrmLiteExample.DataModels
{
    class Note
    {
        [AutoIncrement] // Creates Auto primary key
        public int Id { get; set; }

        public string SchemaUri { get; set; }
        public string NoteText { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
