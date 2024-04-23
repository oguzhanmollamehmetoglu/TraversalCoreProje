using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SocialContactManager : ISocialContactService
    {
        ISocialContactDal _SocialContactDal;

        public SocialContactManager(ISocialContactDal socialContactDal)
        {
            _SocialContactDal = socialContactDal;
        }

        public void TChangeToFalseBySocialContact(int id)
        {
            _SocialContactDal.ChangeToFalseBySocialContact(id);
        }

        public void TChangeToTrueBySocialContact(int id)
        {
            _SocialContactDal.ChangeToTrueBySocialContact(id);
        }

        public void TDelete(SocialContact t)
        {
            _SocialContactDal.Delete(t);
        }

        public SocialContact TGetByID(int id)
        {
            return _SocialContactDal.GetByID(id);
        }

        public List<SocialContact> TGetList()
        {
            return _SocialContactDal.GetList();
        }

        public void TInsert(SocialContact t)
        {
            _SocialContactDal.Insert(t);
        }

        public void TUpdate(SocialContact t)
        {
            _SocialContactDal.Update(t);
        }
    }
}