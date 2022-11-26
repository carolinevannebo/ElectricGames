using ElectricGamesApi.Logic.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors( // <-- Legg til CORS, det vil si Cross-Origin Resource Sharing
    options => {
        options.AddPolicy("AllowAll",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
        );
    }
); //app.UseCors("AllowAll");
builder.Services.AddControllers();
builder.Services.AddDbContext<ElectricGamesContext>(options => options.UseSqlite("Data Source=Data/ElectricGames.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();
app.UseCors("AllowAll");

DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
/*
DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);*/

//app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
