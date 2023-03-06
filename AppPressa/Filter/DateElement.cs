using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Collections;
using AppPress.SerializeService;

namespace AppPressa.Filter
{
    [Serializable]
    public class DateElement : FilterElement, ISerialize
    {
        public override FilterType filterType{get;} = FilterElement.FilterType.filter_date;
        public DateTime dateBegin { get; set; }
        public DateTime minDateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public DateTime maxDateEnd { get; set; }

        string fileName= "dateElement";
        string ISerialize.FileName  { get => fileName; set => fileName = value; }
        public override void Clear()
        {
            dateBegin = minDateBegin;
            dateEnd = maxDateEnd;
        }
 
        public override FilterElement Copy()
        {
            DateElement f = new DateElement();
            f.Name = Name;
            f.Checked = Checked;
            f.dateBegin = dateBegin;
            f.dateEnd =   dateEnd;
            f.minDateBegin = minDateBegin;
            f.maxDateEnd =   maxDateEnd;
            return f;
        }
        public override bool check(string str)
        {
            if (!Checked) return true;

            if (DateTime.TryParse(str, out DateTime value))
            {
                return (value >= dateBegin) && (value <= dateEnd);
            }
            return false;
        }
    }
}
