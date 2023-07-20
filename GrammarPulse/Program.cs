using GrammarPulse.BLL.Repositories;
using GrammarPulse.BLL.Services;
using GrammarPulse.DAL.Database;
using GrammarPulse.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<GrammarPulseDbContext>(options => options.UseSqlServer(dbConfig));

builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IVersionRepository, VersionRepository>();

builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyOrigin());

app.MapControllers();

app.Run();