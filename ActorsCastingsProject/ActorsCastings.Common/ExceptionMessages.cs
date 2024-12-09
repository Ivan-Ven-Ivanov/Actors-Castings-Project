namespace ActorsCastings.Common
{
    public static class ExceptionMessages
    {
        public const string IdEmpty = "ID cannot be empty.";
        public const string InvalidIdFormat = "Ivalid ID Format.";
        public const string InvalidDateFormat = "Ivalid Date Format.";
        public const string EntityNotFoundById = "{0} with ID {1} not found";
        public const string EntityNotFound = "{0} not found";
        public const string ServerError = "Server error!";
        public const string InvalidPageNumber = "Page number should be above 0";
        public const string InvalidPageSize = "There should be at least 1 on the page";
    }
}
