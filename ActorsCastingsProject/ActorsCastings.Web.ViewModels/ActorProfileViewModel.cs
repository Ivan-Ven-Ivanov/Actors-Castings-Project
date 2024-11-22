using System.ComponentModel.DataAnnotations;

namespace ActorsCastings.Web.ViewModels
{
    public class ActorProfileViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string ProfilePictureUrl { get; set; } = null!;

        public int? Age { get; set; }

        public string? Portfolio { get; set; }
    }
}
