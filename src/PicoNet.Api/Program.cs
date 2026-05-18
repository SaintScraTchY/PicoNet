using PicoNet.Application.Extensions;
using PicoNet.Infrastructure.Data;
using PicoNet.Infrastructure.Extensions;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure
InfrastructureExtensions.AddInfrastructure(builder.Services, builder.Configuration);

// Add Wolverine
builder.Host.UseWolverine(opts =>
{
    opts.Discovery.IncludeAssembly(typeof(ApplicationExtension).Assembly);
});

var app = builder.Build();

// Ensure database is created (for development)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PicoNetDbContext>();
    await db.Database.EnsureCreatedAsync();
}

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
