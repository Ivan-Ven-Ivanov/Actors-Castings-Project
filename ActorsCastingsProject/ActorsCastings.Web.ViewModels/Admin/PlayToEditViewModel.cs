namespace ActorsCastings.Web.ViewModels.Admin
{
    public class PlayToEditViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string? Description { get; set; }

        public string Theatre { get; set; } = null!;
    }
}
