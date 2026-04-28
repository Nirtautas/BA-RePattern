using RePattern.Api.Configurations;
using RePattern.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAuthentication();

builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddDataServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var baseUrl = ConfigUtils.GetRequiredConfigValue(builder.Configuration, "baseUrl");
builder.WebHost.UseUrls(baseUrl);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
