namespace ActorsCastings.Web.ViewModels.Actor
{
    public class ActorSearchViewModel
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Age { get; set; }

        public string? Biography { get; set; }
    }
}
