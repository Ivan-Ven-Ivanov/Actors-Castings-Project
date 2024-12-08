using System.ComponentModel.DataAnnotations;
using static ActorsCastings.Common.EntityValidationConstants.ActorPlay;
using static ActorsCastings.Common.EntityValidationConstants.Play;
using static ActorsCastings.Common.EntityValidationMessages.ActorPlay;
using static ActorsCastings.Common.EntityValidationMessages.Play;

namespace ActorsCastings.Web.ViewModels.Play
{
    public class AddPlayViewModel
    {
        [Required(ErrorMessage = TitleRequiredMessage)]
        [StringLength(PlayTitleMaxLength, MinimumLength = PlayTitleMinLength, ErrorMessage = TitleLengthMessage)]
        public string Title { get; set; } = null!;

        [StringLength(ActorPlayRoleMaxLength, MinimumLength = ActorPlayRoleMinLength, ErrorMessage = RoleLengthMessage)]
        public string? Role { get; set; }

        [Required(ErrorMessage = DirectorRequiredMessage)]
        [StringLength(PlayDirectorMaxLength, MinimumLength = PlayDirectorMinLength, ErrorMessage = DirectorLengthMessage)]
        public string Director { get; set; } = null!;

        [Required(ErrorMessage = TheatreRequiredMessage)]
        [StringLength(PlayTheatreMaxLength, MinimumLength = PlayTheatreMinLength, ErrorMessage = TheatreLengthMessage)]
        public string Theatre { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = ReleaseYearRequiredMessage)]
        [Range(PlayReleaseYearMinValue, PlayReleaseYearMaxValue, ErrorMessage = ReleaseYearRangeMessage)]
        public int ReleaseYear { get; set; }


        [StringLength(PlayDescriptionMaxLength, ErrorMessage = DescriptionLengthMessage)]
        public string? Description { get; set; }
    }
}
