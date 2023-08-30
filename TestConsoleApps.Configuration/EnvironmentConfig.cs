namespace TestConsoleApps.Configuration
{
    public class EnvironmentConfig
    {
        public static Environment Environment { get; private set; } = Environment.Development;
        public static bool IsDebug { get; private set; } = true;
    }
}
