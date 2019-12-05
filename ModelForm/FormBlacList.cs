using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetProcesses.ModelForm
{
    public partial class FormBlacList : Form
    {
        private List<Transport> tempListGetProcess { get; set; } // лист для хранения данных блек листа
        private static int nomerRow; // получение индекса таблицы дата грид
        public FormBlacList()
        {
            InitializeComponent();
        }

        //Кнопка выход
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //при загрузке формы 
        private void FormBlacList_Load(object sender, EventArgs e)
        {
            string nameProcess = "";

            //загрузка данных в датгрид 


            Int32 selectedRowCount =
            blacListTable.Rows.GetRowCount(DataGridViewElementStates.Selected); // выбор строки в дате грид

            nameProcess = blacListTable.Rows[nomerRow].Cells["ProcessName"].Value.ToString();
        }



        //медод получения данных дата грида
        private  void loadDateGrid()
        {
            // dataGridView1.DataSource = transList;
           // blacListTable.DataSource = bl.getCompProcesse(); //получение всех процессов с компа
          //  tempListGetProcess = bl.getCompProcesse();  //заполнение листа из черного списка

        }
    }
}
