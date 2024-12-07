namespace ActorsCastings.Common
{
    public class EntityValidationMessages
    {
        public static class ActorProfile
        {
            public const string FirstNameRequiredMessage = "First name is required.";
            public const string FirstNameLengthMessage = "First name must be between 2 and 20 letters.";
            public const string LastNameRequiredMessage = "Last name is required.";
            public const string LastNameLengthMessage = "Last name must be between 2 and 20 letters.";
            public const string AgeRangeMessage = "Age must be between 3 and 100.";
            public const string BiographyMaxLengthMessage = "Biography must be less than 1000 symbols.";
            public const string ProfilePictureUrlRequiredMessage = "You must have a profile picture URL.";
        }

        public static class CastingAgentProfile
        {
            public const string NameRequiredMessage = "Name is required.";
            public const string NameLengthMessage = "Name must be between 2 and 30 letters.";
            public const string CastingAgencyMaxLengthMessage = "Casting agency name must be less than 50 symbols.";
        }

        public static class Casting
        {
            public const string TitleRequiredMessage = "Title is required.";
            public const string TitleLengthMessage = "Title must be between 6 and 100 symbols.";
            public const string DescriptionRequiredMessage = "Description is required.";
            public const string DescriptionLengthMessage = "Description must be between 10 and 500 symbols.";
            public const string CastingEndRequiredMessage = "End of casting is required.";
        }

        public static class ActorMovie
        {
            public const string RoleLengthMessage = "Role must be between 2 and 50 symbols.";
        }
    }
}
