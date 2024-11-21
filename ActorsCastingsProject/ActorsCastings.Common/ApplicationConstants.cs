﻿namespace ActorsCastings.Common
{
    public class ApplicationConstants
    {
        public static class ActorProfileValidationConstants
        {
            public const int ActorFirstNameMinLength = 2;
            public const int ActorFirstNameMaxLength = 20;
            public const int ActorLastNameMinLength = 2;
            public const int ActorLastNameMaxLength = 20;
            public const int ActorPortfolioMaxLength = 1000;
        }

        public static class MovieValidationConstants
        {
            public const int MovieTitleMinLength = 2;
            public const int MovieTitleMaxLength = 150;
            public const int MovieGenreMinLength = 3;
            public const int MovieGenreMaxLength = 30;
            public const int MovieDescriptionMaxLength = 300;
            public const int MovieDirectorMinLength = 2;
            public const int MovieDirectorMaxLength = 50;
        }

        public static class PlayValidationConstants
        {
            public const int PlayTitleMinLength = 2;
            public const int PlayTitleMaxLength = 150;
            public const int PlayDescriptionMaxLength = 300;
            public const int PlayDirectorMinLength = 2;
            public const int PlayDirectorMaxLength = 50;
        }

        public static class CastingValidationConstants
        {
            public const int CastingTitleMinLength = 6;
            public const int CastingTitleMaxLength = 100;
            public const int CastingDescriptionMinLength = 10;
            public const int CastingDescriptionMaxLength = 500;
        }

        public static class CastingAgentProfileValidationConstants
        {
            public const int CastingAgentNameMinLength = 2;
            public const int CastingAgentNameMaxLength = 30;
            public const int CastingAgentAgencyMaxLength = 50;
        }
    }
}
