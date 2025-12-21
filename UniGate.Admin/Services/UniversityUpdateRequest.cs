using UniGate.Admin.Services;

namespace UniGate.Admin.Services;

public class UniversityUpdateRequest : UniversityCreateRequest
{
    public int UniversityID { get; set; }
}
