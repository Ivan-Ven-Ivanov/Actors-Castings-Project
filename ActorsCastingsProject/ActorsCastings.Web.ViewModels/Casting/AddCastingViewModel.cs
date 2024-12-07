using System.ComponentModel.DataAnnotations;

using static ActorsCastings.Common.EntityValidationConstants.Casting;
using static ActorsCastings.Common.EntityValidationMessages.Casting;

namespace ActorsCastings.Web.ViewModels.Casting
{
    public class AddCastingViewModel
    {
        [Required(ErrorMessage = TitleRequiredMessage)]
        [StringLength(CastingTitleMaxLength, MinimumLength = CastingTitleMinLength, ErrorMessage = TitleLengthMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [StringLength(CastingDescriptionMaxLength, ErrorMessage = DescriptionLengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = CastingEndRequiredMessage)]
        public string CastingEnd { get; set; } = null!;
    }
}
