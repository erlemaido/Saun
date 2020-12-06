using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions;

namespace Domain.DeliveryCountries
{
    public interface IDeliveryCountries : IRepository<DeliveryCountry>
    {
    }
}
