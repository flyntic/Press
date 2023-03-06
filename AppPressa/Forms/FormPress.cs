using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppPress.SerializeService;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AppPressa.Filter;
using AppPressa.Forms;
using System.Collections;
using static System.Net.WebRequestMethods;
using AppPressa.DBService;
using AppPressa.Graph;

namespace AppPressa
{
    public partial class FormPress : Form
    {
        DatabaseService service = new DatabaseService();
        SetElements filter=new SetElements();
        SetFilters  ListFilter=new SetFilters();
      //  PartFilter  partFilter=new PartFilter();
      
        public FormPress()
        {
            InitializeComponent();
          
            FilterPanel.backcolor = example_checkedListBox.BackColor;
            FilterPanel.bounds = checkBoxExample.Bounds;
            FilterElement.onChange = UpdateFilterPanel;

            tableEditComboBox.SelectedIndex = 0;
            tableFilterComboBox.SelectedIndex = 0;

            filterComboBox.TextChanged += (s, e) =>
            {
                if ((filterComboBox.SelectedIndex < 0)|| (filterComboBox.SelectedIndex > ListFilter.list.Count-1))
                {  
                    filter.Name = filterComboBox.Text;
                    filter.Table = tableFilterComboBox.SelectedIndex;
                }
                else
                { 
                    filter = ListFilter.list[filterComboBox.SelectedIndex]; 
                    tableFilterComboBox.SelectedIndex = filter.Table;
                    //partFilter=filter.partFilter ;
                    SortedForm();
                }

              

            };

            tableEditComboBox. SelectedIndexChanged += (a,e)=>{ UpdateTableEdit(); };
            partFilterСomboBox.SelectedIndexChanged += UpdateCalcPart;

            UpdateFilters(filter);
            UpdateTableOnFilter(filter);
            UpdateTableEdit();
            

        }

        private List<string> listValuesCol(DataGridViewRowCollection d, int index)
        { 
            List<string> values = new List<string>();

            foreach (DataGridViewRow r in d) 
            {
                values.Add(r.Cells[index].Value.ToString());
            }
            return values;
        }

        private void UpdateFilters(SetElements F )
        {
            
            filterComboBox.Items.Clear();

            ListFilter = (SetFilters)new SetFilters().openSetFilters();

            if (ListFilter == null) ListFilter = new SetFilters();
            else ListFilter.list.ForEach((f) => filterComboBox.Items.Add(f.Name));

            if(F!=null)filterComboBox.Text = F.Name;

        }


        private void UpdateTableOnFilter(SetElements filter )
        {
            
            service.Update();
            int indexTable= (tableFilterComboBox.SelectedIndex == 0) ? (int)DatabaseService.CollectDate.AllPublications : (int)DatabaseService.CollectDate.All_Releases;
            int indexDefineTable = (tableFilterComboBox.SelectedIndex == 0) ? (int)DatabaseService.CollectDate.DefPublication : (int)DatabaseService.CollectDate.DefRelease;
            dataGridView1.DataSource = service.data.Tables[indexTable];

            filterComboBox.Text = filter.Name;
            filter.list.Clear();
            int i = 0;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {  
                filter.AddElement(c.Name, false, service.data.Tables[indexDefineTable].Rows[i].ItemArray[2].ToString(), listValuesCol(dataGridView1.Rows,c.Index));
                i++;
            }

            label1.Text = "Всего " + dataGridView1.Rows.Count;
            editCountLabel.Text = "Всего " + editDataGridView.Rows.Count;

            panel1.Controls.Clear();
            panel1.Controls.AddRange(FilterPanel.getFilterPanels(filter).ToArray());

        }

        private void UpdateTableEdit()
        {
            service.Update();
            int indexTable =  (tableEditComboBox.SelectedIndex==0)? (int)DatabaseService.CollectDate.AllPublications : (int) DatabaseService.CollectDate.All_Releases;
          
            editDataGridView.DataSource = service.data.Tables[indexTable];
            editCountLabel.Text =  "Всего " + editDataGridView.Rows.Count;

        }

        private void UpdateFilterPanel(object sender,EventArgs a)
        {
              panel1.Controls.Clear();
              panel1.Controls.AddRange(FilterPanel.getFilterPanels(filter).ToArray());
        }
 
        //Сортировка элементов в списке
        private void SortedForm()
        {
            service.Update();
            int indexTable = (tableFilterComboBox.SelectedIndex == 0) ? (int)DatabaseService.CollectDate.AllPublications : (int)DatabaseService.CollectDate.All_Releases;
            int indexDefineTable = (tableFilterComboBox.SelectedIndex == 0) ? (int)DatabaseService.CollectDate.DefPublication : (int)DatabaseService.CollectDate.DefRelease;
            dataGridView1.DataSource = service.data.Tables[indexTable];

            int n = dataGridView1.Rows.Count;
            for (int i=0;i< n;)
            {
                DataGridViewRow r = dataGridView1.Rows[i];
                foreach (FilterElement f in filter.list)
                {
                    int index = dataGridView1.Columns[f.Name].Index;

                    DataGridViewCell cell = r.Cells[index];
                    string str = cell.Value.ToString();

                    if (!f.check(str))
                    {
                        dataGridView1.Rows.Remove(r);
                        n = dataGridView1.Rows.Count;
                        i--;
                        break;
                    }
                    
                }
                i++;
            }
            if (filter.SortColumn>=0)           
                dataGridView1.Sort(dataGridView1.Columns[filter.list[filter.SortColumn].Name], filter.SortDirection);
            
            panel1.Controls.Clear();
            panel1.Controls.AddRange(FilterPanel.getFilterPanels(filter).ToArray());

            UpdateFilterPart(filter.partFilter);
        }

        //Обработка выбора списка элементов
        private void tableFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = new SetElements();
            UpdateTableOnFilter(filter);
        }
 
        //применение фильтра
        private void applyButton_Click(object sender, EventArgs e)
        {
            SortedForm();
        }

        //сброс применения фильтра
        private void resetButton_Click(object sender, EventArgs e)
        {
            UpdateTableOnFilter(new SetElements());
         }

        //Выбор и сохранение сортировки
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            if (dataGridView1.SortOrder == SortOrder.None)
            {
                filter.SortColumn = -1;
                return;
            }
            if (dataGridView1.SortOrder == SortOrder.Ascending)
                 filter.SortDirection = ListSortDirection.Ascending;
            else filter.SortDirection = ListSortDirection.Descending;

            filter.SortColumn = dataGridView1.SortedColumn.Index;
        }

    
        private void UpdateCalcPart(object sender, EventArgs e)
        { 
            partPanel.Controls.Clear();
            if (partFilterСomboBox.SelectedIndex >= 0)
            {
                filter.partFilter.baseFilter = filter.list[partFilterСomboBox.SelectedIndex].Copy() ;
                partPanel.Controls.Add(FilterPanel.getPanelPart(filter.partFilter.baseFilter, partFilterLabel.Bounds));
            }
        }

        //Расчет доли
        private void calcPartButton_Click(object sender, EventArgs e)
        {
           
            SortedForm();

            int count1 = dataGridView1.Rows.Count;

            if ((filter.partFilter.baseFilter == null)||(string.IsNullOrEmpty(filter.partFilter.baseFilter.Name)))
            {
                MessageBox.Show("Не выбран параметр расчета");
                return;
            }

            partCalcListBox.Items.Clear();
 
            List<string> list = new List<string>();
            list = listValuesCol(dataGridView1.Rows, dataGridView1.Columns[filter.partFilter.baseFilter.Name].Index);
            string aver = filter.partFilter.baseFilter.FoundAver(list);

            if (filter.partFilter.CheckMin)
            {
                int indexMin = -1;
                string min = filter.partFilter.baseFilter.FoundMin(list);
                indexMin = filter.partFilter.baseFilter.FoundValue(list, min);
                if (indexMin < 0)
                    partCalcListBox.Items.Add("Минимальное значение: не найдено");
                else
                { 
                    string str = "";
                    foreach (DataGridViewCell i in dataGridView1.Rows[indexMin].Cells)
                      str += dataGridView1.Columns[i.ColumnIndex].Name.ToString() + ": " + i.Value.ToString() + " ; ";
                    partCalcListBox.Items.Add("Минимальное значение: :\n" + str);
                }

            }
            if (filter.partFilter.CheckMax)
            {
                int indexMax = -1;
                string max = filter.partFilter.baseFilter.FoundMax(list);
                indexMax = filter.partFilter.baseFilter.FoundValue(list, max);
                if (indexMax < 0)
                    partCalcListBox.Items.Add("Максимальное значение: не найдено");
                else
                {
                    string str = "";
                    foreach (DataGridViewCell i in dataGridView1.Rows[indexMax].Cells)
                        str += dataGridView1.Columns[i.ColumnIndex].Name.ToString() + ": " + i.Value.ToString() + " ; ";
                    partCalcListBox.Items.Add("Максимальное значение: :\n" + str);
                }

            }
            if (filter.partFilter.CheckAver|| filter.partFilter.CheckAverLess|| filter.partFilter.CheckAverMore)
            {
                 aver = filter.partFilter.baseFilter.FoundAver(list);
                 partCalcListBox.Items.Add("Среднее значение :\n" + filter.partFilter.baseFilter.Name+" : " + aver);

            }
            if (filter.partFilter.CheckAverLess)
            {
                for (int i = 0; i < count1;)
                {
                    DataGridViewRow r = dataGridView1.Rows[i];

                    int index = dataGridView1.Columns[filter.partFilter.baseFilter.Name].Index;

                    DataGridViewCell cell = r.Cells[index];
                    string str = cell.Value.ToString();

                    if (filter.partFilter.baseFilter.LessValue(aver,str))
                    {
                        string str_aver = "Меньше среднего значения :\n";
                        foreach (DataGridViewCell c in dataGridView1.Rows[i].Cells)
                            str_aver += dataGridView1.Columns[c.ColumnIndex].Name.ToString() + ": " + c.Value.ToString() + " ; ";

                        partCalcListBox.Items.Add(str_aver);
                    }
                    i++;
                }

            }
            if (filter.partFilter.CheckAverMore)
            {
                for (int i = 0; i < count1;)
                {
                    DataGridViewRow r = dataGridView1.Rows[i];

                    int index = dataGridView1.Columns[filter.partFilter.baseFilter.Name].Index;

                    DataGridViewCell cell = r.Cells[index];
                    string str = cell.Value.ToString();

                    if (filter.partFilter.baseFilter.MoreValue(aver, str))
                    {
                        string str_aver = "Больше среднего значения :\n";
                        foreach (DataGridViewCell c in dataGridView1.Rows[i].Cells)
                            str_aver += dataGridView1.Columns[c.ColumnIndex].Name.ToString() + ": " + c.Value.ToString() + " ; ";

                        partCalcListBox.Items.Add(str_aver);
                    }
                    i++;
                }
               
            }
            if (filter.partFilter.CheckPartCalc)
            {
                float count2 = 0;
                for (int i = 0; i < count1;)
                {
                    DataGridViewRow r = dataGridView1.Rows[i];

                    int index = dataGridView1.Columns[filter.partFilter.baseFilter.Name].Index;

                    DataGridViewCell cell = r.Cells[index];
                    string str = cell.Value.ToString();

                    if (filter.partFilter.baseFilter.check(str))
                    {
                        count2++;
                    }
                    i++;
                }
                partCalcListBox.Items.Add("Рачет доли \nКоличество 1: "+count1.ToString()+". Количество 2 : "+count2.ToString()+" . Доля :"+(count2 * 100 / count1).ToString("#.##")+" % ");
            }

        }

        //Вызов формы для редактирования-удаления-добавления элементов
        private void addButton_Click(object sender, EventArgs e)
        {
            if (tableEditComboBox.SelectedIndex == 0)
            {
                PublicationForm p = new PublicationForm();
                p.EditShow("add", null);
                if (p.DialogResult == DialogResult.OK)
                {
                    UpdateTableOnFilter(new SetElements());
                }
            }
            else
            {
                ReleaseForm p = new ReleaseForm();
                p.EditShow("add", editDataGridView.SelectedCells[0].Value as int? );
                if (p.DialogResult == DialogResult.OK)
                {
                   UpdateTableOnFilter(new SetElements());
                }

            }
         
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (tableEditComboBox.SelectedIndex == 0)
            {
                PublicationForm p = new PublicationForm();
                p.EditShow("remove", editDataGridView.SelectedCells[0].Value as int?);
                if (p.DialogResult == DialogResult.OK)
                {
                    UpdateTableOnFilter(new SetElements());
                }
            }
            else
            {
                ReleaseForm p = new ReleaseForm();
                p.EditShow("remove", editDataGridView.SelectedCells[0].Value as int?);
                if (p.DialogResult == DialogResult.OK)
                {
                   UpdateTableOnFilter(new SetElements());
                }

            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (tableEditComboBox.SelectedIndex == 0)
            {
                PublicationForm p = new PublicationForm();
                p.EditShow("edit",editDataGridView.SelectedCells[0].Value as int?);
                if (p.DialogResult == DialogResult.OK)
                {
                   UpdateTableOnFilter(new SetElements());
                }
            }
            else
            {
                ReleaseForm p = new ReleaseForm();
                p.EditShow("edit", editDataGridView.SelectedCells[0].Value as int?);
                if (p.DialogResult == DialogResult.OK)
                {
                    UpdateTableOnFilter(new SetElements());
                }

            }
        }

        //редактирование списка фильтров
        private void saveFilterButton_Click(object sender, EventArgs e)
        {
            if (filterComboBox.SelectedIndex >= 0)
            {
                ListFilter.list.RemoveAt(filterComboBox.SelectedIndex);
            }

            if (!string.IsNullOrEmpty(filterComboBox.Text))
            {
                filter.Name = filterComboBox.Text;
                filter.Table = tableFilterComboBox.SelectedIndex;
                if (filterComboBox.SelectedIndex >= 0)
                {
                    if (filter.partFilter.baseFilter!=null)
                      filter.partFilter=new PartFilter() { baseFilter= filter.partFilter.baseFilter.Copy()};
                    else filter.partFilter = null;
                }
                else filter.partFilter = new PartFilter();

                ListFilter.list.Add(filter);
            }

            ListFilter.saveSetFilters();
            UpdateFilters(filter);
        }

        private void removeFilterButton_Click(object sender, EventArgs e)
        {
            if (filterComboBox.SelectedIndex >= 0)
            {
                ListFilter.list.RemoveAt(filterComboBox.SelectedIndex);
                ListFilter.saveSetFilters();
                filterComboBox.Text = "";
                UpdateFilters(null);
            }
            else
            {
                MessageBox.Show("Не выбран фильтр для удаления из списка");
            }

        }

        private void addNewFilter_Click(object sender, EventArgs e)
        {
            if ((filterComboBox.SelectedIndex >= 0)|| string.IsNullOrEmpty(filterComboBox.Text))
            {
                filterComboBox.Text= "";
                MessageBox.Show("Введите название фильтра для добавления в список"); 
            }
            else
            {
                ListFilter.list.Add(filter);
                ListFilter.saveSetFilters(); 
                UpdateFilters(new SetElements());
               
            }
        }


        private void UpdateFilterPart(PartFilter partFilter)
        {   
            calcPartPanel.Visible = partFilter.CheckPartCalc || partFilter.CheckMax || partFilter.CheckMin ||
                                    partFilter.CheckAver || partFilter.CheckAverLess || partFilter.CheckAverMore;
            if (calcPartPanel.Visible)
            {
                partCalcPanel2.Visible = true;
                partFilterСomboBox.Items.Clear();
                filter.list.ForEach((str) => partFilterСomboBox.Items.Add(str.Name));
            }
            else
            {
                partFilterСomboBox.SelectedIndex = -1;
                partCalcPanel2.Visible = false;
            }
        }

        private void maxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filter.partFilter.CheckMax = maxCheckBox.Checked;
            UpdateFilterPart(filter.partFilter);
        }

        private void minCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filter.partFilter.CheckMin = minCheckBox.Checked;
            UpdateFilterPart(filter.partFilter);
        }

        private void averCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filter.partFilter.CheckAver = averCheckBox.Checked;
            UpdateFilterPart(filter.partFilter);
        }

        private void averMoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filter.partFilter.CheckAverMore = averMoreCheckBox.Checked;
            UpdateFilterPart(filter.partFilter);
        }

        private void averLessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filter.partFilter.CheckAverLess = averLessCheckBox.Checked;
            UpdateFilterPart(filter.partFilter);
        }

        private void calcPartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filter.partFilter.CheckPartCalc= calcPartCheckBox.Checked;
            UpdateFilterPart(filter.partFilter);
        }

        private void rstButton_Click(object sender, EventArgs e)
        {
            filter.partFilter.CheckMax = false;
            filter.partFilter.CheckMin = false;
            filter.partFilter.CheckAver = false;
            filter.partFilter.CheckPartCalc = false;
            filter.partFilter.CheckAverLess = false;
            filter.partFilter.CheckAverMore = false;
            
            calcPartCheckBox.Checked = false;
            averLessCheckBox.Checked = false;
            averMoreCheckBox.Checked = false;
            averCheckBox.Checked = false;
            maxCheckBox.Checked = false;
            minCheckBox.Checked = false;

            UpdateFilterPart(filter.partFilter);
        }

        //Показ формы О программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAbout().Show();
        }


    }
}
