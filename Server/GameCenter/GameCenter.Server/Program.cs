using GameCenter.Business.Behavior;
using GameCenter.Business.Filters;
using GameCenter.DataAccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using GameCenter.Server.Services.Genres;
using GameCenter.Business.Repositories.Genres;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
//builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddControllers(options =>
{
    //options.Filters.Add(typeof(ExeptionFilter));
    options.Filters.Add(typeof(ParseBadRequest));
}).ConfigureApiBehaviorOptions(BadRequest.Parse);

AddTransientServices(builder.Services);
AddScopedRepositories(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    var frontendUrl = builder.Configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendUrl)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders(new string[] { "totalAmountOfRecords" });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddTransientServices(IServiceCollection services)
{
    services.AddTransient<IGenreService, GenreService>();
}

static void AddScopedRepositories(IServiceCollection services)
{
    services.AddScoped<IGenreRepository, GenreRepository>();
}
