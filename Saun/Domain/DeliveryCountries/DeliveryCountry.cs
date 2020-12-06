using System;
using System.Collections.Generic;
using System.Text;
using Data.DeliveryCountry;
using Domain.Abstractions;

namespace Domain.DeliveryCountries
{
    public sealed class DeliveryCountry : NamedEntity<DeliveryCountryData>
    {
        public DeliveryCountry() : this(null)
        {

        }

        public DeliveryCountry(DeliveryCountryData data) : base(data)
        {

        }
    }
}
