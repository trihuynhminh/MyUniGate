using System.Collections.Generic;

namespace UniGate.Shared.DTOs;


public class ComboInfoDto
{
    
    public string Code { get; set; } = string.Empty;

    
    public List<string> Subjects { get; set; } = new();
}
