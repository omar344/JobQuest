using JobQuest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register Infrastructure Services
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();