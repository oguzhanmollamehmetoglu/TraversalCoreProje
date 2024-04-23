using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class Feature2Manager : IFeature2Service
    {
        IFeature2Dal _Feature2Dal;

        public Feature2Manager(IFeature2Dal feature2Dal)
        {
            _Feature2Dal = feature2Dal;
        }

        public void TDelete(Feature2 t)
        {
            _Feature2Dal.Delete(t);
        }

        public Feature2 TGetByID(int id)
        {
            return _Feature2Dal.GetByID(id);
        }

        public List<Feature2> TGetList()
        {
            return _Feature2Dal.GetList();
        }

        public void TInsert(Feature2 t)
        {
            _Feature2Dal.Insert(t);
        }

        public void TUpdate(Feature2 t)
        {
            _Feature2Dal.Update(t);
        }
    }
}