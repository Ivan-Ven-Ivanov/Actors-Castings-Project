using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ActorsCastings.Common.EntityValidationConstants.ActorMovie;

namespace ActorsCastings.Data.Models
{
    [PrimaryKey(nameof(ActorId), nameof(MovieId))]
    public class ActorMovie
    {
        [Required]
        [ForeignKey(nameof(Actor))]
        [Comment("Foreign key to Actor")]
        public Guid ActorId { get; set; }

        [Required]
        public Actor Actor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Movie))]
        [Comment("Foreign key to Movie")]
        public Guid MovieId { get; set; }

        [Required]
        public Movie Movie { get; set; } = null!;

        [Comment("The role of the actor in the movie")]
        [MaxLength(ActorMovieRoleMaxLength)]
        public string? Role { get; set; }

        [Required]
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Is the part of the actor in the movie approved by Admin")]
        public bool IsApproved { get; set; }
    }
}
