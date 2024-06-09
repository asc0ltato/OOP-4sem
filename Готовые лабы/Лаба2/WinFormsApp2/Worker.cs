using Newtonsoft.Json;

namespace WinFormsApp2
{
    public class Worker
    {
        [JsonProperty]
        public string FullName { get; set; }
        [JsonProperty]
        public string JobTitle { get; set; }
        [JsonProperty]
        public int Age { get; set; }
        [JsonProperty]
        public int Seniority { get; set; }

        public Worker(string fullName, string job, int age, int seniority)
        {
            FullName = fullName;
            JobTitle = job;
            Age = age;
            Seniority = seniority;
        }

        public override string ToString()
        {
            return $"ФИО: {FullName}, Должность: {JobTitle}, Возраст: {Age}, Стаж: {Seniority}";
        }
    }
}