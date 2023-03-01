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
    public partial class FormNewPublication : Form
    {
        DatabaseService service = new DatabaseService();
        Rectangle BoundsLabel;
        Rectangle BoundsBox;
        public FormNewPublication()
        {
            InitializeComponent();
            BoundsLabel = label1.Bounds;
            BoundsBox = textBox1.Bounds;
            UpdateForm();

        }
        private List<string> getVariables(int id)
        { List<string> list = new List<string>();
            foreach (DataRow r in service.data.Tables[2+id].Rows)
                list.Add(r[0].ToString());
            return list;
        }
        private Control AddElement(Rectangle bnd, string t,int id)
        {

            if (t == "date")
            {
                 return new DateTimePicker() { Bounds = bnd };

            }
            else
            if (t=="string")
            {
               return (new TextBox() { Bounds = bnd });
           }
            else
            if (t=="enum")
            {
                bnd.Width += 24;
                Panel p = new Panel() { Bounds = bnd };
                bnd.X = 0;
                bnd.Y = 0;
                bnd.Width -= 24;
                ComboBox cb = new ComboBox() { Bounds = bnd };
                getVariables(id).ForEach((x)=> { cb.Items.Add(x); });
                p.Controls.Add(cb);
                bnd.X+=bnd.Width ;
                bnd.Width = 24;
                p.Controls.Add(new Button() { Text = "...", Bounds = bnd });
                return p;


            }
            else
            {
                return(new TextBox() { Bounds = bnd });
            }
           
        }
     //   public List<string> getlistValues(string str)
     //   { 
     //   
     //   }
        public void UpdateForm()
        {   
            panel1.Controls.Clear();
            Rectangle bndLabel = BoundsLabel;
            Rectangle bndBox = BoundsBox;
            foreach (DataRow i in service.data.Tables[2].Rows)//.For , .// Rows.Count.ToString(); ;
            {
                panel1.Controls.Add(new Label() { Text = i[1].ToString(), Bounds = bndLabel });
                bndLabel.Y += 28;

                panel1.Controls.Add(AddElement(bndBox, i[2].ToString(),(int)i[0]));
                bndBox.Y += 28;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
