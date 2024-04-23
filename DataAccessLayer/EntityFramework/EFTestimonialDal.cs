using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public List<Testimonial> GetListByTestimonialAndComment()
        {
            using (var c = new Context())
            {
                return c.testimonials.Include(x => x.Comments).ToList();
            }
        }
    }
}