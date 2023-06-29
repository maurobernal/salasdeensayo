using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace front.Identity;

public class IdentityContext : IdentityDbContext<IdentityUserDTO>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
              : base(options)
    {
    }


}
