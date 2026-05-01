using Microsoft.AspNetCore.Diagnostics;
using RePattern.Api.Configurations;
using RePattern.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

builder
    .ConfigureSwagger()
    .ConfigureAuthentication();

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddDataServices(builder.Configuration);

builder.Services.AddControllers();

var baseUrl = ConfigUtils.GetRequiredConfigValue(builder.Configuration, "baseUrl");
builder.WebHost.UseUrls(baseUrl);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEnd", policy =>
    {
        policy
        .WithOrigins(ConfigUtils.GetRequiredConfigValue(builder.Configuration, "FrontEndBaseUrl"))
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
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

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception != null)
        {
            var handler = context.RequestServices.GetRequiredService<GlobalExceptionHandler>();
            await handler.TryHandleAsync(context, exception, CancellationToken.None);
        }
    }
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("FrontEnd");

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();
