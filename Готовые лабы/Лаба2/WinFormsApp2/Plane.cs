using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2
{
    public class DateTimeConverterWithoutTime : IsoDateTimeConverter
    {
        public DateTimeConverterWithoutTime()
        {
            DateTimeFormat = "dd-MM-yyyy"; 
        }
    }

    public class YearOnlyDateTimeConverter : IsoDateTimeConverter
    {
        public YearOnlyDateTimeConverter()
        {
            DateTimeFormat = "yyyy"; 
        }
    }

    internal class Plane
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "workers")]
        public List<Worker> Workers { get; set; } = new List<Worker>();

        [JsonProperty(PropertyName = "numberOfPlace")]
        public int NumberOfPlace { get; set; }

        [JsonProperty(PropertyName = "carrying")]
        public int Carrying { get; set; }

        [JsonProperty(PropertyName = "yearOfManufacture")]
        [JsonConverter(typeof(YearOnlyDateTimeConverter))]
        public DateTime YearOfManufacture { get; set; }

        [JsonProperty(PropertyName = "technicalInspection")]
        [JsonConverter(typeof(DateTimeConverterWithoutTime))]
        public DateTime TechnicalInspection { get; set; }

        public Plane(string ID, string type, string model, List<Worker> crew, int numberOfPlace, int carrying, DateTime yearOfManufacture, DateTime technicalInspection)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                this.ID = ID;
            }
            else
            {
                this.ID = "1";
            }
            this.Type = type;
            this.Model = model;
            this.Workers = crew;
            this.NumberOfPlace = numberOfPlace;
            this.Carrying = carrying;
            this.YearOfManufacture = yearOfManufacture;
            this.TechnicalInspection = technicalInspection;
        }
    }
}
