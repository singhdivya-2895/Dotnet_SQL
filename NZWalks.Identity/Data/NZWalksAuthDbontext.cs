using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.Identity.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleID = "40a32ea6-bae6-480d-a9ca-282707aad8ca";
            var writerRoleID = "3eb4e3f9-64ec-4430-8bfe-d8f03ebc53a0";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = readerRoleID,
                    Name = "Reader",
                    ConcurrencyStamp = readerRoleID,
                    NormalizedName = "Reader".ToUpper()
                },
                 new IdentityRole
                 {
                     Id = writerRoleID,
                     Name = "Writer",
                     ConcurrencyStamp = writerRoleID,
                     NormalizedName = "Writer".ToUpper()
                 }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
