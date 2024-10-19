﻿using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model
{
    public class DentalInsuranceUpdateModel: NamedUpdateModel
    {
        public string BrandName { get; set; } = string.Empty;
        public bool NeedAuthorization { get; set; }
        public bool HasReimbursement { get; set; }
        public decimal CoPaymentPercentage { get; set; } = decimal.Zero;
    }
}
