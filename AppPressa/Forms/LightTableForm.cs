using AppPressa.DBService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPressa.Forms
{
    public partial class LightTableForm : Form
    {
        DatabaseService service = new DatabaseService();
        string _nametable;
        int index = 0;
        public LightTableForm()
        {
            InitializeComponent();
        
        }
        public void EditShow(string nametable, string namelabel)
        { 
            _nametable = nametable;
            label.Text= namelabel;
            showEditTable();
            Show();
        }
        public int showEditTable()
        {   
            
            service.Update();
            switch (_nametable)
            { 
               case "publication":         index = (int)DatabaseService.CollectDate.publication;        break;
               case "publishing_company":  index = (int)DatabaseService.CollectDate.publishing_company; break;
               case "themes":              index = (int)DatabaseService.CollectDate.themes;             break;
               case  "edition":            index = (int)DatabaseService.CollectDate.edition;            break;
               case "distribution_region": index = (int)DatabaseService.CollectDate.dregions; break;
               case "frequency":           index = (int)DatabaseService.CollectDate.frequency; break;
 
               default:return -1;
            }
            
            dataGridView.DataSource = service.data.Tables[index];
            dataGridView.Columns[0].Visible = false;

            service.setUpdateRemoveAdd(index);
            return index;

        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void saveButton_Click(object sender, EventArgs e)
        {
           // int index=showEditTable();
            string str = service.Save(index); ;
            if (str != null) MessageBox.Show(str);

            showEditTable();

        }


    }
}
