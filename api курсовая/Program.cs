using api_курсовая;
using api_курсовая.Authentication;
using api_курсовая.Repositories;
using Kursovaya.Application.Services;
using Kursovaya.Core.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
AppDbContext db = new AppDbContext();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ISuppliesServise, SuppliesServise>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServise, UserServise>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidAudience = AuthOptions.AUDIENCE,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
        };
    });
    


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader(); 
    x.WithOrigins("http://localhost:5173");
    x.WithMethods().AllowAnyMethod();
});


app.Map("/login/{username}", (string username, string role) =>
{
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, role) };

    var jwt = new JwtSecurityToken(
    issuer: AuthOptions.ISSUER,
    audience: AuthOptions.AUDIENCE,
    claims: claims,
    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
    SecurityAlgorithms.HmacSha256));

    return new JwtSecurityTokenHandler().WriteToken(jwt);
});

app.Run();
