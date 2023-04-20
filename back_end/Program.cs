using GISDemo.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext to the container
builder.Services.AddDbContext<GISDbContext>(options => {
    var dbconfig = builder.Configuration.GetSection("Database");
    string connStr = dbconfig.GetSection("ConnStr").Value;
    options.UseNpgsql(connStr, o => o.UseNetTopologySuite());
});

// Add services to the container.

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
