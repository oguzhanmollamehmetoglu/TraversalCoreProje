using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Newslater
    {
        [Key]
        public int NewslaterID { get; set; }

        public string Mail { get; set; }
    }
}