using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPress.SerializeService
{
    public static class SerializeService
    {

        public static void Serialize(ISerialize obj, ISerializeType serializer, Type type = null)
        {
            serializer.Serialize(obj,type);
        }
        public static ISerialize Deserialize(ISerialize obj, ISerializeType serializer, Type type = null)
        {
            return serializer.Deserialize(obj,type);
        }
    }
}
