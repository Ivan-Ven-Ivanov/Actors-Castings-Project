namespace ActorsCastings.Web.ViewModels.Admin
{
    public class MovieToApproveViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Genre { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public string? Description { get; set; }
    }
}
