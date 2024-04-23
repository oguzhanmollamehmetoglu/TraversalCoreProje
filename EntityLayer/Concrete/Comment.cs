using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public string CommentUser { get; set; }

        public DateTime CommentDate { get; set; }

        public string CommentContent { get; set; }

        public bool CommentStatus { get; set; }

        public int DestiantionID { get; set; }

        public Destination Destiantion { get; set; }

        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }
    }
}