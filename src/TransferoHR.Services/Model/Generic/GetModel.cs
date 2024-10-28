namespace TransferoHR.Services.Model.Generic;

public class GetModel : GenericModel
{
  public Guid Id { get; set; }
  public string Status { get; set; } = String.Empty;
  public DateTime CreatedAt { get; set; } 
  public string CreatedBy { get; set; } = String.Empty;
  public DateTime? UpdatedAt { get; set; }
  public string? UpdatedBy { get; set; } = String.Empty;
}