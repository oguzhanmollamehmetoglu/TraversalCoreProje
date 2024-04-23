using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void TDelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination TGetByID(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public void TInsert(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void TAdd(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void TUpdate(Destination t)
        {
            _destinationDal.Update(t);
        }

        public Destination TGetDestinationWhiteGuide(int id)
        {
            return _destinationDal.GetDestinationWhiteGuide(id);
        }

        public List<Destination> TGetLastFourDestination()
        {
            return _destinationDal.GetLastFourDestination();
        }

        public Destination TGetDestinationWhiteReservation(int id)
        {
            return _destinationDal.GetDestinationWhiteReservation(id);
        }
    }
}