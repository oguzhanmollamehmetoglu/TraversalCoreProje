using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        IGuideDal _GuideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _GuideDal = guideDal;
        }

        public void TChangeToFalseByGuide(int id)
        {
            _GuideDal.ChangeToFalseByGuide(id);
        }

        public void TChangeToTrueByGuide(int id)
        {
            _GuideDal.ChangeToTrueByGuide(id);
        }

        public void TDelete(Guide t)
        {
            _GuideDal.Delete(t);
        }

        public Guide TGetByID(int id)
        {
            return _GuideDal.GetByID(id);
        }

        public List<Guide> TGetLastSixGuide()
        {
            return _GuideDal.GetLastSixGuide();
        }

        public List<Guide> TGetList()
        {
            return _GuideDal.GetList();
        }

        public List<Guide> TGetListGuideWithAppUser()
        {
            return _GuideDal.GetListGuideWithAppUser();
        }

        public void TInsert(Guide t)
        {
            _GuideDal.Insert(t);
        }

        public void TUpdate(Guide t)
        {
            _GuideDal.Update(t);
        }
    }
}