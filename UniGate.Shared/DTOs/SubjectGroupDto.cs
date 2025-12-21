using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniGate.Shared.DTOs
{
    public class SubjectGroupDto
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; } = "";
        public string Subjects { get; set; } = "";
    }
}
