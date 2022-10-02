using corporatediscountsApi.CorporateDiscountsServices;
using corporatediscountsApi.CorporateDiscountsAdminServices;
using corporatediscountsApi.DbContexts;
using corporatediscountsApi.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgreDbContext>(item => item.UseNpgsql(
    "User ID=postgres;Password=ZAQ12wsx;Server=localhost;Port=5432;Database=postgres;Integrated Security=true;Pooling=true;"));
builder.Services.AddScoped<CorporateDiscountsService, CorporateDiscountsService>();
builder.Services.AddScoped<CorporateDiscountsAdminService, CorporateDiscountsAdminService>();
builder.Services.AddScoped (typeof(IRepository<,>), typeof(Repository<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x=>x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
