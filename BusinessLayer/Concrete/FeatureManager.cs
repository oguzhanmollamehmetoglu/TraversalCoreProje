using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void TDelete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public Feature TGetByID(int id)
        {
            return _featureDal.GetByID(id);
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList();
        }

        public List<Feature> TGetListByFeatureAndFeature2()
        {
            return _featureDal.GetListByFeatureAndFeature2();
        }

        public void TInsert(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TUpdate(Feature t)
        {
            _featureDal.Update(t);
        }
    }
}