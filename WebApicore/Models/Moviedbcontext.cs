using Microsoft.EntityFrameworkCore;

namespace WebApicore.Models
{
    public class Moviedbcontext:DbContext
    {
        public Moviedbcontext(DbContextOptions<Moviedbcontext> options) : base(options)
        {



        }
        public DbSet<UserInfo> userinfo { get; set; }
        public DbSet<movie> movies { get; set; }
    }
}
