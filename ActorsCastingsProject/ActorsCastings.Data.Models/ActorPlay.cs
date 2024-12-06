using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ActorsCastings.Common.EntityValidationConstants.ActorPlay;

namespace ActorsCastings.Data.Models
{
    [PrimaryKey(nameof(ActorId), nameof(PlayId))]
    public class ActorPlay
    {
        [Required]
        [ForeignKey(nameof(Actor))]
        [Comment("Foreign key to Actor")]
        public Guid ActorId { get; set; }

        [Required]
        public Actor Actor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Play))]
        [Comment("Foreign key to Play")]
        public Guid PlayId { get; set; }

        [Required]
        public Play Play { get; set; } = null!;

        [Comment("The role of the actor in the play")]
        [MaxLength(ActorPlayRoleMaxLength)]
        public string? Role { get; set; }

        [Required]
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Is the part of the actor in the play approved by Admin")]
        public bool IsApproved { get; set; }
    }
}
