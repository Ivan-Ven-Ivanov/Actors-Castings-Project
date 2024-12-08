namespace ActorsCastings.Web.ViewModels.Casting
{
    public class CastingViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string CastingEnd { get; set; } = null!;
        public int ActorsApplied { get; set; }
    }
}
