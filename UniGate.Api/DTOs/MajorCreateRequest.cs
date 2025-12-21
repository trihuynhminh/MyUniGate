using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniGate.Api.DTOs;

namespace UniGate.Api.DTOs
{

    public class MajorCreateRequest
    {
        public string? MajorCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int UniversityID { get; set; }   // ⭐ RẤT QUAN TRỌNG
        public short Year { get; set; }
        public decimal MinScore { get; set; }

        public List<int> GroupIds { get; set; } = new();
    }


}
