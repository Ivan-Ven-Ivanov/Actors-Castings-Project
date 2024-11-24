using ActorsCastings.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<CastingAgent> CastingAgents { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Play> Plays { get; set; }
        public virtual DbSet<Casting> Castings { get; set; }
        public virtual DbSet<ActorCasting> ActorsCastings { get; set; }
        public virtual DbSet<ActorMovie> ActorsMovies { get; set; }
        public virtual DbSet<ActorPlay> ActorsPlays { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
