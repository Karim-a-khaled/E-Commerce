using PartTwo.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddRedisServices(builder.Configuration);
builder.Services.AddExceptionServices();
builder.Services.AddServices();

var app = builder.Build();

app.AddUsings();
app.MapControllers();
app.Run();

//using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;
//var context = services.GetRequiredService<StoreContext>();
//var logger = services.GetRequiredService<ILogger<Program>>();

//try
//{
//    await context.Database.MigrateAsync();
//    await StoreContextSeed.SeedAsync(context);
//}
//catch(Exception ex)
//{
//    logger.LogError(ex, "An Error Occured During Migration");
//}