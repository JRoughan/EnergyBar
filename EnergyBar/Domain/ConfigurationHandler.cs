namespace EnergyBar.Domain
{
    public static class ConfigurationHandler
    {
        // TODO: Move to read/write config via ConfigurationManager
        public static bool DisableScreenLockOnStartup { get; } = true;
        public static bool DisableSleepOnStartup { get; } = true;
    }
}