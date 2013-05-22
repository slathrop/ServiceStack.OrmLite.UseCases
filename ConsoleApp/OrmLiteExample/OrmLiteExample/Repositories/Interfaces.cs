using System;
using System.Data;
using ServiceStack.OrmLite;

namespace OrmLiteExample.Repositories
{
    public interface IReadOnlyRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Get(TKey id);
    }

    public interface IRepository<TEntity, in TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// Save should perform an "Upsert", inserting/creating a new entity when it doesn't already exist, and
        /// updating it when it does already exist
        /// </summary>
        /// <param name="entity"></param>
        void Save(TEntity entity);

        void Delete(TEntity entity);
    }

    public interface IDbRepository<TEntity, in TKey> : IDisposable, IRepository<TEntity, TKey> where TEntity : class
    {
        IDbConnectionFactory dbFactory { get; }
        IDbConnection db { get; }
    }


}
