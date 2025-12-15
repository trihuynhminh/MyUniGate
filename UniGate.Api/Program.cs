using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UniGate.Api.Services;
using UniGate.API.Controllers;
using UniGate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 1. KẾT NỐI SqlServer
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});



if (databaseProvider == "SqlServer")
{
    // MÁY BẠN: Dùng SQL Server
    connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    // MÁY TRÍ: Dùng MySQL (Mặc định)
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}

// --- 2. CẤU HÌNH DỊCH VỤ ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký Service
builder.Services.AddScoped<MajorService>();
// builder.Services.AddScoped<UserService>(); // (Nếu có thì uncomment)

var app = builder.Build();

// --- 3. CẤU HÌNH PIPELINE ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();