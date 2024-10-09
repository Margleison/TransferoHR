namespace DentalRJ.Services.Model.Base;

public class GetModel : BaseModel
{
  public Guid Id { get; set; }
  public string Status { get; set; } = String.Empty;
  public DateTime CreatedAt { get; set; } 
  public string CreatedBy { get; set; } = String.Empty;
  public DateTime? UpdatedAt { get; set; }
  public string? UpdatedBy { get; set; } = String.Empty;
}