using System.Text;
using Investment.App.Api.Exceptions;
using Investment.App.Api.Extensions;
using Investment.App.Api.Infrastructure.Context;
using Investment.App.Api.Workers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "XP - Investment API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

builder.Services.AddControllers();

builder.Services.AddOutputCache(options => {
    options.AddBasePolicy(builder => builder.Cache());
    options.AddPolicy("OutputCacheWithAuthPolicy", OutputCacheWithAuthPolicy.Instance);
});

builder.Services.AddDbContext<InvestmentDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("InvestmentContext")));

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddHostedService<TimedInvestmentHostedService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>() ?? throw new EmptyConfigException("Jwt:Issuer");
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>() ?? throw new EmptyConfigException("Jwt:Key");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });
//Jwt configuration ends here

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseOutputCache();
app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InvestmentDbContext>();
    db.Database.Migrate();
}

app.Run();
