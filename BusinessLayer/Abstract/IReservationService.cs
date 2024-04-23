using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> TGetListWithReservationByWaitAprroval(int id);
        List<Reservation> TGetListWithReservationByPrevious(int id);
        List<Reservation> TGetListWithReservationByAccepted(int id);
        List<Reservation> TGetListReservationWithDestinationAndAppUser();
    }
}