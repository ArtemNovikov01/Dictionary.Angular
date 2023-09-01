using Dictionary.Web.Infrastructure.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomainService(builder.Configuration);
builder.Services.AddWebService();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Dictionary API",
    });
});
var app = builder.Build();

app.UseSwagger().UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
    });

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
