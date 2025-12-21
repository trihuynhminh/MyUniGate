using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniGate.Shared.DTOs
{
    public class ComboWithSubjectsDto
    {
        public string Code { get; set; } = "";
        public List<string> Subjects { get; set; } = new();
    }
}
