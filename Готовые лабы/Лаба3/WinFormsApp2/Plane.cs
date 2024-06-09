using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [ID]
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Crew is required.")]
        [MinLength(1, ErrorMessage = "Crew is required.")]
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-------------------------------------------------------------------------------\n");
            sb.Append($" ID: {ID}\n Тип: {Type}\n Модель: {Model}\n Пассажирские места: {NumberOfPlace}\n Грузоподъемность: {Carrying}\n Год выпуска: {YearOfManufacture} \n Последнее техническое обслуживание: {TechnicalInspection}\n");
            sb.Append(" Экипаж:\n ");
            foreach (var worker in Workers)
            {
                sb.Append($"{worker.ToString()}\n");
            }
            return sb.ToString();
        }
    }
}
