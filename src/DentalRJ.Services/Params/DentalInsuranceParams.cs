namespace DentalRJ.Services.Params
{
    public class DentalInsuranceParams : NamedParams
    {
        public string? BrandName { get; set; } = string.Empty;
        public bool? NeedAuthorization { get; set; }
        public bool? HasReimbursement { get; set; }
        public bool? HasCoPaymentPercentage { get; set; }
    }
}
