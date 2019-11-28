using System;
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
        private List<string> tempListGetProcess{get; set;}
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
            bl.InitDirAndFile();
            bl.CopyLinkAppStartup(true);


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Bl bl = new Bl();

            clientTable.DataSource = null;
            // dataGridView1.DataSource = transList;
            clientTable.DataSource = bl.getCompProcesse();
           // tempListGetProcess = bl.getCompProcesse();
            // tempListGetProcess.Add(bl.getCompProcesse().ToString());
            bl.WrateText(bl.getCompProcesse().ToString());
        }

        //кнопка закрыть процесс
        private void Button3_Click(object sender, EventArgs e)
        {
            Bl bl = new Bl();
          //  bl.InitDirAndFile();
            bl.DeleteMyFail();
            // bl.GetFailSite(); //загрузка с файла
            // bl.KillProssec(string ff = dataGridView1.Rows);
            // bl.InitDirAndFile(); // создание временной директории
            // bl.ZipArhivMyPath(@"C:\Users\Dim\Documents\Test\GetProcesses.zip", @"C:\Users\Dim\Documents\Test\");
        }

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

        ////Событие 2й клик по таблице с процессами
        //private void clientTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //  Bl bl = new Bl();

        //    int temp = e.RowIndex;

        //    Int32 selectedRowCount =
        //    clientTable.Rows.GetRowCount(DataGridViewElementStates.Selected);

        //    label4.Text = temp.ToString();

        //    var t = clientTable.Rows[temp]; // получили индек в датагрид
        //    var ttt = t.Index; // интовы индекс

        //    //for (int i = 0; i < tempListGetProcess.Count; i++)

        //    //    if (tempListGetProcess[i] == 1)
        //    //        // обрабатывай данные строки

        //    // // var rrr = clientTable.SelectedRows;

        //    //  /  clientTable.in


        //            MessageBox.Show($"Будет удален этот элемент!!{temp}");

        //    // string temppp =  tempListGetProcess.  Count(temp);
        //    label4.Text = selectedRowCount.ToString();

        //    // bl.KillProssec(Convert.ToInt32(temp));
        //    //  e.RowIndex

        //}

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

            int temp = e.RowIndex;
            string ggggg ="Незаполнено";
              Int32 selectedRowCount =
               clientTable.Rows.GetRowCount(DataGridViewElementStates.Selected);

            //label4.Text = temp.ToString();

            var ffff = clientTable.Rows.SharedRow(temp);

            int counList = clientTable.RowCount; // получаем все значения 
                                                 // var t = clientTable.Rows[temp]; // получили индек в датагрид
                                                 // var ttt = t.Index; // интовы индекс

            // for (int i = 0; i < counList; i++)
            //{
            //ggggg = clientTable.Rows[temp].Cells[temp].Value.ToString(); // работает 1раз
            // ggggg = clientTable.CurrentRow.Cells.ToString(); // CurrentCell.ToString();
            // this.clientTable.FirstDisplayedCell = this.clientTable.CurrentCell;
            // ggggg = clientTable.FirstDisplayedCell.ToString();
            //}

            ggggg = clientTable.Rows[temp].Cells["ProcessName"].Value.ToString();

            //DataGridViewRow startingBalanceRow = clientTable.Rows[temp];
            //if (clientTable.SelectedRows.Contains(startingBalanceRow))
            //{
            //    // Do not allow the user to delete the Starting Balance row.
            //    MessageBox.Show("FJFJFJFJFJFJFJ");

            //    // Cancel the deletion if the Starting Balance row is included.
            //   // e.Cancel = true;
            //}

            // if (tempListGetProcess.F == 1)
            // обрабатывай данные строки

            label4.Text = ggggg.ToString();

            bl.KillProssec(ggggg); // Закрытие процесса по имени
        }



        private void clientTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
