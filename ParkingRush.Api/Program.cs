using Microsoft.OpenApi.Models;
using ParkingRush.Application;
using ParkingRush.Infrastructure;
using ParkingRush.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationServicesR();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("{SWAGGER_VERSION}", new OpenApiInfo {Title = "{PROJECT_TITLE}", Version = "{SWAGGER_VERSION}"});
});

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/1/swagger.json", "ParkingRush.Api"));
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


app.Run();