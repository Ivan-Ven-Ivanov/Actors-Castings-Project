namespace ActorsCastings.Web.ViewModels.Admin
{
    public class DataToApproveViewModel
    {
        public IList<MovieToApproveViewModel> Movies { get; set; }
            = new List<MovieToApproveViewModel>();

        public IList<PlayToApproveViewModel> Plays { get; set; }
            = new List<PlayToApproveViewModel>();

        public IList<CastingToApproveViewModel> Castings { get; set; }
            = new List<CastingToApproveViewModel>();

        public IList<RoleInMovieToApproveViewModel> RolesInMovies { get; set; }
            = new List<RoleInMovieToApproveViewModel>();

        public IList<RoleInPlayToApproveViewModel> RolesInPlays { get; set; }
            = new List<RoleInPlayToApproveViewModel>();
    }
}
