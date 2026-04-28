using RePattern.Api.Configurations;
using RePattern.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

builder
    .ConfigureSwagger()
    .ConfigureAuthentication();

builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddDataServices(builder.Configuration);

builder.Services.AddControllers();

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
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RePattern API Version 1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
