using System.Collections.Generic;

namespace UniGate.Student.Models
{
    public static class HollandQuestionBank
    {
        public static readonly Dictionary<string, string> GroupDescriptions =
            new()
            {
                { "R", "Thực tiễn – thích làm việc với máy móc, công cụ, kỹ thuật." },
                { "I", "Nghiên cứu – thích phân tích, suy luận, tìm hiểu vấn đề." },
                { "A", "Nghệ thuật – sáng tạo, thẩm mỹ, nghệ thuật." },
                { "S", "Xã hội – giao tiếp, hỗ trợ, giúp đỡ người khác." },
                { "E", "Quản lý – lãnh đạo, kinh doanh, thuyết phục." },
                { "C", "Nghiệp vụ – tổ chức, dữ liệu, quy trình, chi tiết." }
            };
    }
}
