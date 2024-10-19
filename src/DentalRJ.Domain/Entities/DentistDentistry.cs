using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalRJ.Domain.Entities
{
    public class DentistDentistry
    {
        public Guid DentistryId { get; set; }
        public Guid DentistId { get; set; }

        public required Dentistry Dentistry { get; set; }
        public required Dentist Dentist { get; set; }
    }
}
