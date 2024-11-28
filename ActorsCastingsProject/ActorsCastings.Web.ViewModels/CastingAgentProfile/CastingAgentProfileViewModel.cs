using System.ComponentModel.DataAnnotations;

namespace ActorsCastings.Web.ViewModels.CastingAgentProfile
{
    public class CastingAgentProfileViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? CastingAgency { get; set; }
    }
}
