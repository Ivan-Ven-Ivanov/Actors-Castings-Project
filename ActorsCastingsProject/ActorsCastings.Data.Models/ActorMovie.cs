using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActorsCastings.Data.Models
{
    [PrimaryKey(nameof(ActorProfileId), nameof(MovieId))]
    public class ActorMovie
    {
        [Required]
        [ForeignKey(nameof(Actor))]
        [Comment("Foreign key to ActorProfile")]
        public Guid ActorProfileId { get; set; }

        [Required]
        public Actor Actor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Movie))]
        [Comment("Foreign key to Movie")]
        public Guid MovieId { get; set; }

        [Required]
        public Movie Movie { get; set; } = null!;
    }
}
