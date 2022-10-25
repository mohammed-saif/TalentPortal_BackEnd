using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", p => { 
        p.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:50000");
        });
    });
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);

// Add services to the container.

//builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseOcelot();



// Configure the HTTP request pipeline.

//app.UseAuthorization();

//app.MapControllers();

app.Run();
