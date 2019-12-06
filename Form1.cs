using GetProcesses.ModelForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetProcesses
{

    public partial class Form1 : Form
    {
        private List<Transport> tempListGetProcess{get; set;}
        private static int nomerRow;
        

        public Form1()
        {
            InitializeComponent();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        //При загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            Bl bl = new Bl();
            bl.InitDirAndFile(); // создание и папок
          //  bl.getCompProcesse(); // получение списка запущеных процессов
           // bl.CopyLinkAppStartup(true); // программное добавление в автозагрузку

            clientTable.DataSource = bl.getCompProcesse();
            tempListGetProcess = bl.getCompProcesse();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //очистить старую форму датагрида c 2 колонками
            // DeleteColums();

            clientTable.Refresh();
            Bl bl = new Bl();
            clientTable.DataSource = null;

            // dataGridView1.DataSource = transList;
            clientTable.DataSource = bl.getCompProcesse();
            tempListGetProcess = bl.getCompProcesse();
            // tempListGetProcess = bl.getCompProcesse();
            // tempListGetProcess.Add(bl.getCompProcesse().ToString());
            bl.WrateText(bl.getCompProcesse().ToString()); // получение обьекта прошивки
        }

        //кнопка закрыть процесс
        private void Button3_Click(object sender, EventArgs e)
        {
            Bl bl = new Bl();
            //  bl.InitDirAndFile();
            //  bl.DeleteMyFail();
            bl.ReadingList(); //чтение файла и закрытие процессов из списка
            // bl.GetFailSite(); //загрузка с файла
            // bl.KillProssec(string ff = dataGridView1.Rows);
            // bl.InitDirAndFile(); // создание временной директории
            // bl.ZipArhivMyPath(@"C:\Users\Dim\Documents\Test\GetProcesses.zip", @"C:\Users\Dim\Documents\Test\");
            bl.ReaderWhiteList("Microsoft.Photos2"); //DTAgent

        }

        /// <summary>
        /// Кнопка закрытия процесса по id и им6ни
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            Bl bl = new Bl();

            if (numericUpDown2.Value>0)
            {
                bl.KillProssec(Convert.ToInt32(numericUpDown2.Value));
            }
            if (textBox1.Text!=null)
            {
                bl.KillProssec(textBox1.Text.ToString());
            }
            bl.KillProssec(textBox1.Text.ToString());
        }

        //кнопка сохранения настроек
        private void ButtonSaveSettings_Click(object sender, EventArgs e)
        {

        }

        //Чек бокс автозагрузки программы
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox

            if (checkBox.Checked == true)
            {
                // MessageBox.Show("Запуск в скрытом режиме включен!");
                Bl bl = new Bl();
                bl.CopyLinkAppStartup(true);
            }
            else
            {
                Bl bl = new Bl();
                bl.IniBollCheckBox1(false);
               // MessageBox.Show("Запуск в скрытом режиме Отключен!");
               
            }
        }

       /// <summary>
       /// Событие при двойном клике на строку с процессами
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void clientTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Bl bl = new Bl();

            #region Тест 1
            //Int32 selectedCellCount =
            //    clientTable.GetCellCount(DataGridViewElementStates.Selected);
            //if (selectedCellCount > 0)
            //{
            //    if (clientTable.AreAllCellsSelected(true))
            //    {
            //        MessageBox.Show("All cells are selected", "Selected Cells");
            //    }
            //    else
            //    {
            //        System.Text.StringBuilder sb =
            //            new System.Text.StringBuilder();

            //        for (int i = 0;
            //            i < selectedCellCount; i++)
            //        {
            //            sb.Append("Row: ");
            //            sb.Append(clientTable.SelectedCells[i].RowIndex
            //                .ToString());
            //            sb.Append(", Column: ");
            //            sb.Append(clientTable.SelectedCells[i].ColumnIndex
            //                .ToString());
            //            sb.Append(Environment.NewLine);
            //        }

            //        sb.Append("Total: " + selectedCellCount.ToString());
            //        MessageBox.Show(sb.ToString(), "Selected Cells");
            //    }
            //}

            #endregion

            #region не раб 
            //    Int32 selectedRowCount =
            //clientTable.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //    if (selectedRowCount > 0)
            //    {
            //        System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //        for (int i = 0; i < selectedRowCount; i++)
            //        {
            //            sb.Append("Row: ");
            //            sb.Append(clientTable.SelectedRows[i].Index.ToString());
            //            sb.Append(Environment.NewLine);
            //        }

            //        sb.Append("Total: " + selectedRowCount.ToString());
            //        MessageBox.Show(sb.ToString(), "Selected Rows");
            //    }

            #endregion

            #region не раб
            //    Int32 selectedCellCount =
            //clientTable.GetCellCount(DataGridViewElementStates.Selected);
            //    if (selectedCellCount > 0)
            //    {
            //        if (clientTable.AreAllCellsSelected(true))
            //        {
            //            MessageBox.Show("НЕт Выбраны строки", "111");
            //        }
            //        else
            //        {
            //            System.Text.StringBuilder sb =
            //                new System.Text.StringBuilder();

            //            for (int i = 0;
            //                i < selectedCellCount; i++)
            //            {
            //                sb.Append("Row: ");
            //                sb.Append(clientTable.SelectedCells[i].RowIndex
            //                    .ToString());
            //                //sb.Append(", Column: ");
            //                //sb.Append(dataGridView1.SelectedCells[i].ColumnIndex
            //                //    .ToString());
            //                //sb.Append(Environment.NewLine);
            //            }

            //            sb.Append("Total: " + selectedCellCount.ToString());
            //           // MessageBox.Show(sb.ToString(), "Selected Cells");
            //        } 
            //    }

            #endregion

            nomerRow = e.RowIndex;
            string nameProcess ="Незаполнено";
             Int32 selectedRowCount =
             clientTable.Rows.GetRowCount(DataGridViewElementStates.Selected);

            int counList = clientTable.RowCount; 

            nameProcess = clientTable.Rows[nomerRow].Cells["ProcessName"].Value.ToString();
            string idProsecc = clientTable.Rows[nomerRow].Cells["Id"].Value.ToString(); 

            label4.Text = $"{nameProcess.ToString()} из {counList} процессов";

            Transport transport = new Transport();
            transport = tempListGetProcess.Find(item => item.ID== idProsecc); //

            // var tempp = tempListGetProcess.IndexOf(x => x.ID == iddd); // 
            // int tempp = (int)tempListGetProcess.Find(x=>x.); // 
            // int tempp = tempListGetProcess.IndexOf(iddd);

           // textBoxProcess.Text = $"{transport.ID} и {transport.ProcessName}";


            bl.KillProssec(nameProcess); // Закрытие процесса по имени
            bl.WrateText($"Завершенн процесс по именни.{nameProcess}");

        }



        private void clientTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Кнопка добавления в список закрытия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, EventArgs e)
        {
            Bl bl = new Bl();
            //  nomerRow = e.RowIndex; // номер строки. На которой будет целчок мышки

            FormBlacList formBlacList = new FormBlacList();
            formBlacList.Show();

            string nameProcess = "";
            Int32 selectedRowCount =
            clientTable.Rows.GetRowCount(DataGridViewElementStates.Selected); // выбор строки в дате грид

            nameProcess = clientTable.Rows[nomerRow].Cells["ProcessName"].Value.ToString();


            bl.AddBlacListProcess(nameProcess);// запись имени нужного процесса
        }

        //Вызывается при щелчке на строку грида
        private void ClientTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nomerRow = e.RowIndex;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        //исключить из "черного списка"
        private void Button6_Click(object sender, EventArgs e)
        {
           // Bl bl = new Bl();

            FormBlacList formBlacList = new FormBlacList();
            formBlacList.Show();

            ////ПОбавляем 2 новые колонки. Проблемма с переходом на новую форрму.
            //clientTable.DataSource = null;
            
            ////создаём и добавляем две колонки
            //clientTable.Columns.Add("ID", "ID");
            //clientTable.Columns.Add("ProcessName", "ProcessName");

            //// добавляем строку
            //int rowNumber = clientTable.Rows.Add();

            ////3. Заполняем ячейки
            //clientTable.Rows[rowNumber].Cells["ID"].Value = rowNumber; // получение айди или нмера списка
            //clientTable.Rows[rowNumber].Cells[1].Value = "Тестттттт"; // имя процесса

           // bl.ReaderWhiteList("Microsoft.Photos2"); // отправляем строку с именем процесса который нужно исклучить

           // clientTable.DataSource = null;

             
        }

        void DeleteColums()
        {
            clientTable.Columns.RemoveAt(0);
            clientTable.Columns.RemoveAt(1);
        }


        private void Button7_Click(object sender, EventArgs e)
        {
            Bl bl = new Bl();

            int indexRowCell = clientTable.SelectedCells[0].RowIndex; // получаем индекс выделеной строки 

           // MessageBox.Show($"Номер строки { indexRowCell}");
            label4.Text = "Номер строки "+ indexRowCell;

           // bl.KillProssec(indexRowCell);
            label4.Text += "Был остановлен процесс ";

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
