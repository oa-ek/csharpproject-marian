using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace TeamManager.Core.Contrext
{
    public class ProjectContext : IdentityDbContext 
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) 
            :base(options)
        { }
    }
}
