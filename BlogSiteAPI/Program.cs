using BlogSite.API.Data;
using BlogSite.API.Repositories.Implementation;
using BlogSite.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injecting the ApllicationDbContext class in the Program folder so it can be used later inside controllers and repositories
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //give the db options here, tell entity framework core to use the sql server
    //use the connection string name found in the appsettings.json file
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogSiteConnectionString"));
});

//inject in application so it can be used in the controller
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//enable use Cors to make the API public
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
