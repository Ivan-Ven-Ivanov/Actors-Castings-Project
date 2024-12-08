using System.ComponentModel.DataAnnotations;
using static ActorsCastings.Common.EntityValidationConstants.ActorMovie;
using static ActorsCastings.Common.EntityValidationConstants.Movie;
using static ActorsCastings.Common.EntityValidationMessages.ActorMovie;
using static ActorsCastings.Common.EntityValidationMessages.Movie;

namespace ActorsCastings.Web.ViewModels.Movie
{
    public class AddMovieViewModel
    {
        [Required(ErrorMessage = TitleRequiredMessage)]
        [StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength, ErrorMessage = TitleLengthMessage)]
        public string Title { get; set; } = null!;

        [StringLength(ActorMovieRoleMaxLength, MinimumLength = ActorMovieRoleMinLength, ErrorMessage = RoleLengthMessage)]
        public string? Role { get; set; }

        [Required(ErrorMessage = DirectorRequiredMessage)]
        [StringLength(MovieDirectorMaxLength, MinimumLength = MovieDirectorMinLength, ErrorMessage = DirectorLengthMessage)]
        public string Director { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = GenreRequiredMessage)]
        [StringLength(MovieGenreMaxLength, MinimumLength = MovieGenreMinLength, ErrorMessage = GenreLengthMessage)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ReleaseYearRequiredMessage)]
        [Range(MovieReleaseYearMinValue, MovieReleaseYearMaxValue, ErrorMessage = ReleaseYearRangeMessage)]
        public int ReleaseYear { get; set; }

        [StringLength(MovieDescriptionMaxLength, ErrorMessage = DescriptionLengthMessage)]
        public string? Description { get; set; }
    }
}
