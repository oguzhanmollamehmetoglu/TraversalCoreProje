using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IFeatureDal : IGenericDal<Feature>
    {
        List<Feature> GetListByFeatureAndFeature2();
    }
}