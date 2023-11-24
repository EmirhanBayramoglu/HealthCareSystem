using HealthCareSystem.Extensions;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureAppointRepository();
builder.Services.ConfigureDoctorRepository();
builder.Services.ConfigureMedicineRepository();
builder.Services.ConfigurePatientRepository();
builder.Services.ConfigurePrescriptRepository();
builder.Services.ConfigureRecordRepository();
builder.Services.ConfigurePatientToDoctorRepository();
builder.Services.ConfigurePatientToRecordRepository();
builder.Services.ConfigurePrescriptionListRepository();
builder.Services.ConfigurePatientToAppointmentRepository();
builder.Services.ConfigurePrescriptionToAppointmentRepository();

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
