namespace ActorsCastings.Web.ViewModels.CastingAgentProfile
{
    public class UpdateCastingAgentProfileViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string? CastingAgency { get; set; }
    }
}
