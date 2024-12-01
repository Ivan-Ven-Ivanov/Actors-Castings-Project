namespace ActorsCastings.Web.ViewModels.Actor
{
    public class ActorInMovieViewModel
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string ProfilePictureUrl { get; set; } = null!;

        public string? Role { get; set; }
    }
}
