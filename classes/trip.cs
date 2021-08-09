using System;
using System.Collections.Generic;
using System.Linq;

namespace drone_delivery.classes
{
    public class trip
    {
        public string droneName { get; set; }
        public List<String> locationNames { get; set; }
        public int tripId { get; set; }

        public static List<trip> trips { get; set; }

        public static string currdroneName { get; set; }

        public static void addTrip(string droneNameIn, string locationNameIn)
        {
            if (trips == null)
            {
                trips = new List<trip>();
                currdroneName = droneNameIn;
                insertTrip(droneNameIn, locationNameIn);
                return;
            }

            if (currdroneName == droneNameIn)
            {
                var lasTrip = trips.Max(x => x.tripId);
                int indice = trips.FindIndex(element => element.droneName == droneNameIn && element.tripId == lasTrip);
                if (indice > -1)
                {
                    trips[indice].locationNames.Add(locationNameIn);
                }

            }
            else
            {
                var lasTrip = trips.Max(x => x.tripId);
                int indice = trips.FindIndex(element => element.droneName == droneNameIn && element.tripId == lasTrip);
                if (indice > -1)
                {
                    trips[indice].locationNames.Add(locationNameIn);
                }
                else
                {
                    insertTrip(droneNameIn, locationNameIn);
                }
            }
            currdroneName = droneNameIn;
        }

        private static void insertTrip(string droneNameIn, string locationNameIn)
        {
            trip tripToAdd = new trip();
            tripToAdd.tripId = trips.FindAll(element => element.droneName == droneNameIn).Count + 1;
            tripToAdd.droneName = droneNameIn;
            tripToAdd.locationNames = new List<String>();
            tripToAdd.locationNames.Add(locationNameIn);
            trips.Add(tripToAdd);
        }
    }



}