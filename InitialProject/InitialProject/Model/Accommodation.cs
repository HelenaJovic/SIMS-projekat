using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
	public class Accommodation : ISerializable
	{

		public int Id { get; set; }

		public string Name { get; set; }

		public int IdLocation { get; set; }
		public Location Location { get; set; }

		public AccommodationType Type { get; set; }

		public int MaxGuestNum { get; set; }

		public int MinReservationDays { get; set; }

		public int DaysBeforeCancel { get; set; }

		public List<Image> Images	{get; set;}

		public int IdUser { get; set; }




		public Accommodation(string name, int idLocation,Location location, AccommodationType type, int maxGuestNum, int minResevationDays, int daysBeforeCancel, int idUser)


		{
			this.Name = name;
			this.IdLocation = idLocation;
			this.Location = location;
			this.Type = type;
			this.MaxGuestNum = maxGuestNum;
			this.MinReservationDays=minResevationDays;
			this.DaysBeforeCancel = daysBeforeCancel;
			this.IdUser= idUser;


    }

		


		public Accommodation()
		{

		}

		public void FromCSV(string[] values)
		{
			Id = int.Parse(values[0]);
			Name = values[1];
		    IdLocation=int.Parse(values[2]);
			Location = new Location(values[3], values[4]);
			Type = (AccommodationType)Enum.Parse(typeof(AccommodationType), values[5]);
			MaxGuestNum = int.Parse(values[6]);
			MinReservationDays = int.Parse(values[7]);
			DaysBeforeCancel=int.Parse(values[8]);
		    IdUser = int.Parse(values[9]);



		}


		public string[] ToCSV()
		{
			string[] csvValues =
			{
				Id.ToString(),
				Name,
				Location.Id.ToString(),
				Location.City,
				Location.Country,
				Type.ToString(),
				MaxGuestNum.ToString(),
				MinReservationDays.ToString(),
				DaysBeforeCancel.ToString(),
				IdUser.ToString()



			};
			return csvValues;
		}

	}
}