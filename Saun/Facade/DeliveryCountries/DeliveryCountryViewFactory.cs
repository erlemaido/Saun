using Aids.Methods;

namespace Facade.DeliveryCountries
{
    public class DeliveryCountryViewFactory
    {
        public static DeliveryCountry Create(DeliveryCountryView view)
        {
            var deliveryCountryData = new DeliveryCountryData();
            // {
            //     Id = view.Id ?? Guid.NewGuid().ToString(),
            //     Description = view.Description,
            //     Name = view.Name
            // };
            Copy.Members(view, deliveryCountryData);
            return new DeliveryCountry(deliveryCountryData);
        }

        public static DeliveryCountryView Create(DeliveryCountry country)
        {
            var view = new DeliveryCountryView();
            Copy.Members(country.Data, view);
            return view;
        }
    }
}
