#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace DataModel.GenericRepository
{
    /// <summary>
    /// Generic Repository class for Entity Operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
		#region Member
		internal SysacadContext dbcontext;
		internal DbSet<TEntity> dbSet;
		#endregion
		#region Contructor
		public GenericRepository(SysacadContext context)
		{
			this.dbcontext = context;
			this.dbSet = context.Set<TEntity>();
		}
		#endregion
		#region CUD
		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}
		public virtual void Update(TEntity entity, List<string> modifiedfields)
		{
			dbcontext.Entry<TEntity>(entity).State = EntityState.Unchanged;
			foreach (string var in modifiedfields)
			{
				dbcontext.Entry<TEntity>(entity).Property(var).IsModified = true;
			}
		}
		public virtual void Delete(TEntity entity, List<string> modifiedfields)
		{
			this.Update(entity, modifiedfields);
		}


		#endregion
		#region ReadOne
		public virtual TEntity GetById(Int64 ID)
		{
			return dbSet.Find(ID);
		}

		public virtual TEntity GetOneByFilters(Expression<Func<TEntity, bool>> where, params string[] include)
		{
			IQueryable<TEntity> query = this.dbSet;
			if (include != null)
				query = include.Aggregate(query, (current, inc) => current.Include(inc));
			if (where != null)
				query = query.Where(where);
			return query.FirstOrDefault<TEntity>();
		}

		#endregion
		#region ReadAll
		public virtual IQueryable<TEntity> GetAll()
		{
			IQueryable<TEntity> query = dbSet;
			return query;
		}

		public virtual IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include)
		{
			IQueryable<TEntity> query = this.dbSet;
			if (include != null)
				query = include.Aggregate(query, (current, inc) => current.Include(inc));
			if (where != null)
				query = query.Where(where);
			return query;
		}
		#endregion
	}
}