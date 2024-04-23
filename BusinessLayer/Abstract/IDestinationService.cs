using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        public Destination TGetDestinationWhiteGuide(int id);
        public Destination TGetDestinationWhiteReservation(int id);
        public List<Destination> TGetLastFourDestination();
    }
}