using Bibliosharp_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bibliosharp_API.Data {
    public class ApplicationDbContext: IdentityDbContext<Admin> {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

    }
}
