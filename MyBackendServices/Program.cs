using Microsoft.EntityFrameworkCore;
using MySOASolution.BLL;
using MySOASolution.BLL.Interface;
using MySOASolution.Data;
using MySOASolution.Data.DAL;
using MySOASolution.Data.DAL.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISamurai, SamuraiDal>();
builder.Services.AddScoped<ISamuraiBLL, SamuraiBLL>();

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapControllers();

app.Run();
