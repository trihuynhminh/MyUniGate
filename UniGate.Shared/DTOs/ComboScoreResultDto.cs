namespace UniGate.Shared.DTOs;


public class ComboScoreResultDto
{
  
    public string Code { get; set; } = string.Empty;

    
    public decimal Score { get; set; }

    
    public string Detail { get; set; } = string.Empty;

    // Thông báo/tin nhắn hiển thị lỗi hoặc mô tả cách tính ưu tiên (tiếng Việt)
    public string Note { get; set; } = string.Empty;
}
