using ActorsCastings.Web.ViewModels.Casting;
using System.ComponentModel.DataAnnotations;

namespace ActorsCastings.Web.ViewModels.CastingAgentProfile
{
    public class CastingAgentProfileViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? CastingAgency { get; set; }

        public IList<CastingViewModel> Castings { get; set; }
            = new List<CastingViewModel>();
    }
}
