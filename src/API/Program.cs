using Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Register database services
builder.Services.AddDataServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();