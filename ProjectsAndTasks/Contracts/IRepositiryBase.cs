using System.Linq.Expressions;

namespace ProjectsAndTasks.Contracts
{
	public interface IRepositiryBase<T>
	{
		IQueryable<T> FindAll(bool trackChanges);

		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

		void Create(T entity);

		void Update(T entity);

		void Delete(T entity);
	}
}
