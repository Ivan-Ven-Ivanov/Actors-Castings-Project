using System.ComponentModel.DataAnnotations;

using static ActorsCastings.Common.EntityValidationConstants.ActorMovie;
using static ActorsCastings.Common.EntityValidationMessages.ActorMovie;

namespace ActorsCastings.Web.ViewModels.Movie
{
    public class SelectedMovieViewModel
    {
        public string Id { get; set; } = null!;

        [StringLength(ActorMovieRoleMaxLength, MinimumLength = ActorMovieRoleMinLength, ErrorMessage = RoleLengthMessage)]
        public string? Role { get; set; }

        public IList<MovieViewModel> Movies { get; set; }
            = new List<MovieViewModel>();
    }
}
