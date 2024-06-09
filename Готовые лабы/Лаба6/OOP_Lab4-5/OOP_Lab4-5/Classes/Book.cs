using System;
using System.Xml.Serialization;

namespace OOP_Lab4_5.Classes
{
    [Serializable]
    public class Book
    {
        private string _title;
        private string _author;
        private string _genre;
        private int _instock;
        private string _rating;
        private string _photo;

        [XmlElement(ElementName = "Title")]
        public string Title { get => _title; set => _title = value; }
        [XmlElement(ElementName = "Author")]
        public string Author { get => _author; set => _author = value; }
        [XmlElement(ElementName = "Genre")]
        public string Genre { get => _genre; set => _genre = value; }
        [XmlElement(ElementName = "InStock")]
        public int InStock { get =>_instock; set => _instock = value; }
        [XmlElement(ElementName = "Rating")]
        public string Rating { get => _rating; set => _rating = value; }
        [XmlElement(ElementName = "Photo")]
        public string Photo { get => _photo; set => _photo = value; }


        public Book() { }

        public Book(string title, string author, string genre, 
            int in_s, string rating, string photo)
        {
            Title = title;
            Author = author;
            Genre = genre;
            InStock = in_s;
            Rating = rating;
            Photo = photo;
        }
    }
}