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
        private void UpdateForm(bool activation)
        {
            int si = comboBox1.SelectedIndex;

            if (si == 0) si = (int)DatabaseService.CollectDate.AllPublications; 
                   else si = (int)DatabaseService.CollectDate.All_Releases;
            dataGridView1.DataSource = service.data.Tables[si];
            label1.Text ="Всего " + service.data.Tables[si].Rows.Count.ToString();

            panel1.Controls.Clear();

            if (activation) checkedbox.Clear();

            namefilter.Clear();
            int i = 0;
            int j = 0,l=0;
            CheckBox checkbox ;
            Rectangle bnd = checkBoxExample.Bounds;
            Rectangle bndlb = example_checkedListBox.Bounds;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {   if (activation) checkedbox.Add(false);
                checkbox = new CheckBox() { Text = c.Name, Bounds = bnd, Checked= checkedbox[i]};
                bnd.Y += 24;
                checkbox.CheckedChanged+= addFilter;
                panel1.Controls.Add(checkbox);
                namefilter.Add(c.Name);                

           
                if (checkedbox[i])
                    {
                        bndlb.Y = bnd.Y;

                    if (!service.data.Tables[si].Columns[i].DataType.IsValueType)
                    {
                        CheckedListBox listbox = new CheckedListBox()
                        {
                            Bounds = bndlb,
                            Height = 90,
                            CheckOnClick = true,
                            BorderStyle = BorderStyle.None,
                            BackColor = example_checkedListBox.BackColor
                        };

                        foreach (DataRow r in service.data.Tables[si].Rows)
                        {
                            if (!listbox.Items.Contains(r[i].ToString()))
                                listbox.Items.Add(r[i].ToString());
                        }


                        panel1.Controls.Add(listbox);
                    }
                    else
                    {
                        float max = 0; 
                        foreach (DataRow r in service.data.Tables[si].Rows)
                        {
                            float f=0;
                            if (float.TryParse(r[i].ToString(),out f) ) 
                                if(f>max) max = f;
                        }
                        panel1.Controls.Add(new TextBox() { Bounds=bnd,Text="0"});
                        bnd.Y += 24;
                        panel1.Controls.Add(new TextBox() { Bounds = bnd, Text = max.ToString() });
                    }
                        bnd.Y += 90;

                    }
                i++;
            }

     //       Publication_checkedListBox.Items.Clear();
     //       foreach (DataRow r in service.data.Tables[(int)DatabaseService.CollectDate.Publication].Rows)
     //       {
     //           Publication_checkedListBox.Items.Add(r[0].ToString(),false);
     //       }
     //
     //       theme_checkedListBox.Items.Clear();
     //       foreach (DataRow r in service.data.Tables[(int)DatabaseService.CollectDate.Themes].Rows)
     //       {
     //           theme_checkedListBox.Items.Add(r[0].ToString(), false);
     //       }
     //
     //       company_checkedListBox.Items.Clear();
     //       foreach (DataRow r in service.data.Tables[(int)DatabaseService.CollectDate.Publishing_company].Rows)
     //       {
     //           company_checkedListBox.Items.Add(r[0].ToString(), false);
     //       }
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
    }
}
