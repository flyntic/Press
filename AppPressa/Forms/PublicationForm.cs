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
    public partial class PublicationForm : Form
    {

        private readonly pressDBEntities pressContext;
        private All_Publications publication;
        public PublicationForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            pressContext = new pressDBEntities();

            publicationComboBox.DataSource = pressContext.publication.Select(x=>x.name).Distinct().ToList();
            publicationComboBox.SelectedIndex = -1;
            editionComboBox.DataSource = pressContext.Edition.Select(x => x.count).Distinct().ToList();
            editionComboBox.SelectedIndex = -1;
            publishingCompanyComboBox.DataSource = pressContext.publishing_company.Select(x => x.name).Distinct().ToList();
            publishingCompanyComboBox.SelectedIndex = -1;
            themeComboBox.DataSource = pressContext.themes.Select(x => x.name).Distinct().ToList();
            themeComboBox.SelectedIndex = -1;
            frequencyComboBox.DataSource = pressContext.Frequency.Select(x => x.short_description).Distinct().ToList();
            frequencyComboBox.SelectedIndex = -1;
            distributionRegionComboBox.DataSource = pressContext.Distribution_region.Select(x => x.region).ToList();
            distributionRegionComboBox.SelectedIndex = -1;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            pressContext.All_Publications.Add(publication);
            pressContext.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            pressContext.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            pressContext.All_Publications.Remove(publication);
            pressContext.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
           
            Close();
        }

        private void beinDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            beginDateTimePicker.Visible=!beinDateCheckBox.Checked;
        }

        private void endDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            endDateTimePicker.Visible = !endDateCheckBox.Checked;

        }

        private void openPublictionButton_Click(object sender, EventArgs e)
        {
            new LightTableForm().EditShow("publication", "Типы Изданий");
        }

        private void openThemesButton_Click(object sender, EventArgs e)
        {
            new LightTableForm().EditShow("themes", "Темы Изданий");

        }

        private void openFrequencyButton_Click(object sender, EventArgs e)
        {
            new LightTableForm().EditShow("frequency", "Периодичность");
            

        }

        private void openPublishingCompanyButton_Click(object sender, EventArgs e)
        {
            new LightTableForm().EditShow("publishing_company", "Издательства");

        }

        private void openDistributionRegionButton_Click(object sender, EventArgs e)
        {
          new LightTableForm().EditShow("distribution_region", "Регионы доставки");

        }

        private void openEditionButton_Click(object sender, EventArgs e)
        {
            new LightTableForm().EditShow("edition", "Варианты тиража");

        }
        public void EditShow(string action, int? id)
        {
            if (id != null)
            {
                 publication = pressContext.All_Publications.Where(x => x.id == id).Single();
            }
            else publication = new All_Publications();

            switch (action)
            {
                case "add": addButton.Visible = true; break;
                case "remove": removeButton.Visible = true; panel1.Enabled = false; break;
                case "edit": saveButton.Visible = true; break;
            }


                articulTextBox.Text = publication.articul;
                articulTextBox.TextChanged +=(a,z)=>{ publication.articul = articulTextBox.Text; };

                nameTextBox.Text = publication.name;
                nameTextBox.TextChanged+= (a, z) => { publication.name = nameTextBox.Text; };

                beinDateCheckBox.Checked = (publication.begin_date == null);
                if (!beinDateCheckBox.Checked)
                   beginDateTimePicker.Value = publication.begin_date.Value.Date;
                beginDateTimePicker.ValueChanged += (a, z) =>
                { 
                    if (beinDateCheckBox.Checked) 
                        publication.begin_date = null;
                    else publication.begin_date = beginDateTimePicker.Value.Date; 
                };
 
                endDateCheckBox.Checked = (publication.end_date == null);
                if (!endDateCheckBox.Checked)
                    endDateTimePicker.Value = publication.end_date.Value.Date;
                endDateTimePicker.ValueChanged += (a, z) => 
                {  if (endDateCheckBox.Checked) 
                        publication.end_date = null; 
                    else publication.end_date = endDateTimePicker.Value.Date; 
                };

                priceTextBox.Text = publication.price.ToString();
                priceTextBox.TextChanged += (a, z) => { if (float.TryParse(priceTextBox.Text, out float f)) publication.price = f; else { publication.price = null; priceTextBox.Text = null; }  };

               if ((id != null) &&(publication.id_publication_fk!=null))
                  publicationComboBox.SelectedItem = pressContext.publication.Where((x) => x.id == publication.id_publication_fk).FirstOrDefault().name;
                publicationComboBox.SelectedIndexChanged += (a, s) =>
                  {
                      publication.id_publication_fk = pressContext.publication.Where((x) => x.name == publicationComboBox.Text).FirstOrDefault().id;
                  };

                if ((id != null) && (publication.id_publishing_company_fk!=null))
                  publishingCompanyComboBox.SelectedItem = pressContext.publishing_company.Where(x => x.id == publication.id_publishing_company_fk).FirstOrDefault().name;
                publishingCompanyComboBox.SelectedIndexChanged += (a, s) =>
                  {
                      publication.id_publishing_company_fk = pressContext.publishing_company.Where(x => x.name == publishingCompanyComboBox.Text).FirstOrDefault().id;
                  };

                if ((id != null)&&(publication.id_edition_fk!=null)) editionComboBox.SelectedItem = pressContext.Edition.Where(x => x.id == publication.id_edition_fk).FirstOrDefault().count;
                editionComboBox.SelectedIndexChanged += (a, s) =>
                  {
                      publication.id_edition_fk = pressContext.Edition.Where(x => x.count.ToString() == editionComboBox.Text).FirstOrDefault().id;
                  };

                if ((id != null) &&(publication.id_region_fk!=null))
                  distributionRegionComboBox.SelectedItem = pressContext.Distribution_region.Where(x => x.id == publication.id_region_fk).FirstOrDefault().region;
                distributionRegionComboBox.SelectedIndexChanged += (a, s) =>
                  {
                      publication.id_region_fk = pressContext.Distribution_region.Where(x => x.region == distributionRegionComboBox.Text).FirstOrDefault().id;
                  };

                if ((id != null)&&(publication.id_theme_fk!=null))
                  themeComboBox.SelectedItem = pressContext.themes.Where(x => x.id == publication.id_theme_fk).SingleOrDefault().name;
                themeComboBox.SelectedIndexChanged += (a, s) =>
                  {
                      publication.id_theme_fk = pressContext.themes.Where(x => x.name == themeComboBox.Text).SingleOrDefault().id;
                  };

                if ((id != null) &&(publication.id_frequency_fk!=null))
                  frequencyComboBox.SelectedItem = pressContext.Frequency.Where(x => x.id == publication.id_frequency_fk).SingleOrDefault().short_description;
                frequencyComboBox.SelectedIndexChanged += (a, s) =>
                  {
                      publication.id_frequency_fk = pressContext.Frequency.Where(x => x.short_description == frequencyComboBox.Text).SingleOrDefault().id;
                  };

                ShowDialog();

        }


    }
}
