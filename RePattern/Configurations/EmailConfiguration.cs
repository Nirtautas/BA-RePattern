using RePattern.Api.Options;

namespace RePattern.Api.Configurations
{
    public static class EmailConfiguration
    {
        public static WebApplicationBuilder ConfigureGmail(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<GmailOptions>(
                builder.Configuration.GetSection(GmailOptions.GmailOptionsKey)
            );

            return builder;
        }
    }
}
