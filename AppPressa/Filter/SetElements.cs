using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPress.SerializeService;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace AppPressa.Filter
{
    [Serializable]
    public class SetElements : ISerialize
     {
        public static EventHandler onChange=null; 
        public List<FilterElement> list { get; set; } = new List<FilterElement>();

        public PartFilter partFilter { get; set; } = new PartFilter();
        public string Name { get; set; }
        public int Table { get; set; }
        public int SortColumn { get; set; }
        public ListSortDirection SortDirection { get; set; }
        string fileName = "Filter ";
        string ISerialize.FileName { get => fileName+Name; set => fileName = value; }

  
        public void AddElement(string name, bool _checked, string t, List<string> _list)
        {
  
            if (t== "date")
            {
                List<DateTime> listdate = new List<DateTime>();
               _list.ForEach(str => { if (DateTime.TryParse(str, out DateTime result)) listdate.Add(result); });
                DateTime min= (listdate.Count >0 )? listdate.Min() : DateTime.MinValue;
                DateTime max = (listdate.Count > 0) ? listdate.Max() : DateTime.Now;
                list.Add(new DateElement() { Name = name, Checked = _checked, dateBegin =min , dateEnd =max, minDateBegin = min, maxDateEnd = max });

            }
            else
            if ((t=="float")|| (t == "int"))
            {
                List<float> listfloat = new List<float>();
                _list.ForEach(str => { if (float.TryParse(str, out float result)) listfloat.Add(result); });

                float min = (listfloat.Count > 0) ? listfloat.Min() : 0;
                float max = (listfloat.Count > 0) ? listfloat.Max() : 0;

                list.Add(new RealElement() { Name = name, Checked = _checked, valueBegin = min, valueEnd = max, minValueBegin = min, maxValueEnd = max});

            }
            else
            if  (t=="enum")
            {   Dictionary<string,bool> newList= new Dictionary<string,bool>();
               
                _list.ForEach((str) => { if (!newList.ContainsKey(str)) newList.Add(str, false); });
                list.Add(new EnumElement() { Name = name, Checked = _checked, list = newList });
            }
            else
            {
                list.Add(new StringElement() { Name = name, Checked = _checked, foundString = null});
            }
 
        }
 
        
    }
}
