using System.ComponentModel.DataAnnotations;

using static ActorsCastings.Common.EntityValidationConstants.CastingAgentProfile;
using static ActorsCastings.Common.EntityValidationMessages.CastingAgentProfile;

namespace ActorsCastings.Web.ViewModels.CastingAgentProfile
{
    public class UpdateCastingAgentProfileViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = NameRequiredMessage)]
        [StringLength(CastingAgentNameMaxLength, MinimumLength = CastingAgentNameMinLength, ErrorMessage = NameLengthMessage)]
        public string Name { get; set; } = null!;

        [StringLength(CastingAgentAgencyMaxLength, ErrorMessage = CastingAgencyMaxLengthMessage)]
        public string? CastingAgency { get; set; }
    }
}
