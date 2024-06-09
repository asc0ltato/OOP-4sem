using System.IO;
using System.Xml.Serialization;
using OOP_Lab4_5.Classes;

namespace OOP_Lab4_5
{
    public static class DataTransfer
    {
        public static void SerializeBooks(Library books)
        {
            var serializer = new XmlSerializer(typeof(Library));
            using (var fs = new FileStream(@"C:\Users\user\Desktop\ООП\OOP_Lab4-5\OOP_Lab4-5\Resources\books.xml", FileMode.Create))
            {
                serializer.Serialize(fs, books);
            }
        }


        public static Library DeserializeBooks()
        {
            var serializer = new XmlSerializer(typeof(Library));
            Library deserializedBooksList = null;

            using (var fs = new FileStream(@"C:\Users\user\Desktop\ООП\OOP_Lab4-5\OOP_Lab4-5\Resources\books.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    deserializedBooksList = serializer.Deserialize(fs) as Library;
            }

            return deserializedBooksList;
        }
    }
}
