using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPress.SerializeService
{
    public interface ISerializeType
    {
        void Serialize(ISerialize obj, Type type = null);
        ISerialize Deserialize(ISerialize obj, Type type = null);
    }
}
