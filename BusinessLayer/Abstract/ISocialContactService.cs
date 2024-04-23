using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISocialContactService : IGenericService<SocialContact>
    {
        void TChangeToTrueBySocialContact(int id);
        void TChangeToFalseBySocialContact(int id);
    }
}