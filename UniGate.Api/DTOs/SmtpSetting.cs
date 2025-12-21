namespace UniGate.Api.DTOs
{
    public class SmtpSettings
    {
        public string Host { get; set; } = "";
        public int Port { get; set; }
        public string User { get; set; } = "";
        public string AppPassword { get; set; } = "";
        public string FromName { get; set; } = "";
        public string FromEmail { get; set; } = "";
    }
}
