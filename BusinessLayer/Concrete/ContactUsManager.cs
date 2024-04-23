using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TContactUsStatusChangeToFalse(int id)
        {
            _contactUsDal.ContactUsStatusChangeToFalse(id);
        }

        public void TDelete(ContactUS t)
        {
            _contactUsDal.Delete(t);
        }

        public ContactUS TGetByID(int id)
        {
            return _contactUsDal.GetByID(id);
        }

        public List<ContactUS> TGetList()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUS> TGetListContactUsByFalse()
        {
            return _contactUsDal.GetListContactUsByFalse();
        }

        public List<ContactUS> TGetListContactUsByTrue()
        {
            return _contactUsDal.GetListContactUsByTrue();
        }

        public void TInsert(ContactUS t)
        {
            _contactUsDal.Insert(t);
        }

        public void TUpdate(ContactUS t)
        {
            _contactUsDal.Update(t);
        }
    }
}