namespace ActorsCastings.Web.ViewModels.Admin
{
    public class MovieToEditViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public string? Description { get; set; }
    }
}
