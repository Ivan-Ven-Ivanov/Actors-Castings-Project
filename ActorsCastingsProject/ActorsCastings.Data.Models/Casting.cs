using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ActorsCastings.Common.EntityValidationConstants.Casting;

namespace ActorsCastings.Data.Models
{
    public class Casting
    {
        public Casting()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
        }

        [Key]
        [Comment("Casting unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Casting title")]
        [MaxLength(CastingTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Description of the casting")]
        [MaxLength(CastingDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The date the casting has been created")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("The day and time the casting ends")]
        public DateTime CastingEnd { get; set; }

        [ForeignKey(nameof(CastingAgent))]
        [Comment("The Casting agent that has created the casting - foreign key")]
        public Guid CastingAgentId { get; set; }

        public CastingAgent CastingAgent { get; set; } = null!;

        [Required]
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }
    }
}
