namespace ActorsCastings.Web.ViewModels.Admin
{
    public class RoleInMovieToApproveViewModel
    {
        public string MovieId { get; set; } = null!;

        public string MovieTitle { get; set; } = null!;

        public string ActorId { get; set; } = null!;

        public string ActorName { get; set; } = null!;

        public string? Role { get; set; }
    }
}
