namespace ActorsCastings.Common
{
    public static class ProfileTypes
    {
        public const string Actor = "Actor";

        public const string CastingAgent = "CastingAgent";

        public static readonly IReadOnlyList<string> AllProfiles
            = new List<string> { Actor, CastingAgent };
    }
}
