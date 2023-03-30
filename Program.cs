using thepathbackend.Services;
using thepathbackend.Services.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BlogService>();
builder.Services.AddScoped<PasswordService>();

//how we connect database to api
var connectionString = builder.Configuration.GetConnectionString("ThePathString");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

//adding cors policy to a website
builder.Services.AddCors(options => {
options.AddPolicy("BlogPolicy", 
    builder => {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
    );
});

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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
