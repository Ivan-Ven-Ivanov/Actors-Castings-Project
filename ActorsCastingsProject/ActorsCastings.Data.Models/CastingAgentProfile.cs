using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ActorsCastings.Common.ApplicationConstants.CastingAgentProfileValidationConstants;

namespace ActorsCastings.Data.Models
{
    public class CastingAgentProfile
    {
        public CastingAgentProfile()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Comment("Casting agent profile unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Name of the casting agent")]
        [MaxLength(CastingAgentNameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Name of the casting agency the agent works for")]
        [MaxLength(CastingAgentAgencyMaxLength)]
        public string? CastingAgency { get; set; }

        [Required]
        [Comment("Foreign key to User")]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }

        public IList<Casting> Castings { get; set; }
            = new List<Casting>();
    }
}
