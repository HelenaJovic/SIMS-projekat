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
       public int IdUser { get; set; }
       
       public int IdAccommodation { get; set; }
        
       public DateOnly StartDate { get; set; }
       public DateOnly EndDate { get; set; }
       
       public int DaysNum { get; set; }
       
       public string AccommodationName { get; set; }

        public AccommodationReservation()
        {

        }

        public AccommodationReservation(int idguest, DateOnly startDate, DateOnly endDate,int daysNum,int IdAccommodation,string accommodationName)
        {
            
            IdUser= idguest;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.DaysNum = daysNum;
            this.IdAccommodation = IdAccommodation;
            this.AccommodationName= accommodationName;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                IdUser.ToString(),
                StartDate.ToString(),
                EndDate.ToString(),
                DaysNum.ToString(),
                IdAccommodation.ToString(),
                AccommodationName.ToString()

            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            IdUser=int.Parse(values[1]);
            StartDate = DateOnly.Parse(values[2]);
            EndDate = DateOnly.Parse(values[3]);
            DaysNum = int.Parse(values[4]);
            IdAccommodation = int.Parse(values[5]);
            AccommodationName=values[6];

        }
    }
}
