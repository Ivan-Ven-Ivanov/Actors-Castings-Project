namespace ActorsCastings.Web.ViewModels.Casting
{
    public class CastingSearchViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CastingAgentName { get; set; } = null!;

        public string? CastingAgency { get; set; }
    }
}
