using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public List<Feature> GetListByFeatureAndFeature2()
        {
            using (var c = new Context())
            {
                return c.features.Include(x => x.Feature2).ToList();
            }
        }
    }
}