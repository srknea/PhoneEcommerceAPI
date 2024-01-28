using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Core.UnitOfWork;
using PhoneEcommerce.Repository;
using PhoneEcommerce.Repository.Repositories;
using PhoneEcommerce.Repository.UnitOfWork;
using PhoneEcommerce.Service.Mapping;
using PhoneEcommerce.Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        //option.MigrationsAssembly("CarParkSystem.Repository");
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Services.AddIdentity<AppUser, AppRole>(Opt =>
{
    Opt.User.RequireUniqueEmail = true; // Email adresi unique olmalý
    Opt.Password.RequireNonAlphanumeric = false; // *? gibi karakterlerin kullanýmýný zorunlu tutma... (Normalde default olarak zorunludur)
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

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
