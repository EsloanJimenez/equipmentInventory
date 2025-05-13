using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Domain.Interface.Service;
using EquipmentInventory.Infrastructure.Context;
using EquipmentInventory.Infrastructure.Mapping;
using EquipmentInventory.Infrastructure.Repository;
using EquipmentInventory.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//CONFIGURACION DE CORS
builder.Services.AddCors(op =>
{
    op.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
});

//AUTOMAPPER
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EquipmentInventoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EquipmentInventory"));
});

#region "TRANSIENT"
builder.Services.AddScoped<IBaseRepository<Equipment, EquipmentDTO>, BaseRepository<Equipment, EquipmentDTO>>();
builder.Services.AddTransient<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddTransient<IMaintenanceTaskRepository, MaintenanceTaskRepository>();
builder.Services.AddTransient<IEquipmentMaintenanceRepository, EquipmentMaintenanceRepository>();
#endregion

#region "SCOPED"
builder.Services.AddScoped<IBaseRepository<Equipment, EquipmentDTO>, BaseRepository<Equipment, EquipmentDTO>>();
builder.Services.AddScoped<IBaseRepository<EquipmentType, EquipmentTypeDTO>, BaseRepository<EquipmentType, EquipmentTypeDTO>>();
builder.Services.AddScoped<IBaseRepository<MaintenanceTask, MaintenanceTaskDTO>, BaseRepository<MaintenanceTask, MaintenanceTaskDTO>>();

builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
builder.Services.AddScoped<IMaintenanceTaskService, MaintenanceTaskService>();
builder.Services.AddScoped<IEquipmentMaintenanceService, EquipmentMaintenanceService>();
#endregion


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
