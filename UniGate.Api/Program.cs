using Microsoft.EntityFrameworkCore;
using UniGate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 1. KẾT NỐI MYSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 2. CẤU HÌNH DỊCH VỤ (NET 8 CHUẨN)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Bắt buộc cho Swagger
builder.Services.AddSwaggerGen();           // Dùng cái này thay vì AddOpenApi

var app = builder.Build();

// 3. CẤU HÌNH PIPELINE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();     // Tạo file JSON Swagger
    app.UseSwaggerUI();   // Tạo giao diện web để test API
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();