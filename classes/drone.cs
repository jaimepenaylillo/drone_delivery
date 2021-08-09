using System;
using System.Collections.Generic;
using System.Linq;
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


        /// <summary>Generate Fake Data for drones, in odder to test 
        /// the solution, using Bogus.</summary>

        public static Faker<drone> FakeData { get; } =
            new Faker<drone>()
                .RuleFor(p => p.droneId, f => _droneId++)
                .RuleFor(p => p.droneName, f => "Drone #" + _subfixName++)
                .RuleFor(p => p.carryMaxWeigth, f => f.Random.Decimal(500, 1000));


        public static void loadToDrone(List<location> testDataLocation, drone itemDrone)
        {
            {
                decimal currentWeigth = 0;
                for (var i = 0; i <= testDataLocation.Count() - 1; i++)
                {
                    currentWeigth += testDataLocation[i].packageWeight;
                    if (currentWeigth <= itemDrone.carryMaxWeigth)
                    {
                        testDataLocation[i].delivered = true;
                        trip.addTrip(itemDrone.droneName, testDataLocation[i].locationName);
                    }
                    else
                    {
                        testDataLocation[i].delivered = false;
                        return;
                    }
                }
            }
        }

    }




}