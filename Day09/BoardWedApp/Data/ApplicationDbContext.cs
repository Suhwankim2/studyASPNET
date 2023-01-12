using BoardWedApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace BoardWedApp.Data
{
    public class ApplicationDbContext : IdentityDbContext

	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}


		public DbSet<Note> Notes { get; set; }


		public DbSet<BoardWedApp.Models.RegisterModel> RegisterModel { get; set; }
    }
}
