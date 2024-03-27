using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyBackendServices.Helpers;
using MySOASolution.BLL;
using MySOASolution.BLL.DTOs.Validation;
using MySOASolution.BLL.Interface;
using MySOASolution.Data;
using MySOASolution.Data.DAL;
using MySOASolution.Data.DAL.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI 
builder.Services.AddScoped<ISamuraiBLL, SamuraiBLL>();
builder.Services.AddScoped<ISamurai, SamuraiDal>();
builder.Services.AddScoped<IQuote, QuoteDal>();
builder.Services.AddScoped<IQuoteBLL, QuoteBLL>();
builder.Services.AddScoped<IAccount, AccountDal>();
builder.Services.AddScoped<IAccountBLL, AccountBLL>();

//fluent validation
//builder.Services.AddScoped<IValidator<SamuraiCreateDTO>, SamuraiCreateDTOValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<SamuraiCreateDTOValidation>();


//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//identity
builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SamuraiContext>()
    .AddDefaultTokenProviders();


//jwt token
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//ef core
builder.Services.AddDbContext<SamuraiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
