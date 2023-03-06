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
    public class FilterElement
    {
        public enum FilterType
        {  filter_base,
           filter_real,
           filter_enum,
           filter_string,
           filter_date
        };

        public virtual FilterType filterType { get; } = FilterElement.FilterType.filter_base;

        public string Name { get; set; }
        public bool Checked { get; set; }
  
        public virtual string FoundMax(List<string> list) { return null; }
        public virtual string FoundMin(List<string> list) { return null; }
        public virtual string FoundAver(List<string> list) { return null; }

        public virtual bool MoreValue(string aver, string value) { return false; }
        public virtual bool LessValue(string aver, string value) { return false; }
        public virtual int FoundValue(List<string> list, string value) { return -1; }

        public static EventHandler onChange;
        public virtual void Clear()  {  }
 
        public virtual FilterElement Copy()
        { 
            FilterElement f=new FilterElement();
            f.Name= Name;   
            f.Checked=Checked;
            return f;
        }
        public virtual bool check(string str)
        {
            if (!Checked) return true;

            return false;
        }
    }
        
}
