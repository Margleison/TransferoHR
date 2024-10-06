using System.ComponentModel.Design;
using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class Clinic : NamedBaseEntity
	{
		public Guid CompanyId { get; set; }
        public Company? Company { get; set; }


    }
}

