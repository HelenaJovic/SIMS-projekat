using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InitialProject.Model
{
    internal class Tour : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int MaxGuestNum { get; set; }
        public List<TourPoint> Points { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public List<Image> Images { get; set; }
        public int FreeSetsNum { get; set; }
        public bool Active { get; set; }

        public Tour()
        {
            Points = new List<TourPoint>();
            Images = new List<Image>();
        }

        public Tour(int id, string name, string language, int maxGuestNum, DateTime startDate, DateTime endDate, int duration, int freeSetsNum, bool active)
        {
            Id = id;
            Name = name;
            Language = language;
            MaxGuestNum = maxGuestNum;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            FreeSetsNum = freeSetsNum;
            Active = active;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Name,
                Language,
                MaxGuestNum.ToString(),
                StartDate.ToString(),
                EndDate.ToString(),
                Duration.ToString(),
                FreeSetsNum.ToString(),
                Active.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            Language = values[2];
            MaxGuestNum = int.Parse(values[3]);
            StartDate = DateTime.Parse(values[4]);
            EndDate = DateTime.Parse(values[5]);
            Duration = int.Parse(values[6]);
            FreeSetsNum = int.Parse(values[7]);
            Active = bool.Parse(values[8]);
        }
    }
}
