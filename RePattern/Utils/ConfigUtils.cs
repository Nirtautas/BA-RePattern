namespace RePattern.Api.Utils;

public static class ConfigUtils
{
    public static string GetRequiredConfigValue(this IConfiguration configuration, string key)
    {
        var value = configuration[key];

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException(
                $"Missing configuration value for key '{key}'"
            );
        }

        return value;
    }
}