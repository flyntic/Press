using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppPress.SerializeService
{
    public class XmlSerializeFormat : ISerializeType
    {
        private XmlSerializer serializer;
        public ISerialize Deserialize(ISerialize obj, Type type = null)
        {
            serializer = new XmlSerializer(type);
            if (File.Exists($"{obj.FileName}.xml") == false) return null;

            using (var fs = new FileStream($"{obj.FileName}.xml", FileMode.Open))
            {
                return (ISerialize)serializer.Deserialize(fs);
            }
        }

        public void Serialize(ISerialize obj, Type type = null)
        {
            serializer = new XmlSerializer(type);
            using (var fs = new FileStream($"{obj.FileName}.xml", FileMode.Create))
            {
                serializer.Serialize(fs, obj);
            }
        }
    }
}
