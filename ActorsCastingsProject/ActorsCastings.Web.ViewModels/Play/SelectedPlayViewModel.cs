using System.ComponentModel.DataAnnotations;

using static ActorsCastings.Common.EntityValidationConstants.ActorPlay;
using static ActorsCastings.Common.EntityValidationMessages.ActorPlay;

namespace ActorsCastings.Web.ViewModels.Play
{
    public class SelectedPlayViewModel
    {
        public string Id { get; set; } = null!;

        [StringLength(ActorPlayRoleMaxLength, MinimumLength = ActorPlayRoleMinLength, ErrorMessage = RoleLengthMessage)]
        public string? Role { get; set; }

        public IList<PlayViewModel> Plays { get; set; }
            = new List<PlayViewModel>();
    }
}
