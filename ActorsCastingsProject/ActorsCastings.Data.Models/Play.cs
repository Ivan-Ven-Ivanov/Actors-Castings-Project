﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static ActorsCastings.Common.EntityValidationConstants.Play;

namespace ActorsCastings.Data.Models
{
    public class Play
    {
        public Play()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Comment("Play unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Play title")]
        [MaxLength(PlayTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Play director name")]
        [MaxLength(PlayDirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        [Comment("The theatre where the play is played")]
        [MaxLength(PlayTheatreMaxLength)]
        public string Theatre { get; set; } = null!;

        [Required]
        [Comment("Release year of the play")]
        public int ReleaseYear { get; set; }

        [Comment("Description of the play")]
        [MaxLength(PlayDescriptionMaxLength)]
        public string? Description { get; set; }

        [Comment("Image URL of the play")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Is the Play approved by Admin")]
        public bool IsApproved { get; set; }

        public IList<ActorPlay> ActorsPlays { get; set; }
            = new List<ActorPlay>();
    }
}
