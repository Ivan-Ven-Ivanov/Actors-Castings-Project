using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static ActorsCastings.Common.EntityValidationConstants.Movie;

namespace ActorsCastings.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Comment("Movie unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Movie title")]
        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Genre of the movie")]
        [MaxLength(MovieGenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required]
        [Comment("Movie director name")]
        [MaxLength(MovieDirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        [Comment("Release year of the movie")]
        public int ReleaseYear { get; set; }

        [Comment("Description of the movie")]
        [MaxLength(MovieDescriptionMaxLength)]
        public string? Description { get; set; }

        [Comment("Image URL of the movie")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Is the Movie approved by Admin")]
        public bool IsApproved { get; set; }

        public IList<ActorMovie> ActorsMovies { get; set; }
            = new List<ActorMovie>();
    }
}
