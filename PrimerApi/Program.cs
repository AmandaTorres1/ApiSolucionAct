using Dao_library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<StudentDAO>();
builder.Services.AddScoped<CourseDao>();
builder.Services.AddScoped<ActivityDao>();
builder.Services.AddScoped<PersonDao>();
builder.Services.AddScoped<PlayerDao>();
builder.Services.AddScoped<TeamDao>();
builder.Services.AddScoped<TrainerDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
