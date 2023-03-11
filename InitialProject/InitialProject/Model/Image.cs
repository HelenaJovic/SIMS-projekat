using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Image : ISerializable

    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int IdUser { get; set; }

		public void FromCSV(string[] values)
		{
			Id=int.Parse(values[0]);
			Url=values[1];
			IdUser=int.Parse(values[2]);

		}

		public string[] ToCSV()
		{
			string[] csvValues =
			{
				Id.ToString(),
				Url,
				IdUser.ToString()
			};
			return csvValues;
				
		}
	}
}
