using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SzpitalGUI
{
    public static class Serializer
    {
        public static void Save(string filePath, object objToSerialize)
        {
            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, objToSerialize);
            }
        }

        public static T Load<T>(string filePath) where T : new()
        {
            T rez = new T();


            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                rez = (T) bin.Deserialize(stream);
            }


            return rez;
        }
    }
}