using AppPress.SerializeService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace AppPressa.Filter
{
    [Serializable]
    public class StringElement : FilterElement, ISerialize
    {
        public override FilterType filterType { get; } = FilterElement.FilterType.filter_string;
        string fileName = "stringElement";
        string ISerialize.FileName { get => fileName; set => fileName = value; }

        public string foundString { get;set; }
        public override void Clear()
        {
            foundString=null;
        }
         public override bool check(string str)
        {
            if (!Checked) return true;

            return str.StartsWith(foundString);
        }
        public override FilterElement Copy()
        {   StringElement f = new StringElement();
            f.Name = Name;
            f.Checked = Checked;
            f.foundString= foundString;
            return f;
        }



    }
}
