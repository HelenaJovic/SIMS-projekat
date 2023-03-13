using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InitialProject.Repository
{
    internal class LocationRepository
    {
        private const string FilePath = "../../../Resources/Data/locations.csv";

        private readonly Serializer<Location> _serializer;

        private List<Location> _locations;

        public LocationRepository()
        {
            _serializer = new Serializer<Location>();
            _locations = _serializer.FromCSV(FilePath);
        }

        public List<Location> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public List<string> GetAllCities()
        {
            List<string> cities = new List<string>();
            foreach (var location in _locations)
            {
                cities.Add(location.City);
            }
            return cities;
        }
        public List<string> GetAllCountries() 
        {
            List<string> countries = new List<string>();

            foreach (var location in _locations)
            {
                if(!countries.Contains(location.Country))
                    countries.Add(location.Country);
            }
            return countries;
        }
        //da li nam je potrebno ovo sve
        public Location Save(Location location)
        {
            if (!IsSaved(location)){
                location.Id = NextId();
                _locations = _serializer.FromCSV(FilePath);
                _locations.Add(location);
                _serializer.ToCSV(FilePath, _locations);
            }
            return location;
        }

        public bool IsSaved(Location location)
        {
            _locations = _serializer.FromCSV(FilePath);
            Location current = _locations.Find(c => c.City == location.City);
            if (current != null)
                return true;
            else
                return false;
        }


        public int NextId()
        {
            _locations = _serializer.FromCSV(FilePath);
            if (_locations.Count < 1)
            {
                return 1;
            }
            return _locations.Max(c => c.Id) + 1;
        }

        public void Delete(Location location)
        {
            _locations = _serializer.FromCSV(FilePath);
            Location founded = _locations.Find(c => c.Id == location.Id);
            _locations.Remove(founded);
            _serializer.ToCSV(FilePath, _locations);
        }

        public Location GetByCity(string city)
        {
            _locations = _serializer.FromCSV(FilePath);
            return _locations.Find(c => c.City == city);
        }

        public Location Update(Location location)
        {
            _locations = _serializer.FromCSV(FilePath);
            Location current = _locations.Find(c => c.Id == location.Id);
            int index = _locations.IndexOf(current);
            _locations.Remove(current);
            _locations.Insert(index, location);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _locations);
            return location;
        }

    }
}
