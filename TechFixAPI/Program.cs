using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TechFixAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = "Data Source=DESKTOP-SCEAP9U;Initial Catalog=techfix;Integrated Security=True;Trust Server Certificate=True";
builder.Services.AddDbContext<AppDBContext>
            (options => options.UseSqlServer(conn));

builder.Services.AddControllers();
builder.Services.AddScoped<StockRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
