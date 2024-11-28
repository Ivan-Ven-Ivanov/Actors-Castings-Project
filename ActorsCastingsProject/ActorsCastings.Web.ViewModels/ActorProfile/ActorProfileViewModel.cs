using System.ComponentModel.DataAnnotations;

namespace ActorsCastings.Web.ViewModels.ActorProfile
{
    using Movie;
    using Play;

    public class ActorProfileViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string ProfilePictureUrl { get; set; } = null!;

        public int? Age { get; set; }

        public string? Biography { get; set; }

        IList<MovieViewModel> Movies { get; set; }
            = new List<MovieViewModel>();

        IList<PlayViewModel> Plays { get; set; }
            = new List<PlayViewModel>();
    }
}
