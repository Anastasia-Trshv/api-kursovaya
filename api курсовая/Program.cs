using api_��������;
using api_��������.Repositories;
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
app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader(); 
    x.WithOrigins("http://localhost:5173/");
    x.WithMethods().AllowAnyMethod();
});


app.Run();
