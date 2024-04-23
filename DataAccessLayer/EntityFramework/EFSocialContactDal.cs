using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFSocialContactDal: GenericRepository<SocialContact>, ISocialContactDal
    {
        Context context = new Context();

        public void ChangeToFalseBySocialContact(int id)
        {
            var values = context.socialContacts.Find(id);
            values.Status = false;
            context.Update(values);
            context.SaveChanges();
        }

        public void ChangeToTrueBySocialContact(int id)
        {
            var values = context.socialContacts.Find(id);
            values.Status = true;
            context.Update(values);
            context.SaveChanges();
        }
    }
}