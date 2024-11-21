using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ActorsCastings.Common.ApplicationConstants.ActorProfileValidationConstants;

namespace ActorsCastings.Data.Models
{
    public class ActorProfile
    {
        public ActorProfile()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Comment("Actor profile unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("First name of the actor")]
        [MaxLength(ActorFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;


        [Required]
        [Comment("Last name of the actor")]
        [MaxLength(ActorLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Comment("Url of the profile picture of the actor")]
        public string ProfilePictureUrl { get; set; } = null!;

        [Comment("Age of the actor")]
        public int? Age { get; set; }

        [Comment("Portfolio of the actor")]
        [MaxLength(ActorPortfolioMaxLength)]
        public string? Portfolio { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("Foreign key to User")]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public IList<ActorMovie> ActorsMovies { get; set; }
            = new List<ActorMovie>();

        public IList<ActorPlay> ActorsPlays { get; set; }
            = new List<ActorPlay>();

        public IList<ActorCasting> ActorsCastings { get; set; }
            = new List<ActorCasting>();
    }
}
