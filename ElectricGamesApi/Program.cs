using System.Text.Json;
using System.Text.Json.Serialization;
using ElectricGamesApi.Logic.Enumerations;
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
                //.AllowCredentials()
        );
    }
); //app.UseCors("AllowAll");
builder.Services.AddControllers();
builder.Services.AddDbContext<ElectricGamesContext>(options => options.UseSqlite("Data Source=Data/ElectricGames.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAll");
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000/");
    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
    context.Response.Headers.Add("Access-Control-Allow-Headers", 
    "Origin, X-Requested-With, Content-Type, Accept, x-client-key, x-client-token, x-client-secret, Authorization");
    await next();
});

DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);

/*var jsonOptions = new JsonSerializerOptions();
jsonOptions.Converters.Add(new JsonStringEnumConverter());
var genre = JsonSerializer.Deserialize<GenreEnum>(json, jsonOptions);*/
//app.UseJsonOptions(jsonOptions);

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
