using ActorsCastings.Web.ViewModels.Casting;
using System.ComponentModel.DataAnnotations;

using static ActorsCastings.Common.EntityValidationConstants.CastingAgentProfile;
using static ActorsCastings.Common.EntityValidationMessages.CastingAgentProfile;

namespace ActorsCastings.Web.ViewModels.CastingAgentProfile
{
    public class CastingAgentProfileViewModel
    {
        [Required(ErrorMessage = NameRequiredMessage)]
        [StringLength(CastingAgentNameMaxLength, MinimumLength = CastingAgentNameMinLength, ErrorMessage = NameLengthMessage)]
        public string Name { get; set; } = null!;

        [StringLength(CastingAgentAgencyMaxLength, ErrorMessage = CastingAgencyMaxLengthMessage)]
        public string? CastingAgency { get; set; }

        public IList<CastingViewModel> Castings { get; set; }
            = new List<CastingViewModel>();
    }
}
