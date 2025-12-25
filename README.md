# UniGate – Ứng dụng định hướng ngành học

Ứng dụng **UniGate** là hệ thống Desktop hỗ trợ **học sinh THPT** trong việc  
**định hướng nghề nghiệp và xét tuyển Đại học**, kết hợp giữa **trắc nghiệm tính cách RIASEC**,  
**phân tích điểm số** và **dữ liệu tuyển sinh thực tế** để đưa ra các gợi ý ngành học phù hợp.

---

## Thông tin đồ án
- **Môn học:** Lập trình Mạng Căn Bản  
- **Lớp:** NT106.Q14  
- **Giảng viên hướng dẫn:** ThS. Lê Minh Khánh Hội  
- **Trường:** Đại học Công Nghệ Thông Tin – ĐHQG TP.HCM  

---

## Thông tin các thành viên

| Tên thành viên | MSSV |
|---------------|------|
| Huỳnh Minh Trí | 24521831 |
| Khương Thành Lên | 24520949 |
| Huỳnh Hoàng Tứ Văn | 24521977 |
| Trần Kim Ngân | 24521135 |
| Lê Nguyễn Phương Vy | 24522056 |

---

## Mục tiêu đề tài
- Hỗ trợ học sinh **chọn ngành – chọn trường phù hợp với năng lực**
- Giảm rủi ro **trượt nguyện vọng hoặc chọn sai ngành**
- Cá nhân hóa tư vấn dựa trên **điểm số + sở thích cá nhân**

---

## Chức năng chính

### Phân hệ Người dùng (Học sinh)
- Đăng ký, đăng nhập, quên mật khẩu
- Làm trắc nghiệm hướng nghiệp **RIASEC (Holland)**
- Nhập điểm học bạ / điểm thi
- Xem **phân vị – trung vị điểm số**
- Gợi ý ngành học theo:
  - Sở thích cá nhân
  - Khối xét tuyển
  - Mức độ **An toàn / Cạnh tranh / Mạo hiểm**

### Phân hệ Quản trị viên (Admin)
- Quản lý Trường – Ngành – Điểm chuẩn
- Quản lý ngân hàng câu hỏi trắc nghiệm
- Import dữ liệu phổ điểm
- Quản lý tài khoản người dùng

---

## Kiến trúc & Công nghệ sử dụng
- **Client:** C# .NET Windows Forms  
- **Backend:** ASP.NET Core Web API (RESTful)
- **Database:** MySQL
- **ORM:** Entity Framework Core
- **Kiến trúc:** Layered Architecture + Clean Architecture
- **Giao tiếp:** HTTP / HTTPS, JSON
- **Email:** SMTP (Gmail / SendGrid)

---

## Yêu cầu kỹ thuật
- Mật khẩu được **băm (Bcrypt)**, không lưu plain text
- Phân quyền rõ ràng giữa **User / Admin**
- Chống **SQL Injection** (EF Core / Parameterized Query)
- Hiệu năng:
  - Thao tác cơ bản: **< 1 giây**
  - Truy vấn phức tạp: **< 3 giây**

---

## Hướng phát triển
- Phát triển **Mobile App / Web App** (MAUI, React, Blazor)
- Tích hợp **AI Chatbot** tư vấn ngành học
- Dự báo điểm chuẩn bằng **Machine Learning**
- Mở rộng dữ liệu tuyển sinh toàn quốc

---

## Liên kết
-  **Video báo cáo:**  
  https://drive.google.com/drive/folders/17X4PAghnMXwdcSB-PRFSFR8_lc3NzjxJ?usp=drive_link  
-  **Source Code:**  
  https://github.com/trihuynhminh/MyUniGate

---

*UniGate được xây dựng với định hướng mở rộng, dễ bảo trì và phù hợp cho các hệ thống tư vấn tuyển sinh quy mô lớn trong tương lai.*
