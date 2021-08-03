using System;
using System.Collections.Generic;

namespace drone_delivery.classes
{
    public class trip
    {
        public string droneName { get; set; }
        public List<String> locationNames { get; set; }
        public int tripId { get; set; }

        public static List<trip> trips { get; set; }

        public static void addTrip(string droneNameIn, string locationNameIn)
        {
            if (trips == null)
            {
                trips = new List<trip>();
            }
            int result = trips.FindIndex(element => element.droneName == droneNameIn);
            if (result > -1 && trips.FindAll(elementt => elementt.droneName == droneNameIn).Count == trips[result].locationNames.Count)
            {
                if (trips[result].locationNames == null)
                {
                    trips[result].locationNames = new List<String>();
                }
                trips[result].locationNames.Add(locationNameIn);
                return;
            }
            trip tripToAdd = new trip();

            tripToAdd.tripId = trips.FindAll(element => element.droneName == droneNameIn).Count + 1;
            tripToAdd.droneName = droneNameIn;
            tripToAdd.locationNames = new List<String>();
            tripToAdd.locationNames.Add(locationNameIn);

            trips.Add(tripToAdd);
        }
    }


}