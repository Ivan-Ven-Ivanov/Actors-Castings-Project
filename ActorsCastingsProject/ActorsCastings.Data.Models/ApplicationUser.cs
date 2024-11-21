using Microsoft.AspNetCore.Identity;

namespace ActorsCastings.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        public Guid? ActorProfileId { get; set; }

        public ActorProfile? ActorProfile { get; set; }

        public Guid? CastingAgentProfileId { get; set; }

        public CastingAgentProfile? CastingAgentProfile { get; set; }
    }
}
