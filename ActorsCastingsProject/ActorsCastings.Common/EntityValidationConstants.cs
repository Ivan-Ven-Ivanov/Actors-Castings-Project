namespace ActorsCastings.Common
{
    public class EntityValidationConstants
    {
        public static class ActorProfile
        {
            public const int ActorFirstNameMinLength = 2;
            public const int ActorFirstNameMaxLength = 20;
            public const int ActorLastNameMinLength = 2;
            public const int ActorLastNameMaxLength = 20;
            public const int ActorBiographyMaxLength = 1000;
            public const int ActorAgeMinValue = 3;
            public const int ActorAgeMaxValue = 100;
        }

        public static class Movie
        {
            public const int MovieTitleMinLength = 2;
            public const int MovieTitleMaxLength = 150;
            public const int MovieGenreMinLength = 3;
            public const int MovieGenreMaxLength = 30;
            public const int MovieDescriptionMaxLength = 500;
            public const int MovieDirectorMinLength = 2;
            public const int MovieDirectorMaxLength = 50;
        }

        public static class Play
        {
            public const int PlayTitleMinLength = 2;
            public const int PlayTitleMaxLength = 150;
            public const int PlayDescriptionMaxLength = 500;
            public const int PlayDirectorMinLength = 2;
            public const int PlayDirectorMaxLength = 50;
            public const int PlayTheatreMinLength = 3;
            public const int PlayTheatreMaxLength = 50;
        }

        public static class Casting
        {
            public const int CastingTitleMinLength = 6;
            public const int CastingTitleMaxLength = 100;
            public const int CastingDescriptionMinLength = 10;
            public const int CastingDescriptionMaxLength = 500;
            public const string CastingEndDateTimeFormatString = "dd/MM/yyyy HH:mm";
        }

        public static class CastingAgentProfile
        {
            public const int CastingAgentNameMinLength = 2;
            public const int CastingAgentNameMaxLength = 30;
            public const int CastingAgentAgencyMaxLength = 50;
        }

        public static class ActorMovie
        {
            public const int ActorMovieRoleMinLength = 2;
            public const int ActorMovieRoleMaxLength = 50;
        }

        public static class ActorPlay
        {
            public const int ActorPlayRoleMinLength = 2;
            public const int ActorPlayRoleMaxLength = 50;
        }
    }
}
