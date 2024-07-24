namespace ServiceLink.Core.Dto.Responses;

public class GetDriveResponce
{
    public Guid DriveID { get; set; }
    public string Fullname { get; set; }
    public int DriverNumber {get; set;}
    public DateTime DateOfBirth {get; set;}


}
