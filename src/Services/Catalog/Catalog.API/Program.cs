using Carter;

var builder = WebApplication.CreateBuilder(args);

//Add Service to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(otps =>
{
    otps.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();


var app = builder.Build();

//Configure the http request pipline
app.MapCarter();

app.Run();
