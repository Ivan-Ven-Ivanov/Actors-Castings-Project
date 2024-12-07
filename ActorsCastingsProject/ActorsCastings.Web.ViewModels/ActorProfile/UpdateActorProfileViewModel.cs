using System.ComponentModel.DataAnnotations;
using static ActorsCastings.Common.EntityValidationConstants.ActorProfile;
using static ActorsCastings.Common.EntityValidationMessages.ActorProfile;

namespace ActorsCastings.Web.ViewModels.ActorProfile
{
    public class UpdateActorProfileViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = FirstNameRequiredMessage)]
        [StringLength(ActorFirstNameMaxLength, MinimumLength = ActorFirstNameMinLength, ErrorMessage = FirstNameLengthMessage)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequiredMessage)]
        [StringLength(ActorLastNameMaxLength, MinimumLength = ActorLastNameMinLength, ErrorMessage = LastNameLengthMessage)]
        public string LastName { get; set; } = null!;

        [Range(ActorAgeMinValue, ActorAgeMaxValue, ErrorMessage = AgeRangeMessage)]
        public int? Age { get; set; }

        [StringLength(ActorBiographyMaxLength, ErrorMessage = BiographyMaxLengthMessage)]
        public string? Biography { get; set; }

        [Required(ErrorMessage = ProfilePictureUrlRequiredMessage)]
        public string ProfilePictureUrl { get; set; } = null!;
    }
}
