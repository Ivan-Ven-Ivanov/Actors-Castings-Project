namespace ActorsCastings.Web.ViewModels.ActorProfile
{
    public class UpdateActorProfileViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }

        public string? Biography { get; set; }

        public string ProfilePictureUrl { get; set; } = null!;
    }
}
