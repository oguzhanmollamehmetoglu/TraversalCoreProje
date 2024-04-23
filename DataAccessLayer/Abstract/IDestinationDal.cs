using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        public Destination GetDestinationWhiteGuide(int id);
        public Destination GetDestinationWhiteReservation(int id);
        public List<Destination> GetLastFourDestination();
    }
}