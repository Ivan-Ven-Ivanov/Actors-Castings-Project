using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActorsCastings.Data.Models
{
    [PrimaryKey(nameof(ActorId), nameof(CastingId))]
    public class ActorCasting
    {
        [Comment("Foreign key to ActorProfile")]
        [ForeignKey(nameof(Actor))]
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }

        [Comment("Foreign key to Casting")]
        [ForeignKey(nameof(Casting))]
        public Guid CastingId { get; set; }

        public Casting Casting { get; set; }
    }
}
