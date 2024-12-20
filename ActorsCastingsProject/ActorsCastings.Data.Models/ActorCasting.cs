﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActorsCastings.Data.Models
{
    [PrimaryKey(nameof(ActorId), nameof(CastingId))]
    public class ActorCasting
    {
        [Comment("Foreign key to Actor")]
        [ForeignKey(nameof(Actor))]
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }

        [Comment("Foreign key to Casting")]
        [ForeignKey(nameof(Casting))]
        public Guid CastingId { get; set; }

        public Casting Casting { get; set; }

        [Required]
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }
    }
}
