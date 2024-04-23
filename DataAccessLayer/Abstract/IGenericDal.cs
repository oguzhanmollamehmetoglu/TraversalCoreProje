using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
        //Arama işlemi gerçekleştirmek için
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}