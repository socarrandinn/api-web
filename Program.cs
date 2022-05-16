using api_web.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opcions=>
{
   opcions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
   opcions.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// context de base datos en postgres
builder.Services.AddDbContext<ConsultorioContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConsultorioContext"));
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
            new string[]{}
        }
    });
});


//Configuración de Cors 
builder.Services.AddCors(opcion =>
{
    var frontendURL = builder.Services
                             .BuildServiceProvider()
                             .GetService<IConfiguration>().GetValue<string>("Frontend_url");
    opcion.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

//Configuración Autenticación
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,  
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,    
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration["Jwt:key"]))
    };
});

//Configuración Mappeo de BaseDatos
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();


//Migracion actumatica de BaseDatos
using (var scope = app.Services.CreateScope())
{
    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ConsultorioContext>(); // context de carpeta Context
    applicationDbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "web-api v1"));
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
