using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestination()
        {
            using (var c = new Context())
            {
                return c.comments.Include(x => x.Destiantion).ToList();
            }
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using (var c = new Context())
            {
                return c.comments.Where(x => x.DestiantionID == id).Include(x => x.AppUser).ToList();
            }
        }

        public List<Comment> GetListCommentWithDestinationAndAppUser()
        {
            using (var c = new Context())
            {
                return c.comments.Include(x => x.Destiantion).Include(x => x.AppUser).ToList();
            }
        }
    }
}