using System;
using System.Collections.Generic;
using System.Linq;
using drone_delivery.classes;
using Newtonsoft.Json;


namespace drone_delivery
{
    class Program
    {
        public String name = "";
        static void Main(string[] args)
        {
            drone dron1 = new drone();
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


            int droneIndex = 0;
            testDataDrone[droneIndex].currentIdTrip = 1;


            testDataDrone[droneIndex].trips = new List<trip>();

            for (int indexLocation = 0; indexLocation < testDataLocation.Count; indexLocation++)
            {
                if (!testDataDrone[droneIndex].fullLoaded(testDataLocation[indexLocation].packageWeight))
                {
                    addLoadToDrone(testDataLocation, indexLocation, testDataDrone, droneIndex);
                }
                else
                {
                    ++droneIndex;

                    if (droneIndex > numberOfDroneRecords - 1)
                    {
                        droneIndex = 0;
                        ++testDataDrone[droneIndex].currentIdTrip;

                    }
                    testDataDrone[droneIndex].currentLoad = 0;
                    addLoadToDrone(testDataLocation, indexLocation, testDataDrone, droneIndex);
                }

                if (droneIndex >= numberOfDroneRecords)
                {
                    droneIndex = 0;
                    ++testDataDrone[droneIndex].currentIdTrip;
                    testDataDrone[droneIndex].currentLoad = 0;
                }



                // Console.WriteLine(testDataDrone[droneIndex].droneName);
                // Console.WriteLine(nroTrp);

            }

            Console.WriteLine(JsonConvert.SerializeObject(testDataDrone,
                 Formatting.Indented));

            //var groupedProducts = testDataDrone.GroupBy(p => p.trips.ToList<trip>);

            foreach (drone adrone in testDataDrone)
            {
                var tripsDatas = new List<trip>();
                foreach (trip atrip in adrone.trips)
                {
                    tripsDatas.Add(atrip);
                }
                Console.WriteLine(adrone.droneName);


                int prevVal = 0;
                for (int indextrip = 0; indextrip < tripsDatas.Count; indextrip++)
                {
                    List<String> listLocDesc = new List<string>();
                    // listLocDesc.Add(tripsDatas[indextrip].locationName);
                    if (indextrip == 0)
                    {
                        prevVal = tripsDatas[indextrip].idTrip;
                    }
                    if (tripsDatas[indextrip].idTrip != prevVal)
                    {
                        Console.WriteLine("Trip #" + tripsDatas[indextrip].idTrip);
                        string concatLocInfo = String.Join(", ", listLocDesc.ToArray());
                        Console.WriteLine(concatLocInfo);
                        listLocDesc = new List<string>();
                    }
                    prevVal = tripsDatas[indextrip].idTrip;
                }
            }

        }

        static void addLoadToDrone(List<location> testDataLocation, int indexLocation, List<drone> testDataDrone, int droneIndex)
        {
            trip tripItem = new trip();
            if (testDataDrone[droneIndex].trips == null)
            {
                testDataDrone[droneIndex].trips = new List<trip>();
                testDataDrone[droneIndex].currentIdTrip = 1;
            }
            tripItem.locationName = testDataLocation[indexLocation].locationName;
            tripItem.idTrip = testDataDrone[droneIndex].currentIdTrip;
            testDataDrone[droneIndex].trips.Add(tripItem);

            testDataDrone[droneIndex].addLoad(testDataLocation[indexLocation].packageWeight);
        }

    }
}
