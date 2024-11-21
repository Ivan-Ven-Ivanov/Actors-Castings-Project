using System.ComponentModel.DataAnnotations;

namespace ActorsCastings.Data.Models
{
    public class CastingAgentProfile
    {
        public CastingAgentProfile()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

    }
}
