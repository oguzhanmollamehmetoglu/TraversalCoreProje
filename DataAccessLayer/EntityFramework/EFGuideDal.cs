using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFGuideDal : GenericRepository<Guide>, IGuideDal
    {
        Context context = new Context();

        public void ChangeToFalseByGuide(int id)
        {
            var values = context.guides.Find(id);
            values.Status = false;
            context.Update(values);
            context.SaveChanges();
        }

        public void ChangeToTrueByGuide(int id)
        {
            var values = context.guides.Find(id);
            values.Status = true;
            context.Update(values);
            context.SaveChanges();
        }

        public List<Guide> GetListGuideWithAppUser()
        {
            using (var c = new Context())
            {
                return c.guides.Include(x => x.AppUser).ToList();
            }
        }

        public List<Guide> GetLastSixGuide()
        {
            using (var context = new Context())
            {
                var values = context.guides.Take(6).OrderByDescending(x => x.GuideID).ToList();
                return values;
            }
        }
    }
}