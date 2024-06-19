using APIs.Day2.CleanCrud.BL;
using APIs.Day2.CleanCrud.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Default

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Database

string? connectionString = builder.Configuration.GetConnectionString("Hospital");
builder.Services.AddDbContext<HospitalContext>(options =>
    options.UseSqlServer(connectionString));

#endregion

#region Repos

builder.Services.AddScoped<IDoctorsRepo, DoctorsRepo>();
builder.Services.AddScoped<IIssuesRepo, IssuesRepo>();
builder.Services.AddScoped<IPatientsRepo, PatientsRepo>();

#endregion

#region Unit of work

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region Managers

builder.Services.AddScoped<IDoctorsManager, DoctorsManager>();

#endregion

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