using Microsoft.EntityFrameworkCore;
using UniGate.API.Controllers;
using UniGate.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// 1. KẾT NỐI SqlServer
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


// 1. Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // cho phép tất cả origin
              .AllowAnyHeader()   // cho phép tất cả headers
              .AllowAnyMethod();  // cho phép tất cả phương thức
    });
});

// 2. Add Controllers, Swagger, DbContext...
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Use CORS
app.UseCors("AllowAll");

// 4. Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
