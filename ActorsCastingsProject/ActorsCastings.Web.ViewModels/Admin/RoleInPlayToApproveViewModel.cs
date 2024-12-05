namespace ActorsCastings.Web.ViewModels.Admin
{
    public class RoleInPlayToApproveViewModel
    {
        public string PlayId { get; set; } = null!;

        public string PlayTitle { get; set; } = null!;

        public string ActorId { get; set; } = null!;

        public string ActorName { get; set; } = null!;

        public string? Role { get; set; }
    }
}
