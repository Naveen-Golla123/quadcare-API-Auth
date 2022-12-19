using MySqlConnector;
using Quadcare.Respository;
using Quadcare.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});


//Dependency Injection

builder.Services.AddSingleton<IPatientRepository, PatientRespository>();
builder.Services.AddSingleton<IPatientService,PatientService>();

builder.Services.AddSingleton<IDoctorRepository, DoctorRespository>();
builder.Services.AddSingleton<IDoctorService, DoctorService>();

builder.Services.AddSingleton<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddSingleton<IAppointmentService, AppointmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
