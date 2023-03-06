using AppPress.SerializeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPressa.Filter
{
    [Serializable]
    public class SetFilters:ISerialize
    {
        public List<SetElements> list=new List<SetElements>();
        string filename = "AllFilters";
        public string FileName { get => filename; set => filename=value; }
        public void saveSetFilters()
        {
            SerializeService.Serialize(this, new BinarrySerializeFormat());
        }
        public SetFilters openSetFilters()
        {
            return (SetFilters)SerializeService.Deserialize(this, new BinarrySerializeFormat());
        }

    }
}
