namespace DentalRJ.Services.Params;

public class GenericParams
{
    public string? Status {get; set;} = string.Empty;
    public int PageNumber { get; set; } = 1; 
    public int PageSize { get; set; } = 100; 
}