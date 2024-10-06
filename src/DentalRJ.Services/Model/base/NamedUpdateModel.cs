namespace DentalRJ.Services.Model.Base;

public class NamedUpdateModel : BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }= String.Empty;
}