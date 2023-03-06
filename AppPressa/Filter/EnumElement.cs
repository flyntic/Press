using AppPress.SerializeService;
using System;
using System.Collections;
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
    public class EnumElement : FilterElement, ISerialize
    {
        public override FilterType filterType { get; }= FilterElement.FilterType.filter_enum;
        string fileName = "enumElement";
        string ISerialize.FileName { get => fileName; set => fileName = value; }
       
        public Dictionary<string,bool> list { get;  set; }=new Dictionary<string,bool>();

        public override void Clear() 
        {
            if (list!=null)

            for (int i=0;i<list.Count;i++)
                list[list.ElementAt(i).Key]=false;
        }

  
        public override bool check(string str)
        {
            if (!Checked) return true;
            if (!list.ContainsKey(str)) return false;
            return list[str];
        }

        public override FilterElement Copy()
        {
            EnumElement f = new EnumElement();

            f.Name = Name;
            f.Checked = Checked;
            f.list = new Dictionary<string, bool>();

            if (!Checked)
                foreach(var l in list) f.list.Add(l.Key, false);
            else
                foreach (var l in list) if (l.Value) f.list.Add(l.Key, false);

            return f;
        }

    }
}
