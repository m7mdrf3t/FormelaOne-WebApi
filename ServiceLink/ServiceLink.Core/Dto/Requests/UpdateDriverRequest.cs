namespace ServiceLink.Core.Dto.Requests;

public class UpdateDriverRequest
{
    public Guid DriveID { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string LastName {get; set;} = string.Empty;
    public int DriverNumber {get; set;}
    public DateTime DateOfBirth {get; set;}
}
