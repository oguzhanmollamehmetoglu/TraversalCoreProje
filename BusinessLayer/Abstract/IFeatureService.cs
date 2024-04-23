using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        List<Feature> TGetListByFeatureAndFeature2();
    }
}