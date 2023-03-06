using AppPress.SerializeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPressa.Filter
{
    [Serializable]
    public class PartFilter : ISerialize
    {
        public FilterElement baseFilter { get; set; } = new FilterElement();
        public bool CheckMax { get; set; } = false;
        public bool CheckMin { get; set; } = false;
        public bool CheckAver { get; set; } = false;
        public bool CheckPartCalc { get; set; } = false;
        public bool CheckAverLess { get; set; } = false;
        public bool CheckAverMore { get; set; } = false;

        string fileName = "partFilter";
        string ISerialize.FileName { get => fileName; set => fileName = value; }
    }
}
