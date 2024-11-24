namespace ActorsCastings.Web.ViewModels.Actor
{
    public class ActorDetailsViewModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Age { get; set; }

        public string ProfilePictureUrl { get; set; } = null!;

        public string? Portfolio { get; set; }
    }
}
