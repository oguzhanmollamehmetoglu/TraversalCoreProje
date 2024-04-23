using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.reservations.Include(x => x.Destiantion).Where(x => x.Status == "Onaylandı" && x.AppUserID == id).Include(x => x.AppUser).ToList();
            }
        }
        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.reservations.Include(x => x.Destiantion).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserID == id).Include(x => x.AppUser).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitAprroval(int id)
        {
            using (var context = new Context())
            {
                return context.reservations.Include(x => x.Destiantion).Where(x => x.Status == "Onay Bekliyor" && x.AppUserID == id).Include(x => x.AppUser).ToList();
            }
        }

        public List<Reservation> GetListReservationWithDestinationAndAppUser()
        {
            using (var c = new Context())
            {
                return c.reservations.Include(x => x.Destiantion).Include(x => x.AppUser).ToList();
            }
        }
    }
}