using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class AccommodationReservation:ISerializable
    {
       public int Id { get; set; }
       public int IdGuest { get; set; }
        
       public DateTime startDate { get; set; }
       public DateTime endDate { get; set; }

        public AccommodationReservation()
        {

        }

        public AccommodationReservation(int id, int idguest, DateTime startDate, DateTime endDate)
        {
            Id = id;
            IdGuest = idguest;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                IdGuest.ToString(),
                startDate.ToString(),
                endDate.ToString(),
                
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            IdGuest=int.Parse(values[1]);
            startDate = DateTime.Parse(values[2]);
            endDate = DateTime.Parse(values[3]);
        }
    }
}
