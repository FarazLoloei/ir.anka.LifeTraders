namespace ir.anka.LifeTraders.Common.Infrastructure;

public abstract partial class DefaultData
{
    public abstract partial class General
    {
        public const int STRING_MAX_LENGTH = 250;

        public const string APPLICATION_TITLE = "ANKA Soft - Life Of Traders API";

        public const string APPLICATION_VERSION = "V1";

        public const string CONTROLLER_ROUTE_TEMPLATE = "api/[controller]/[Action]";
    }

    public abstract partial class Environment
    {
        public const string DEVELOPMENT_ENVIRONMENT_TITLE = "Development";
    }

    public abstract partial class Exceptions
    {
        public const string EXCEPTION_MESSAGE_TEMPLATE = "Creating {0} failed; Check the exception collection";
    }
}