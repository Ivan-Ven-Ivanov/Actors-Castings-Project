using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ActorsCastings.Common.EntityValidationConstants.ActorPlay;

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
        public Actor Actor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Play))]
        [Comment("Foreign key to Play")]
        public Guid PlayId { get; set; }

        [Required]
        public Play Play { get; set; } = null!;

        [Required]
        [Comment("The role of the actor in the play")]
        [MaxLength(ActorPlayRoleMaxLength)]
        public string Role { get; set; } = null!;
    }
}
