using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=OGUZHAN;initial catalog=TraversalDb;integrated Security=true");
		}

		public DbSet<About> abouts { get; set; }

		public DbSet<Contact> contacts { get; set; }

		public DbSet<Destination> Destinations { get; set; }

		public DbSet<Feature> features { get; set; }

		public DbSet<Feature2> feature2s { get; set; }

		public DbSet<Guide> guides { get; set; }

		public DbSet<Newslater> newslaters { get; set; }

		public DbSet<SubAbout> subAbouts { get; set; }

		public DbSet<Testimonial> testimonials { get; set; }

		public DbSet<Comment> comments { get; set; }

        public DbSet<Reservation> reservations { get; set; }

        public DbSet<ContactUS> contactUses { get; set; }

        public DbSet<Announcement> announcements { get; set; }

        public DbSet<Account> accounts { get; set; }

        public DbSet<SocialContact> socialContacts { get; set; }
    }
}