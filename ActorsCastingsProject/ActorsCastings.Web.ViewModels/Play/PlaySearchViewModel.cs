namespace ActorsCastings.Web.ViewModels.Play
{
    public class PlaySearchViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string Theatre { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string? Description { get; set; }
    }
}
