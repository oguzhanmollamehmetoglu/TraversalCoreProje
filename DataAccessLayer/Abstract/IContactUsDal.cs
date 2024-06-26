﻿using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IContactUsDal : IGenericDal<ContactUS>
    {
        List<ContactUS> GetListContactUsByTrue();
        List<ContactUS> GetListContactUsByFalse();
        void ContactUsStatusChangeToFalse(int id);
    }
}