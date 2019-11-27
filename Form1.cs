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

            dataGridView1.DataSource = null;
           // dataGridView1.DataSource = transList;
            dataGridView1.DataSource = bl.getCompProcesse();
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
    }
}
