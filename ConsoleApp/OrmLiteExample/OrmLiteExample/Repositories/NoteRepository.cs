using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ServiceStack.OrmLite;
using OrmLiteExample.DataModels;

namespace OrmLiteExample.Repositories
{
    interface INoteRepository : IDbRepository<Note, int>
    {
        IEnumerable<Note> FindAll();
    }

    class NoteRepository : INoteRepository
    {
        #region Initialization and Cleanup
        //private readonly string SqliteMemoryDb = ":memory:";
        private readonly string SqliteFileDb = "db.sqlite"; //.MapAbsolutePath();

        IDbConnectionFactory _dbFactory;
        public IDbConnectionFactory dbFactory
        {
            get { return _dbFactory ?? (_dbFactory = new OrmLiteConnectionFactory(SqliteFileDb, false, SqliteDialect.Provider)); }
        }

        IDbConnection _db;
        public IDbConnection db
        {
            get { return _db ?? (_db = dbFactory.Open()); }
        }

        public NoteRepository()
        {
            db.CreateTableIfNotExists<DataModels.Note>();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }
        #endregion

        #region IDbRepository
        public Note Get(int key)
        {
            return db.GetByIdParam<Note>(key);
        }

        public void Save(Note note)
        {
            db.Save<Note>(note);
        }

        public void Delete(Note note)
        {
            db.DeleteByIdParam<Note>(note.Id);
        }
        #endregion

        #region INoteRepository
        public IEnumerable<Note> FindAll()
        {
            return db.Select<Note>();
        }
        #endregion
    }
}
