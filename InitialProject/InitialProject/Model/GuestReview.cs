using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
	public class GuestReview : ISerializable
	{
		public int Id { get; set; }

		public int IdOwner { get; set; }

		public int IdGuest { get; set; }

		public int CleanlinessGrade { get; set; }

		public int RuleGrade { get; set; }

		public GuestReview()
		{

		}

		public GuestReview(int idOwner, int idGuest, int cleanlinessGrade, int ruleGrade)
		{
			this.IdOwner=idOwner;
			this.IdGuest=idGuest;
			this.CleanlinessGrade=cleanlinessGrade;
			this.RuleGrade=ruleGrade;

		}

		public void FromCSV(string[] values)
		{
			Id=int.Parse(values[0]);
			IdOwner=int.Parse(values[1]);
			IdGuest=int.Parse(values[2]);
			CleanlinessGrade=int.Parse(values[3]);
			RuleGrade=int.Parse(values[4]);


		}

		public string[] ToCSV()
		{
			string[] csvValues =
			{
				Id.ToString(),
				IdOwner.ToString(),
				IdGuest.ToString(),
				CleanlinessGrade.ToString(),
				RuleGrade.ToString()


			};
			return csvValues;
		}
	}
}
