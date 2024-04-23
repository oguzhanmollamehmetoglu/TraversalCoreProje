using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }

        public string CommentListLokasyon { get; set; }

        public List<Comment> Comments { get; set; }
    }
}