namespace ActorsCastings.Web.ViewModels
{
    public class CastingViewModel
    {
        public string? Id { get; set; }
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CastingEnd { get; set; } = null!;

        public string? CastingAgentId { get; set; }
    }
}
