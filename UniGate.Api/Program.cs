using Microsoft.EntityFrameworkCore;
using UniGate.API.Controllers;
using UniGate.Infrastructure;
using UniGate.Api.Services;


var builder = WebApplication.CreateBuilder(args);

// 1. KẾT NỐI MYSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// 2. CẤU HÌNH DỊCH VỤ (NET 8 CHUẨN)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký Service (Chỉ cần 1 dòng này là đủ, nãy bị thừa)
builder.Services.AddScoped<MajorService>();

var app = builder.Build();

// 3. CẤU HÌNH PIPELINE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
