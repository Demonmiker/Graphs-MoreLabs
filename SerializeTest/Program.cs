using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Xml.Serialization;
using System.IO;

namespace SerializeTest
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Hero Bob = new Hero();
            Bob.l.Add(5);
            Bob.l.Add(6);
            Serialize<Hero>("NewBob.txt", Bob);

            //
            

        }

        public static void Serialize<T>(string Path, T O)
        {
            XmlSerializer F = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            F.Serialize(fs, O);
            fs.Close();
        }

        public static T Deserialize<T>(string Path)
        {
            XmlSerializer F = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(Path, FileMode.Open);
            object Res = F.Deserialize(fs);
            T Res2 = (T)Res;
            fs.Close();
            return Res2;
        }

    }

    

    [Serializable]
    public class Hero
    {
        public List<int> l = new List<int>();
       
        public Hero()
        { }
    }

    public class Node
    {

    }
}
