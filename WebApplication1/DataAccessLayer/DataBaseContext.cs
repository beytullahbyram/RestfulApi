using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataAccessLayer
{
	public class DataBaseContext : DbContext
	{
		public DataBaseContext(DbContextOptions<DataBaseContext> opts) : base(opts)
		{

		}

		public DbSet<Posts> posts { get; set; }

	}
}
