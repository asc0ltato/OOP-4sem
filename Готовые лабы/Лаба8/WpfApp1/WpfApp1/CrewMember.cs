using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class CrewMember
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public BitmapImage Photo { get; set; }
        public int PlaneID { get; set; }

        public CrewMember(int id, string nameSurname, string position, int age, int experience, BitmapImage photo, int planeID)
        {
            this.ID = id;
            this.NameSurname = nameSurname;
            this.Position = position;
            this.Age = age;
            this.Experience = experience;
            this.Photo = photo;
            this.PlaneID = planeID;
        }

        public CrewMember() { }
    }
}