using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PeshoFriends
{
    // Graph node class
    class Facility : IComparable<Facility>
    {
        public int ID { get; set; }
        public double Distance { get; set; }
        public bool IsHospital { get; set; }

        public Facility(int id)
        {
            this.ID = id;
            this.Distance = double.PositiveInfinity;
            this.IsHospital = false;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Facility);
        }

        public bool Equals(Facility other)
        {
            return this.ID.Equals(other.ID);
        }

        public int CompareTo(Facility compareNode)
        {
            int compare = this.Distance.CompareTo((compareNode as Facility).Distance);
            
            return compare;
        }
    }

    // Graph edge class
    class Street
    {
        public Facility LinkedFacility { get; set; }
        public double StreetDistance { get; set; }

        public Street(Facility linkedFacility, double streetDistance)
        {
            this.LinkedFacility = linkedFacility;
            this.StreetDistance = streetDistance;
        }
    }

    // Main Programm
    class Program
    {
        static void Main(string[] args)
        {
            //string initData = "3 2 1";
            //string hospitals = "1";

            //string[] streets = 
            //{
            //    "1 2 1",
            //    "3 2 2"
            //};

            string initData = Console.ReadLine();
            string hospitals = Console.ReadLine();
            
            string[] inputDataSplit = initData.Split(' ');
            string[] hospitalsIDs = hospitals.Split(' ');

            int facilitiesCount = int.Parse(inputDataSplit[0]);
            int streetsCount = int.Parse(inputDataSplit[1]);
            int hospitalsCount = hospitalsIDs.Length;

            string[] streets = new string[streetsCount];
            for (int streetLine = 0; streetLine < streetsCount; streetLine++)
			{
			    streets[streetLine] = Console.ReadLine();
			}

            List<Facility> facilities = new List<Facility>();
            List<Facility> hospitalFacilities = new List<Facility>();

            bool[] hospitalsChecker = new bool[facilitiesCount + 1];
            foreach (var hospID in hospitalsIDs)
            {
                hospitalsChecker[int.Parse(hospID)] = true;
            }

            Facility newFacility;
            for (int i = 1; i <= facilitiesCount; i++)
			{
                newFacility = new Facility(i);
                if (hospitalsChecker[i])
                {
                    newFacility.IsHospital = true;
                    hospitalFacilities.Add(newFacility);
                }
                facilities.Add(newFacility);
            }

            Dictionary<Facility, List<Street>> map = new Dictionary<Facility, List<Street>>();
            foreach (var streetData in streets)
            {
                string[] streetValues = streetData.Split(' ');

                Facility currFacility = facilities[int.Parse(streetValues[0]) - 1];
                Facility targetFacility = facilities[int.Parse(streetValues[1]) - 1];
                double streetDistance = double.Parse(streetValues[2]);

                if (map.ContainsKey(currFacility))
                {
                    map[currFacility].Add(new Street(targetFacility, streetDistance));
                }
                else
                {
                    map.Add(currFacility, new List<Street> { new Street(targetFacility, streetDistance) });
                }
            }

            double minDistance = double.PositiveInfinity;
            double overallDistance = 0;

            foreach (var hospital in hospitalFacilities)
            {
                FindClosestHospital(map, hospital);

                foreach (var item in facilities)
                {
                    Console.WriteLine("{0} -> {1} = {2}", hospital.ID, item.ID, item.Distance);
                }

                for (int i = 0; i < facilities.Count; i++)
                {
                    if (!facilities[i].IsHospital)
                    {
                        overallDistance += facilities[i].Distance;
                    }
                }

                if (overallDistance < minDistance)
                {
                    minDistance = overallDistance;
                }
            }

            Console.WriteLine(minDistance);
        }

        // Dijkstra Find shortest path
        private static void FindClosestHospital(Dictionary<Facility, List<Street>> map, Facility hospital)
        {
            PriorityQueue<Facility> queue = new PriorityQueue<Facility>();
            
            foreach (var streetFacility in map)
            {
                if (hospital.ID != streetFacility.Key.ID)
                {
                    streetFacility.Key.Distance = double.PositiveInfinity;
                    queue.Enqueue(streetFacility.Key);                    
                }
            }
             
            hospital.Distance = 0;
            queue.Enqueue(hospital);

            while (queue.Count > 0)
            {
                Facility currFacility = queue.Peek();
            
                if (currFacility.Distance == double.PositiveInfinity)
                {
                    break;
                }

                foreach (var linkedFacility in map[currFacility])
                {
                    double pottentialDistance = currFacility.Distance + linkedFacility.StreetDistance;

                    if (pottentialDistance < linkedFacility.LinkedFacility.Distance)
                    {
                        linkedFacility.LinkedFacility.Distance = pottentialDistance;
                    }
                }

                queue.Dequeue();
            }
        }
    }
}
