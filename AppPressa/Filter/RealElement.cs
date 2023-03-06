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
    public class RealElement : FilterElement, ISerialize
    {
       
        public override FilterType filterType { get; } = FilterElement.FilterType.filter_real;

        string fileName = "realElement";
        string ISerialize.FileName { get => fileName; set => fileName = value; }

        public float minValueBegin { get; set; }
        public float valueBegin { get; set; }
        public float valueEnd { get; set; }
        public float maxValueEnd { get; set; }

        public override void Clear()
        {
            valueBegin = minValueBegin;
            valueEnd = maxValueEnd;
        }
 
        public override FilterElement Copy()
        {
            RealElement f = new RealElement();

            f.Name = Name;
            f.Checked = Checked;
            f.valueBegin= valueBegin;
            f.valueEnd= valueEnd;
            f.minValueBegin= minValueBegin;
            f.maxValueEnd= maxValueEnd; 
            return f;
        }


        public override bool check(string str)
        {
            if (!Checked) return true;

            if (float.TryParse(str, out float value))
            {
                return (value >= valueBegin) && (value <= valueEnd);
            }
            return false;
        }

        public override string FoundMax(List<string> list)
        {
            float max = 0;
            list.ForEach(x => { if (float.TryParse(x, out float f)) if (f > max) max = f; });
            return max.ToString();
        }
        public override string FoundMin(List<string> list)
        {
            float min=float.MaxValue;
            float.TryParse(list[0], out min);
            

            list.ForEach(x => { if (float.TryParse(x, out float f)) if (f < min) min = f; });
            return min.ToString();
        }
        public override string FoundAver(List<string> list)
        {
            float aver = 0;
            if (list.Count == 0) return "0";

            list.ForEach(x => { if (float.TryParse(x, out float f)) aver += f; });

            return (aver / list.Count).ToString();
        }
        public override int FoundValue(List<string> list, string value)
        {
            return list.IndexOf(value);
        }
        public override bool MoreValue(string aver, string value)
        {
            float _aver;
            float _value;
            if ((float.TryParse(aver,out _aver)) && (float.TryParse(value,out _value)))
              return _aver>=_value;
            return false;    
        }
        public override bool LessValue(string aver, string value) 
        {
            float _aver;
            float _value;
            if ((float.TryParse(aver, out _aver)) && (float.TryParse(value, out _value)))
                return _aver <= _value;
            return false;
        }

    }
}
