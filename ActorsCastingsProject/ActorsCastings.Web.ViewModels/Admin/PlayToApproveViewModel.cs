namespace ActorsCastings.Web.ViewModels.Admin
{
    public class PlayToApproveViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string Theatre { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
