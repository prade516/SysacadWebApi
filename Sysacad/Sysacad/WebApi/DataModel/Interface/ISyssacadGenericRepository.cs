using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataModel.Interface
{
	public interface ISyssacadGenericRepository<TEntity> where TEntity : class
	{
		#region CUD
		void Insert(TEntity entity);
		void Update(TEntity entity, List<string> modifiedfields);
		void Delete(TEntity entity, List<string> modifiedfields);
		#endregion
		#region ReadOne
		TEntity GetById(Int64 ID);
		TEntity GetOneByFilters(Expression<Func<TEntity, bool>> where, params string[] include);
		#endregion
		#region ReadAll
		IQueryable<TEntity> GetAll();
		IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include);

		#endregion
	}
}
