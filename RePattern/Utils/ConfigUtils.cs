using RePattern.Common.Exceptions.Custom;

namespace RePattern.Api.Utils;

public static class ConfigUtils
{
    public static string GetRequiredConfigValue(this IConfiguration configuration, string key)
    {
        var value = configuration[key];

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ConfigValueNotFound($"Missing configuration value for key '{key}'");
        }

        return value;
    }
}