using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniGate.Shared.DTOs
{
    public class UserComboSelectRequest
    {
        public int UserId { get; set; }
        public List<string>? GroupNames { get; set; } // ví dụ: ["A00", "A01", "D01"]
    }
}
