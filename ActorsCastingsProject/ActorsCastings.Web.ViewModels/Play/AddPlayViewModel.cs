namespace ActorsCastings.Web.ViewModels.Play
{
    public class AddPlayViewModel
    {
        public string Title { get; set; } = null!;

        public string? Role { get; set; }

        public string Director { get; set; } = null!;

        public string Theatre { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public int ReleaseYear { get; set; }

        public string? Description { get; set; }
    }
}
