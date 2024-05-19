using api_курсовая;
using api_курсовая.Repositories;
using Kursovaya.Application.Services;
using Kursovaya.Core.Abstract;
AppDbContext db = new AppDbContext();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ISuppliesServise, SuppliesServise>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();

var app = builder.Build();


//app.UseAuthorization();
//app.UseAuthentication();

app.Run();
