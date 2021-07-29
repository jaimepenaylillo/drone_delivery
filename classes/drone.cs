using System;
using System.Collections.Generic;
using Bogus;

namespace drone_delivery.classes
{
    class drone
    {
        private static int _droneId = 100;
        private static int _subfixName = 1;
        public int droneId { get; set; }
        public String droneName { get; set; }
        public Decimal carryMaxWeigth { get; set; }
        public Decimal currentLoad { get; set; }
        public int currentIdTrip { get; set; }
        public List<trip> trips { get; set; }

        public Boolean fullLoaded(Decimal fackeLoad = 0)
        {
            Decimal dronLoad = fackeLoad + currentLoad;

            if (dronLoad > carryMaxWeigth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Decimal addLoad(Decimal amount)
        {
            currentLoad = currentLoad + amount;
            return currentLoad;
        }



        /// <summary>Generate Fake Data for drones, in odder to test 
        /// the solution, using Bogus.</summary>

        public static Faker<drone> FakeData { get; } =
            new Faker<drone>()
                .RuleFor(p => p.droneId, f => _droneId++)
                .RuleFor(p => p.droneName, f => "Drone #" + _subfixName++)
                .RuleFor(p => p.carryMaxWeigth, f => f.Random.Decimal(500, 1000));

    }


}