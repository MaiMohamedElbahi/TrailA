using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.Mappings;
using TrailA.REPOs.Implementation;
using TrailA.REPOs.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(e => e.AddProfile(typeof(MappingProfile)));
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IAppointmentCustom, AppointmentCustom>();
builder.Services.AddScoped<ICustomerCustom, CustomerCustom>();
builder.Services.AddScoped<IServiceCustom, ServiceCustom>();
builder.Services.AddScoped<IVehicleCustom, VehicleCustom>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehers;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True"));
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
// commit changes
// pull
// commit in new branch
