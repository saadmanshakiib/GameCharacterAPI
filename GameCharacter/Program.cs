using GameCharacter.Data;
using GameCharacter.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IVideoGameCharacterService, VideoGameCharacterService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

app.MapGet("/ok", () => "Sadman");
app.UseHttpsRedirection();
app.MigrateDb();
app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.MapStaticAssets();



app.Run();