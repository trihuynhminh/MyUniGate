using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HollandSubmitResponse
{
    public Dictionary<string, int> Scores { get; set; }
    public string HollandCode { get; set; }
    public string Description { get; set; }
    public string CareerSuggestions { get; set; }
}
