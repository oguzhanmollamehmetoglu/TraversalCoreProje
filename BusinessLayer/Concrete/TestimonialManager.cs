using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _TestimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _TestimonialDal = testimonialDal;
        }

        public void TDelete(Testimonial t)
        {
            _TestimonialDal.Delete(t);
        }

        public Testimonial TGetByID(int id)
        {
            return _TestimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
            return _TestimonialDal.GetList();
        }

        public List<Testimonial> TGetListByTestimonialAndComment()
        {
            return _TestimonialDal.GetListByTestimonialAndComment();
        }

        public void TInsert(Testimonial t)
        {
            _TestimonialDal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _TestimonialDal.Update(t);
        }
    }
}