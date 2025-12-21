using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniGate.Shared.DTOs
{
    public class AdmissionUpsertRequest
    {
        public int UniversityID { get; set; }
        public int MajorID { get; set; }
        public short Year { get; set; }
        public decimal MinScore { get; set; }

        // ⭐ BẮT BUỘC PHẢI CÓ
        public List<int> GroupIds { get; set; } = new();
    }
}
