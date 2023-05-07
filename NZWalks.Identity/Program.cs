using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NZWalks.Identity.Data;
using NZWalks.Identity.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{    
 options.SwaggerDoc("v1", new OpenApiInfo(){Title = "NZ Walks API", Version = "v!"});
 options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
 {
  Name = "Authorization",
  In = ParameterLocation.Header,
  Type = SecuritySchemeType.ApiKey,
  Scheme = JwtBearerDefaults.AuthenticationScheme
 });
 options .AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {

         new OpenApiSecurityScheme
         {
             Reference = new OpenApiReference
             {
                 Type = ReferenceType.SecurityScheme,
                 Id = JwtBearerDefaults.AuthenticationScheme
             },
             Scheme ="Oauth2",
             Name = JwtBearerDefaults.AuthenticationScheme,
             In = ParameterLocation.Header
         },
         new List<string>()
     }
 });
});

builder.Services.AddAuthentication();
builder.Services.AddScoped<ITokenRepository,TokenRepository>();
builder.Services.AddDbContext<NZWalksAuthDbContext>(
    options => options
         .UseSqlServer(builder.Configuration.GetConnectionString("IdentityServerConnectionString")));

builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalks.Identity")
                .AddEntityFrameworkStores<NZWalksAuthDbContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase=false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
