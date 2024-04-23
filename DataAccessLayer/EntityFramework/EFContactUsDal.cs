using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactUsDal : GenericRepository<ContactUS>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUS> GetListContactUsByFalse()
        {
            using (var context = new Context())
            {
                var values = context.contactUses.Where(x => x.ContactUsStatus == false).ToList();
                return values;
            }
        }

        public List<ContactUS> GetListContactUsByTrue()
        {
            using (var context = new Context())
            {
                var values = context.contactUses.Where(x => x.ContactUsStatus == true).ToList();
                return values;
            }
        }
    }
}