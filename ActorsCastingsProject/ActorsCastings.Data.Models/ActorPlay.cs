using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActorsCastings.Data.Models
{
    [PrimaryKey(nameof(ActorProfileId), nameof(PlayId))]
    public class ActorPlay
    {
        [Required]
        [ForeignKey(nameof(Actor))]
        [Comment("Foreign key to ActorProfile")]
        public Guid ActorProfileId { get; set; }

        [Required]
        public ActorProfile Actor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Play))]
        [Comment("Foreign key to Play")]
        public Guid PlayId { get; set; }

        [Required]
        public Play Play { get; set; } = null!;
    }
}
