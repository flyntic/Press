using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPressa
{
    public partial class FormPress : Form
    {
        DatabaseService service = new DatabaseService();
        List<bool> checkedbox = new List<bool>(20) ;
        List<string> namefilter = new List<string>(20);
        public FormPress()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            
            UpdateForm(true);
        }
        private Control AddElement(Rectangle bnd,Type t, List<string> list)
        {
            Panel panel = new Panel() { Bounds = bnd };

            bnd.Y = 5;
            bnd.Width-= 15;
            
            if (t.Name == "DateTime")
            {  
                List<DateTime> listdate = new List<DateTime>();
               
                list.ForEach(str => { if (DateTime.TryParse(str,out DateTime result)) listdate.Add(result); });

                panel.Controls.Add(new Label()          { Bounds = bnd, Height=15,Text = "От"    });
                bnd.Y += 16;                                                                     
                panel.Controls.Add(new DateTimePicker() { Bounds = bnd, Value=listdate.Min()     });
                bnd.Y += 24;
                panel.Controls.Add(new Label()          { Bounds = bnd, Height = 15, Text = "До" });
                bnd.Y += 16;
                panel.Controls.Add(new DateTimePicker() { Bounds = bnd, Value = listdate.Max()   });

                panel.Height += 66;

            }
            else
            if (t.IsValueType)
            {
                List<float> listfloat = new List<float>();
                list.ForEach(str => { if (float.TryParse(str, out float result)) listfloat.Add(result); });

                panel.Controls.Add(new Label() { Bounds = bnd, Height = 15, Text = "От" });
                bnd.Y += 16;
                panel.Controls.Add(new TextBox() { Bounds = bnd, Text = listfloat.Min().ToString() });
                bnd.Y += 23;
                panel.Controls.Add(new Label() { Bounds = bnd, Height = 15, Text = "До" });
                bnd.Y += 16;
                panel.Controls.Add(new TextBox() { Bounds = bnd, Text = listfloat.Max().ToString() });

                panel.Height += 66;
            }
            else
            if(list.Count()<10)
            {
                CheckedListBox listbox = new CheckedListBox()
                { Bounds = bnd, CheckOnClick = true, BorderStyle = BorderStyle.None,BackColor = example_checkedListBox.BackColor };

                list.ForEach(str => { listbox.Items.Add(str); panel.Height += 14;listbox.Height += 14; });
  
                panel.Controls.Add(listbox);
            }
            else
            {
                panel.Controls.Add(new TextBox() { Bounds = bnd });
            }

            return panel;
        }
        private void UpdateForm(bool activation)
        {
            int si = comboBox1.SelectedIndex;

            dataGridView1.DataSource = service.data.Tables[si];
            label1.Text ="Всего " + service.data.Tables[si].Rows.Count.ToString();

            panel1.Controls.Clear();
            if (activation) checkedbox.Clear();
            namefilter.Clear();

            int i = 0;
            CheckBox checkbox ;
            Rectangle bnd = checkBoxExample.Bounds;

            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {   if (activation) checkedbox.Add(false);
                checkbox = new CheckBox() { Text = c.Name, Bounds = bnd, Checked= checkedbox[i]};
                bnd.Y += 24;
                checkbox.CheckedChanged+= addFilter;
                panel1.Controls.Add(checkbox);
                namefilter.Add(c.Name);


                if (checkedbox[i])
                {

                    List<string> list = new List<string>();
                    foreach (DataRow r in service.data.Tables[si].Rows)
                    {
                        if (!list.Contains(r[i].ToString()))
                             list.Add(r[i].ToString());
                    }

                    Control cnt = AddElement(bnd, service.data.Tables[si].Columns[i].DataType, list);
                                          
                    panel1.Controls.Add(cnt);
                    bnd.Y += cnt.Height;
                }
                    
                
                i++;
            }

        }

        private void SortDataGridView(DataGridViewRowCollection list, int i, Panel p, Type t)
        {
            if (t.Name == "DateTime")
            {
                DateTime minDate = (p.Controls[1] as DateTimePicker).Value;
                DateTime maxDate = (p.Controls[3] as DateTimePicker).Value;

                foreach(DataGridViewRow r in list)
                {   
                    if (DateTime.TryParse(r.Cells[i].ToString(),out DateTime dt))
                    { if (dt < minDate) list.Remove(r);
                      else
                      if (dt > maxDate) list.Remove(r);
                    }
                }
            }
            else
            if (t.IsValueType)
            {
                float min = float.Parse((p.Controls[1] as TextBox).Text);
                float max = float.Parse((p.Controls[3] as TextBox).Text);

             
                foreach (DataGridViewRow r in list)
                {
                    if (float.TryParse(r.Cells[i].Value.ToString(), out float dt))
                    {
                        if (dt < min) list.Remove(r);
                        else
                        if (dt > max) list.Remove(r);
                       

                    }
                   
                }


            }
           else
           if (list.Count < 10)
           {
                CheckedListBox listbox = p.Controls[0] as CheckedListBox;

                List<string> list_str = new List<string>();

                foreach (var r in listbox.Items)
                    list_str.Add(r.ToString());

                foreach (DataGridViewRow r in list)
                {
                    if (!list_str.Contains(r.Cells[i].Value.ToString()))
                        list.Remove(r);
                }
           }
            else
            {
        //        panel.Controls.Add(new TextBox() { Bounds = bnd });
            }
        }
        private void SortedForm()
        {
            int si = comboBox1.SelectedIndex;
            int i = 0,j=0;
            foreach (bool b in checkedbox)
            {
                if (b)
                {
                    j++;
                    SortDataGridView(dataGridView1.Rows, i, panel1.Controls[i+j] as Panel, service.data.Tables[si].Columns[i].DataType);
                    
                }

                i++;
            }
          
        }

       

        private void addFilter(object sender,EventArgs a)
            {
               if (sender is CheckBox)
               { CheckBox cb = sender as CheckBox;
               
                   checkedbox[namefilter.IndexOf(cb.Text)] = cb.Checked;
                   UpdateForm(false);
               }
            }
        private void addFilterOnSetting(object sender, EventArgs a)
        {

               UpdateForm(false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateForm(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortedForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FormNewPublication().Show();
        }
    }
}
