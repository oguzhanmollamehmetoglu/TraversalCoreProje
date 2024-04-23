using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ISocialContactDal:IGenericDal<SocialContact>
    {
        void ChangeToTrueBySocialContact(int id);
        void ChangeToFalseBySocialContact(int id);
    }
}