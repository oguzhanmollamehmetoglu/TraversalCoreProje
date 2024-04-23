using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewslaterManager : INewslaterService
    {
        INewsLaterDal _newsLaterDal;

        public NewslaterManager(INewsLaterDal newsLaterDal)
        {
            _newsLaterDal = newsLaterDal;
        }

        public void TDelete(Newslater t)
        {
            _newsLaterDal.Delete(t);
        }

        public Newslater TGetByID(int id)
        {
            return _newsLaterDal.GetByID(id);
        }

        public List<Newslater> TGetList()
        {
            return _newsLaterDal.GetList();
        }

        public void TInsert(Newslater t)
        {
            _newsLaterDal.Insert(t);
        }

        public void TUpdate(Newslater t)
        {
            _newsLaterDal.Update(t);
        }
    }
}