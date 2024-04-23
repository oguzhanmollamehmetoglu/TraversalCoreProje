using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _CommentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _CommentDal = commentDal;
        }

        public void TDelete(Comment t)
        {
            _CommentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _CommentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _CommentDal.GetList();
        }

        public List<Comment> TGetDestinationById(int id)
        {
            return _CommentDal.GetListByFilter(x => x.DestiantionID == id);
        }

        public void TInsert(Comment t)
        {
            _CommentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _CommentDal.Update(t);
        }

        public void TAdd(Comment p)
        {
            _CommentDal.Insert(p);
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _CommentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListCommentWithDestinationAndUser(int id)
        {
            return _CommentDal.GetListCommentWithDestinationAndUser(id);
        }

        public List<Comment> TGetListCommentWithDestinationAndAppUser()
        {
            return _CommentDal.GetListCommentWithDestinationAndAppUser();
        }
    }
}