namespace ActorsCastings.Common
{
    public static class ApplicationRoles
    {
        public const string Actor = "Actor";

        public const string CastingAgent = "CastingAgent";

        public static readonly IReadOnlyList<string> AllRoles
            = new List<string> { Actor, CastingAgent };
    }
}
