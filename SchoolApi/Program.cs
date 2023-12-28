using SchoolApi.Models;
using SchoolApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SchoolDatabaseSettings>(
    builder.Configuration.GetSection("SchoolDatabase")
);

builder.Services.AddSingleton<StudentsService>();
builder.Services.AddSingleton<TeachersService>();
builder.Services.AddSingleton<ClassesService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
