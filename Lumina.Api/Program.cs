using Serilog;
using Lumina.Api.Extentions;
using Lumina.Data.DbContexts;
using Lumina.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using Lumina.Service.Helpers.Media;
using Lumina.Api.Middlewares;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


// Serialog
var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration)
   .Enrich.FromLogContext()
   .CreateLogger();

//Fix the Cycle
//builder.Services.AddControllers()
//     .AddNewtonsoftJson(options =>
//     {
//         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//     });

//for logging  data
builder.Logging.AddConsole();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddCustomService();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
WebHostEnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(cors =>
    cors.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseStaticFiles();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();

app.MapControllers();

app.Run();
