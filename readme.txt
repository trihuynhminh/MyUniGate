# UniGate – Ứng dụng định hướng ngành học

**UniGate** là ứng dụng Desktop hỗ trợ học sinh THPT trong quá trình **định hướng nghề nghiệp và xét tuyển Đại học**, kết hợp giữa **trắc nghiệm tính cách RIASEC**, **phân tích điểm số** và **dữ liệu tuyển sinh thực tế** để đưa ra các gợi ý ngành học phù hợp.

## Thông tin đồ án
- **Môn học:** Lập trình Mạng Căn Bản  
- **Lớp:** NT106.Q14  
- **Giảng viên hướng dẫn:** ThS. Lê Minh Khánh Hội  
- **Trường:** ĐH Công Nghệ Thông Tin – ĐHQG TP.HCM  

## Thành viên nhóm
- Huỳnh Minh Trí – 24521831  
- Khương Thành Lên – 24520949  
- Huỳnh Hoàng Tứ Văn – 24521977  
- Trần Kim Ngân – 24521135  
- Lê Nguyễn Phương Vy – 24522056  

## Mục tiêu
- Hỗ trợ học sinh **chọn ngành – chọn trường phù hợp**
- Giảm rủi ro trượt nguyện vọng hoặc chọn sai ngành
- Cá nhân hóa tư vấn dựa trên **năng lực + sở thích**

## Chức năng chính
### Người dùng (Học sinh)
- Đăng ký, đăng nhập, quên mật khẩu
- Trắc nghiệm hướng nghiệp **RIASEC (Holland)**
- Nhập điểm học bạ / điểm thi
- Xem **phân vị – trung vị điểm số**
- Gợi ý ngành theo:
  - Sở thích
  - Khối thi
  - Mức độ An toàn / Cạnh tranh / Mạo hiểm

### Quản trị viên (Admin)
- Quản lý Trường – Ngành – Điểm chuẩn
- Quản lý ngân hàng câu hỏi trắc nghiệm
- Import dữ liệu phổ điểm
- Quản lý người dùng

## Kiến trúc & Công nghệ
- **Client:** C# .NET Windows Forms  
- **Backend:** ASP.NET Core Web API (RESTful)
- **Database:** MySQL
- **ORM:** Entity Framework Core
- **Kiến trúc:** Layered Architecture + Clean Architecture
- **Giao tiếp:** HTTP/HTTPS, JSON
- **Email:** SMTP (Gmail / SendGrid)

## Yêu cầu kỹ thuật
- Mật khẩu được **băm (Bcrypt)**
- Phân quyền User / Admin
- Chống SQL Injection (EF Core / Parameterized Query)
- Thời gian phản hồi:
  - Thao tác cơ bản: < 1s
  - Truy vấn phức tạp: < 3s

## Hướng phát triển
- Mobile App / Web App (MAUI, React, Blazor)
- AI Chatbot tư vấn ngành học
- Dự báo điểm chuẩn bằng Machine Learning
- Mở rộng dữ liệu tuyển sinh toàn quốc

## Liên kết
- Video báo cáo:  
  https://drive.google.com/drive/folders/17X4PAghnMXwdcSB-PRFSFR8_lc3NzjxJ?usp=drive_link
- Source Code:  
  https://github.com/trihuynhminh/MyUniGate

---
 *UniGate được xây dựng với định hướng mở rộng, dễ bảo trì và phù hợp cho các hệ thống tư vấn tuyển sinh quy mô lớn trong tương lai.*
