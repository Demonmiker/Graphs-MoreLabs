using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace MySerialize
{
    public static class Serializer
    {
        public static void Write<T>(string Path, T O)
        {
            XmlSerializer F = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            F.Serialize(fs, O);
            fs.Close();
        }

        public static T Read<T>(string Path)
        {
            XmlSerializer F = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(Path, FileMode.Open);
            object Res = F.Deserialize(fs);
            T Res2 = (T)Res;
            fs.Close();
            return Res2;
        }
    }
}
