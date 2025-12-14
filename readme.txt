Vì MySQL và MSSQL tạo bảng khác nhau, nên không thể dùng chung 1 thư mục Migrations được.

Cách giải quyết êm đẹp nhất:

1. Sửa file appsettings.json (ghi đè): 

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "DatabaseProvider": "SqlServer"",

  "ConnectionStrings": {

    "SqlServerConnection": "Server=.\\SQLEXPRESS;Database=UniGateDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

2. Cài gói thư viện
Tại thư mục gốc (UniGate), mở terminal (ctrl + `) gõ:

dotnet add UniGate.Api package Microsoft.EntityFrameworkCore.SqlServer
dotnet add UniGate.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer

3. Quy trình chạy lệnh

Vào thư mục UniGate.Infrastructure -> Xóa folder Migrations cũ đi.
Mở Terminal tại thư mục gốc của dự án, gõ;

cd UniGate.Infrastructure
dotnet ef migrations add InitialMssql --startup-project ../UniGate.Api
dotnet ef database update --startup-project ../UniGate.Api