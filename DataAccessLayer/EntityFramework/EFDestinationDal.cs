using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWhiteGuide(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x => x.DestiantionID == id).Include(y => y.Guide).FirstOrDefault();
            }
        }

        public Destination GetDestinationWhiteReservation(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x => x.DestiantionID == id).Include(y => y.Reservations).FirstOrDefault();
            }
        }

        public List<Destination> GetLastFourDestination()
        {
            using (var context = new Context())
            {
                var values = context.Destinations.Take(4).OrderByDescending(x => x.DestiantionID).ToList();
                return values;
            }
        }
    }
}