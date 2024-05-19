using api_курсовая;
using api_курсовая.Repositories;
using Kursovaya.Application.Services;
using Kursovaya.Core.Abstract;
AppDbContext db = new AppDbContext();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ISuppliesServise, SuppliesServise>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
