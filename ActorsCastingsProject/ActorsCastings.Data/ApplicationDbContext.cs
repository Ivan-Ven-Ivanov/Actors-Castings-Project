using ActorsCastings.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

            SeedDataFromJson(builder);
        }

        private void SeedDataFromJson(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(LoadData<ApplicationUser>("SeedData/applicationUsers.json"));
            modelBuilder.Entity<Actor>().HasData(LoadData<Actor>("SeedData/actors.json"));
            modelBuilder.Entity<CastingAgent>().HasData(LoadData<CastingAgent>("SeedData/castingAgents.json"));
            modelBuilder.Entity<Movie>().HasData(LoadData<Movie>("SeedData/movies.json"));
            modelBuilder.Entity<Play>().HasData(LoadData<Play>("SeedData/plays.json"));
            modelBuilder.Entity<Casting>().HasData(LoadData<Casting>("SeedData/castings.json"));
            modelBuilder.Entity<ActorMovie>().HasData(LoadData<ActorMovie>("SeedData/actorsMovies.json"));
            modelBuilder.Entity<ActorPlay>().HasData(LoadData<ActorPlay>("SeedData/actorsPlays.json"));
        }

        private List<T> LoadData<T>(string filePath)
            where T : class
        {
            string fullPath = Path.Combine("../ActorsCastings.Data", filePath);
            string jsonData = File.ReadAllText(fullPath);

            return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
    }
}
