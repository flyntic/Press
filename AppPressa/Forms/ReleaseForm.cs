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
    public partial class ReleaseForm : Form
    {
        private readonly pressDBEntities pressContext;
        private All_Releases release;
        public ReleaseForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            pressContext = new pressDBEntities();

            articulComboBox.DataSource = pressContext.All_Publications.Select(x => x.articul).Distinct().ToList();
            articulComboBox.SelectedIndex = -1;
            articulComboBox.SelectedIndexChanged += (a, s) =>
                  { All_Publications publication = pressContext.All_Publications.Where(x => x.articul == articulComboBox.Text).FirstOrDefault();
                      if (publication != null)
                      {
                          release.id_all_publications_fk = publication.id;
                          nameComboBox.Text = publication.name;
                          numberComboBox.DataSource = pressContext.All_Releases.Where(x => x.id_all_publications_fk == publication.id).Select(x => x.id_release).Distinct().ToList();
                          panel2Update(publication.id);
                      }
                  };

            nameComboBox.DataSource = pressContext.All_Publications.Select(x => x.name).Distinct().ToList();
            nameComboBox.SelectedIndex = -1;
            nameComboBox.SelectedIndexChanged += (a, s) =>
            {
                All_Publications publication = pressContext.All_Publications.Where(x => x.name == nameComboBox.Text).FirstOrDefault();
                if (publication != null)
                {
                    release.id_all_publications_fk = publication.id;
                    articulComboBox.Text = pressContext.All_Publications.Where(x => x.id == publication.id).FirstOrDefault().articul;
                    numberComboBox.DataSource = pressContext.All_Releases.Where(x => x.id_all_publications_fk == publication.id).Select(x => x.id_release).Distinct().ToList();
                    panel2Update(publication.id);
                }
            };

            numberComboBox.SelectedIndexChanged += (a, s) =>
              {
                  if (int.TryParse(numberComboBox.Text, out int id_release))
                  {  
                     int? id = pressContext.All_Releases.Where(x => x.id_release == id_release && x.id_all_publications_fk == release.id_all_publications_fk).FirstOrDefault().id;
                      if (id != null)
                      {   release= pressContext.All_Releases.Where(x=>x.id==id).FirstOrDefault();
                          dateTimePicker.Value = release.date_release.Value.Date;
                          priceTextBox.Text = release.price_release.Value.ToString();
                          saleTextBox.Text = release.count_sale.Value.ToString();
                      }
                      else { release.id_release = id_release; }
                  }

              };
            numberComboBox.TextChanged += (a, s) =>
            {
                if (int.TryParse(numberComboBox.Text, out int id_release))
                {
                    bool found= pressContext.All_Releases.Where(x => x.id_release == id_release && x.id_all_publications_fk == release.id_all_publications_fk).Any();
                    if (found)
                    {
                        release = pressContext.All_Releases.Where(x => x.id_release == id_release && x.id_all_publications_fk == release.id_all_publications_fk).FirstOrDefault();
                        dateTimePicker.Value = release.date_release.Value.Date;
                        priceTextBox.Text = release.price_release.Value.ToString();
                        saleTextBox.Text = release.count_sale.Value.ToString();
                    }
                    else { release.id_release = id_release; }
                }

            };

            dateTimePicker.ValueChanged += (a, s) => release.date_release = dateTimePicker.Value;

            priceTextBox.TextChanged += (a, s) => { if (float.TryParse(priceTextBox.Text, out float f)) release.price_release = f; else priceTextBox.Text = ""; } ;

            saleTextBox.TextChanged += (a, s) => { if (int.TryParse(saleTextBox.Text, out int i)) release.count_sale = i; else saleTextBox.Text = ""; };



        }

        void panel2Update(int? id_all_publications_fk)
        {
            All_Publications publication = pressContext.All_Publications.Where(x => x.id == id_all_publications_fk).FirstOrDefault();
            publicationTextBox.Text= pressContext.publication.Where(x => x.id == publication.id_publication_fk).FirstOrDefault().name;
            themeTextBox.Text = pressContext.themes.Where(x => x.id == publication.id_theme_fk).FirstOrDefault().name;
            frequencyTextBox.Text = pressContext.Frequency.Where(x => x.id == publication.id_frequency_fk).FirstOrDefault().short_description;
            distributionRegionTextBox.Text = pressContext.Distribution_region.Where(x => x.id == publication.id_region_fk).FirstOrDefault().region;
            editionTextBox.Text = pressContext.Edition.Where(x => x.id == publication.id_edition_fk).FirstOrDefault().count.ToString();
            
            DateTime? value  = pressContext.All_Publications.Where(x => x.id == id_all_publications_fk).FirstOrDefault().begin_date;
            if (value == null) beginDateTimePicker.Visible = false;
               else beginDateTimePicker.Value = value.Value;

            value = pressContext.All_Publications.Where(x => x.id == id_all_publications_fk).FirstOrDefault().end_date;
            if (value == null) endDateTimePicker.Visible = false;
            else endDateTimePicker.Value = value.Value;
        }

        public void EditShow(string action, int? id)
        {
            if (id != null)
            {
                release = pressContext.All_Releases.Where(x => x.id == id).FirstOrDefault();
                All_Publications publication = pressContext.All_Publications.Where(x=>x.id==release.id_all_publications_fk).FirstOrDefault();
                if (publication != null)
                {
                  articulComboBox.Text = publication.articul;
                }
            }
            switch (action)
            {
                case "add":   addButton.Visible = true;  break;
                case "remove":
                    {
                        nameComboBox.Enabled = false;
                        articulComboBox.Enabled = false;      
                        removeButton.Visible = true;
                        break;
                    }
                case "edit":
                    {
                        
                      nameComboBox.Enabled = false;
                      articulComboBox.Enabled = false;
                      saveButton.Visible = true;
                    }
                    break;
            }
            ShowDialog(); 
        }

    
      
       

        private void removeButton_Click(object sender, EventArgs e)
        {
            pressContext.All_Releases.Remove(release);
            pressContext.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;

            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            pressContext.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        { 
            pressContext.All_Releases.Add(release);
            pressContext.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();

        }
       
    }
}
