using GrammarPulse.BLL.Repositories;
using GrammarPulse.BLL.Services;
using GrammarPulse.DAL.Database;
using GrammarPulse.DAL.Repositories;
using GrammarPulse.Infrasructure.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    o.SecurityTokenValidators.Clear();
    o.SecurityTokenValidators.Add(new GoogleTokenValidator(builder.Configuration["Authentication:Google:ClientId"]));
});

builder.Services.AddAuthorization();

var dbConfig = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<GrammarPulseDbContext>(options => options.UseSqlServer(dbConfig));

builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IVersionRepository, VersionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICompletedTopicRepository, CompletedTopicRepository>();

builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICompletedTopicService, CompletedTopicService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();