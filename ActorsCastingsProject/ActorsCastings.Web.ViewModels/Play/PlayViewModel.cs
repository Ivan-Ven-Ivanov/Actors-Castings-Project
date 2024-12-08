namespace ActorsCastings.Web.ViewModels.Play
{
    public class PlayViewModel
    {

        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string ReleaseYear { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsRoleInPlayApproved { get; set; }

        public bool IsSelected { get; set; }
    }
}
