using System.Collections.Generic;

namespace UniGate.Student.Models
{
    public class HollandSubmitResponse
    {
        public Dictionary<string, int> Scores { get; set; } = new();

        public string HollandCode { get; set; } = "";

        public string Description { get; set; } = "";

        public string CareerSuggestions { get; set; } = "";
    }
}
