using Microsoft.EntityFrameworkCore;

namespace Organization.Models
{
    public class CreateOrganizationContext :DbContext
    {
        public CreateOrganizationContext(DbContextOptions<CreateOrganizationContext> options) : base(options) { }
        public DbSet<CreateOrganization> CreateOrganization {  get; set; } = null!;
    }
}
