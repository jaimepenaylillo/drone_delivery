using System;
using System.Collections.Generic;
using System.Linq;
using drone_delivery.classes;



namespace drone_delivery
{
    class Program
    {
        public String name = "";
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static bool isOdd(int x)
        {
            return x % 2 == 1;
        }
        static void Main(string[] args)
        {
            /// <summary>Change value of Generate(2), in order to generate more fake Dron Data </summary>
            int numberOfDroneRecords = 2;
            /// <summary>Change value of Generate(2), in order to generate more fake Location Data </summary>
            int numberOfLocationRecords = 10;

            var testDataDrone = drone.FakeData.Generate(numberOfDroneRecords).ToList();
            var testDataLocation = location.FakeDataLocation.Generate(numberOfLocationRecords).ToList();

            List<string> listDroneDesc = new List<string>();
            foreach (drone aDrone in testDataDrone)
            {
                listDroneDesc.Add(aDrone.droneName + ", " + aDrone.carryMaxWeigth.ToString());
            }

            string concatDroneInfo = String.Join(", ", listDroneDesc.ToArray());
            Console.WriteLine(concatDroneInfo);

            foreach (location aLocation in testDataLocation)
            {
                Console.WriteLine(aLocation.locationName + ", " + aLocation.packageWeight.ToString());
            }


            /// <summary> To minimize the number of trips, we will maximize the maximum amount of cargo 
            ///           for the drone and minimize the weight of deliveries.
            ///           For this we order the fleet of drones with more capacity and order the weight 
            ///           of the loads from lowest to highest;
            ///</summary>

            testDataDrone.Sort(delegate (drone x, drone y)
            {
                return y.carryMaxWeigth.CompareTo(x.carryMaxWeigth);
            });

            testDataLocation.Sort(delegate (location x, location y)
            {
                return x.packageWeight.CompareTo(y.packageWeight);
            });

            var droneIndex = 0;

            while (testDataLocation != null && testDataLocation.Count() > 0)
            {
                if (droneIndex > numberOfDroneRecords - 1) droneIndex = 0;
                drone.loadToDrone(testDataLocation, testDataDrone[droneIndex]);
                ++droneIndex;
                testDataLocation = testDataLocation.Where(p => p.delivered == false).ToList();
            }

            trip.trips.Sort(delegate (trip x, trip y)
            {
                return x.droneName.CompareTo(y.droneName);
            });

            foreach (var item in trip.trips.ToList())
            {
                Console.WriteLine(item.droneName);
                Console.WriteLine(item.tripId);
                string concatDroneInfo1 = String.Join(", ", item.locationNames.ToArray());
                Console.WriteLine(concatDroneInfo1);
            }
        }


    }
}
