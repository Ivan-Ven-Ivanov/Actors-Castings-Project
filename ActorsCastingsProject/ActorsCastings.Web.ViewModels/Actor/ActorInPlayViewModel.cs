namespace ActorsCastings.Web.ViewModels.Actor
{
    public class ActorInPlayViewModel
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string ProfilePictureUrl { get; set; } = null!;

        public string? Role { get; set; }
    }
}
