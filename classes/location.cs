using System;
using Bogus;

namespace drone_delivery.classes
{
    public class location
    {
        private static int _locationId = 100;
        private static int _subfixName = 1;
        public int locationId { get; set; }
        public String locationName { get; set; }
        public Decimal packageWeight { get; set; }

        public static Faker<location> FakeDataLocation { get; } =
            new Faker<location>()
                .RuleFor(p => p.locationId, f => _locationId++)
                .RuleFor(p => p.locationName, f => "Location #" + _subfixName++)
                .RuleFor(p => p.packageWeight, f => f.Random.Decimal(1, 500));
    }
}