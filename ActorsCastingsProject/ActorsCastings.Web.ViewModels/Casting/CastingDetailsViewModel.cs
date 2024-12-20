﻿using ActorsCastings.Web.ViewModels.Actor;

namespace ActorsCastings.Web.ViewModels.Casting
{
    public class CastingDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
        public string CastingEnd { get; set; } = null!;

        public string CastingAgent { get; set; } = null!;

        public string? CastingAgency { get; set; }

        public bool HasActorApplied { get; set; }

        public IList<ActorInCastingViewModel> CastedActors { get; set; }
            = new List<ActorInCastingViewModel>();
    }
}
