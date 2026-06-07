using GameCharacter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVideoGameCharacterService, VideoGameCharacterService>();

var app = builder.Build();

app.MapGet("/ok", () => "Sadman");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.MapStaticAssets();



app.Run();