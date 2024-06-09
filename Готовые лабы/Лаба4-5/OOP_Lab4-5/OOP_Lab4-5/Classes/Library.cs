using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP_Lab4_5.Classes
{
    [Serializable]
    public class Library
    {
        [XmlArray("BooksList"), XmlArrayItem("Book")]
        public List<Book> booksList;

        public Library() { booksList = new List<Book>(); }

        public void Add(Book m) => booksList.Add(m);   
    }
}
