using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AppPressa.Filter;

namespace AppPressa.Graph
{
    public static class FilterPanel
    {   public static Rectangle bounds;
        public static Color backcolor { get; set; }

        public static List<Control> getFilterPanels(SetElements f)
        {

            List<Control> listPanel = new List<Control>();
            Rectangle boundsNewFilter = bounds;

            f.list.ForEach(x =>
            {

                if (x.Checked)
                     listPanel.Add(FilterPanel.getPanel(x,boundsNewFilter));
                else listPanel.Add(FilterPanel.getPanel((x as FilterElement),boundsNewFilter));

                boundsNewFilter.Y += listPanel.Last().Bounds.Height;


            });

            return listPanel;
        }
        private static Control getDatePartPanel(DateElement f, Rectangle bounds)
        {
            Rectangle _bounds = bounds;
            _bounds.Height = 16;
            Control panel = new Panel() { Bounds = _bounds };
            _bounds.Y = 0;

            _bounds.X += 15;
            _bounds.Width -= 15;
            _bounds.Y += 28;

            if (f.Checked)
            {
                panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "От" });
                _bounds.Y += 16;

                DateTimePicker dtp= new DateTimePicker(){ Bounds = _bounds, Value = f.dateBegin };
                dtp.ValueChanged += (a, e) =>  f.dateBegin = dtp.Value.Date;
                panel.Controls.Add(dtp);

                _bounds.Y += 24;
                panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "До" });
                _bounds.Y += 16;
                dtp = new DateTimePicker() { Bounds = _bounds, Value = f.dateEnd };
                dtp.ValueChanged += (a, e) => f.dateEnd = dtp.Value.Date;
                panel.Controls.Add(dtp);

                panel.Height += 76;
            }
            return panel;
        }

        private static Control getStringPartPanel(StringElement f, Rectangle bounds)
        {
            Rectangle _bounds = bounds;
            _bounds.Height = 16;
            Control panel = new Panel() { Bounds = _bounds };
            _bounds.Y = 0;
            _bounds.X += 15;
            _bounds.Width -= 15;
            _bounds.Y += 28;

            if (f.Checked)
            {
                TextBox tb = new TextBox() { Bounds = _bounds, Text = f.foundString };
                tb.TextChanged += (a, e) =>  f.foundString= tb.Text;
                panel.Controls.Add(tb);
                panel.Height += 26;
            }

            return panel;
        }

        private static Control getEnumPartPanel(EnumElement f, Rectangle bounds)
        {
            Rectangle _bounds = bounds;
            _bounds.Height = 16;
            Control panel = new Panel() { Bounds = _bounds };
            _bounds.Y = 0;


            _bounds.X += 15;
            _bounds.Width -= 15;
            _bounds.Y += 28;


            if (f.Checked)
            {

                CheckedListBox listbox = new CheckedListBox()
                { Bounds = _bounds, CheckOnClick = true, BorderStyle = BorderStyle.None, BackColor = backcolor };


                foreach (var i in f.list)
                {
                    listbox.Items.Add(i.Key, i.Value);
                    panel.Height += 15;
                    listbox.Height += 15;
                }
                listbox.SelectedIndexChanged += (sender, a) =>
                {
                    f.list[f.list.ElementAt(listbox.SelectedIndex).Key] = listbox.GetItemChecked(listbox.SelectedIndex);
                };

                panel.Controls.Add(listbox);
                panel.Height += 10;
            }

            return panel;
        }


        private static Control getRealPartPanel(RealElement f, Rectangle bounds)
        {
            Rectangle _bounds = bounds;
            _bounds.Height = 16;
            Control panel = new Panel() { Bounds = _bounds };
            _bounds.Y = 0;


            panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "От" });
                _bounds.Y += 16;
                TextBox tb = new TextBox() { Bounds = _bounds, Text = f.valueBegin.ToString() };
                tb.TextChanged += (a, e) => { if (!float.TryParse((a as TextBox).Text, out float _minValue)) (a as TextBox).Text = f.valueBegin.ToString(); else { f.valueBegin = _minValue; } };
                panel.Controls.Add(tb);


                _bounds.Y += 23;
                panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "До" });
                _bounds.Y += 16;

                tb = new TextBox() { Bounds = _bounds, Text = f.valueEnd.ToString() };
                tb.TextChanged += (a, e) => { if (!float.TryParse((a as TextBox).Text, out float _maxValue)) (a as TextBox).Text = f.valueEnd.ToString(); else f.valueEnd = _maxValue; };
                panel.Controls.Add(tb);

                panel.Height += 76;
         

            return panel;

        }

        private static Control getDatePanel(DateElement f, Rectangle bounds)
        {
             Control panel = getFilterPanel(f as FilterElement, bounds);
             Rectangle _bounds = bounds;
            _bounds.Y = 0;
            _bounds.Height = 16;


            _bounds.X += 15;
            _bounds.Width -= 15;
            _bounds.Y += 28;


            if (f.Checked)
            {
                panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "От" });
                _bounds.Y += 16;
                DateTimePicker dtp = new DateTimePicker() { Bounds = _bounds, Value = f.dateBegin };
                dtp.ValueChanged += (a, e) => f.dateBegin = dtp.Value.Date;
                panel.Controls.Add(dtp);
                _bounds.Y += 24;
                panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "До" });
                _bounds.Y += 16;
                dtp = new DateTimePicker() { Bounds = _bounds, Value = f.dateEnd };
                dtp.ValueChanged += (a, e) => f.dateEnd = dtp.Value.Date;
                panel.Controls.Add(dtp);

                panel.Height += 76;
            }
            return panel;
        }

        private static Control getStringPanel(StringElement f, Rectangle bounds)
        {
            Control panel = getFilterPanel(f as FilterElement, bounds);
            Rectangle _bounds = bounds;

            _bounds.Y = 0;
            _bounds.Height = 16;

            _bounds.X += 15;
            _bounds.Width -= 15;
            _bounds.Y += 28;

            if (f.Checked)
            {
                TextBox tb = new TextBox() { Bounds = _bounds, Text = f.foundString };
                tb.TextChanged += (a, e) => f.foundString = tb.Text;
                panel.Controls.Add(tb);
                panel.Height += 26;
            }
            
            return panel;
        }

        private static Control getEnumPanel(EnumElement f, Rectangle bounds)
        {
            Control panel = getFilterPanel(f as FilterElement, bounds);
            Rectangle _bounds = bounds;

            _bounds.Y = 0;
            _bounds.Height = 16;


            _bounds.X += 15;
            _bounds.Width -= 15;
            _bounds.Y += 28;

 
            if (f.Checked) 
            {

                CheckedListBox listbox = new CheckedListBox()
                { Bounds = _bounds, CheckOnClick = true, BorderStyle = BorderStyle.None, BackColor = backcolor };


                foreach (var i in f.list)
                {
                    listbox.Items.Add(i.Key, i.Value);
                    panel.Height += 15;
                    listbox.Height += 15;
                }
                listbox.SelectedIndexChanged += (sender, a) =>
                {
                    f.list[f.list.ElementAt(listbox.SelectedIndex).Key] = listbox.GetItemChecked(listbox.SelectedIndex);
                };

                panel.Controls.Add(listbox);
                panel.Height += 10;
            }

            return panel;
        }


        private static Control getRealPanel(RealElement f, Rectangle bounds)
        {
            Control panel = getFilterPanel(f as FilterElement, bounds);
            Rectangle _bounds = bounds;
            _bounds.Y = 0;
            _bounds.Height = 16;

            _bounds.X += 15;
            _bounds.Width -= 15;
            _bounds.Y += 28;

            if (f.Checked) 
            {
                panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "От" });
                _bounds.Y += 16;
                TextBox tb = new TextBox() { Bounds = _bounds, Text = f.valueBegin.ToString() };
                tb.TextChanged += (a, e) => { if (!float.TryParse((a as TextBox).Text, out float _minValue)) (a as TextBox).Text = f.valueBegin.ToString(); else { f.valueBegin = _minValue; } };
                panel.Controls.Add(tb);


                _bounds.Y += 23;
                panel.Controls.Add(new Label() { Bounds = _bounds, Height = 15, Text = "До" });
                _bounds.Y += 16;

                tb = new TextBox() { Bounds = _bounds, Text = f.valueEnd.ToString() };
                tb.TextChanged += (a, e) => { if (!float.TryParse((a as TextBox).Text, out float _maxValue)) (a as TextBox).Text = f.valueEnd.ToString(); else f.valueEnd = _maxValue; };
                panel.Controls.Add(tb);

                panel.Height += 76;
            }

            return panel;

        }

        private static Control getFilterPanel(FilterElement f, Rectangle bounds)
        {
            Panel panel = new Panel() { Bounds = bounds };
            panel.Height = 8;

            Rectangle _bounds = bounds;
            _bounds.Y = 5;
            _bounds.Width -= 15;


            CheckBox cb = new CheckBox() { Text = f.Name, Bounds = _bounds, Checked = f.Checked };
            cb.Click += (a, e) =>
            {
                f.Checked = (a as CheckBox).Checked;
                if (!f.Checked)
                    f.Clear();
            };

            if (FilterElement.onChange != null) cb.Click += FilterElement.onChange;

            panel.Controls.Add(cb);
            panel.Height = 24;

            return panel;
        }

        public static Control getPanel(FilterElement f, Rectangle bounds)
        {
 
            if (f.filterType == FilterElement.FilterType.filter_enum)    return getEnumPanel  (f as EnumElement,   bounds);else
            if (f.filterType == FilterElement.FilterType.filter_real)    return getRealPanel  (f as RealElement,   bounds);else
            if (f.filterType == FilterElement.FilterType.filter_date)    return getDatePanel  (f as DateElement,   bounds);else
            if (f.filterType == FilterElement.FilterType.filter_string)  return getStringPanel(f as StringElement, bounds);else

            return getFilterPanel(f,bounds);
        }


        public static Control getPanelPart(FilterElement f, Rectangle bounds)
        {
            if (f.filterType == FilterElement.FilterType.filter_enum) return getEnumPartPanel(f as EnumElement, bounds);
            else
            if (f.filterType == FilterElement.FilterType.filter_real) return getRealPartPanel(f as RealElement, bounds);
            else
            if (f.filterType == FilterElement.FilterType.filter_date) return getDatePartPanel(f as DateElement, bounds);
            else
            if (f.filterType == FilterElement.FilterType.filter_string) return getStringPartPanel(f as StringElement, bounds);
            else

                return null;
        }

    }
}
