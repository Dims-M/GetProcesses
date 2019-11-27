using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GetProcesses
{
  public  class Bl
    {
        
        /// <summary>
        /// Основная папка программы
        /// </summary>
        private string myPachDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\Test\";
        private string myPachDirFileApp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Test\GetProcesses\";
        private bool swechLink = true; // добавление ярлыка в автозагрузку
        private string linkAppPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup)+ @"\GetProcesses.lnk";

        public List<Transport> getCompProcesse()
        {
            List<Transport> transList = new List<Transport>();
            Transport transport; // = new Transport((transList.Count + 1).ToString(), "fndfg", "fhjmfhj", "gk,ghj", 3.14);
            Process[] processes = Process.GetProcesses();
             

            foreach (var instance in processes)
            {
                transport = new Transport(instance.Id.ToString(), instance.ProcessName.ToString() );

                // transList.Add(instance.ProcessName);
                // listBox1.Items.Add(instance.ProcessName);
                transList.Add(transport);
            }
           // transList.Add(transport);
            return transList;
        }

        //закрыть нужны процесс по имени.
        public void KillProssec(string nameProssec)
        {
            try
            {
                System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill();
            }
            catch (Exception ex)
            {
                WrateText(" Ошибка при закрытии процесса" + ex);
            }

        }

        public void KillProssec(int nameProssec)
        {
            try
            {
                System.Diagnostics.Process.GetProcessById(nameProssec).Kill(); // GetProcessesByName(nameProssec)[0].Kill();
            }
            catch (Exception ex)
            {
                WrateText(" Ошибка при закрытии процесса" + ex);
            }

        }


        /// <summary>
        /// Запись в автозагрузку
        /// </summary>
        /// <param name="swixh"></param>
        public void CopyLinkAppStartup(bool swixh)
        {
            String s3 = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            s3 += "\\";
            //WrateText("Строка подключения \n" + s3);
            // MessageBox.Show(s3);

            //string a = "~runme.lnk"; GetProcesses.exe
            string a = "GetProcesses.lnk";
            //string b = @"C:\EoU\"; myPachDir
            string b = myPachDirFileApp;// + "GetProcesses\\";
            string c = s3;

            try
            {
                if (swixh)
                {
                    #region НЕ смотреть
                    // var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    // key.SetValue("Отправка чеков в ОФД", Application.ExecutablePath);
                    //  key.SetValue("Отправка чеков в ОФД", @"C:\EoU\EthOverUsb.exe");
                    // String s = System.Environment.GetEnvironmentVariable("programfiles");
                    //  String s2 = System.Environment.GetEnvironmentVariable("Startup");
                    //String s3 = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
                    //  File.Delete(c + a);
                    #endregion

                    System.IO.File.Copy(b + a, c + a);
                    //File.Copy(@"C:\EoU\~runme", patchStartup);
                    WrateText("Копирование ярлыка завершено!!");
                }

                else
                {
                    //  var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    //  key.DeleteValue("Отправка чеков в ОФД",true);
                    // File.Delete(@"C:\EoU\EthOverUsb.exe");
                    System.IO.File.Delete(c + a);
                    WrateText("Не актуальный ярлык удален");
                }

            }
            catch (Exception ex)
            {
                WrateText("Ошибка при при копировании ярлыка в автозагрузки" + ex);
            }
        }

        /// <summary>
        /// Создание директории, временной папки
        /// </summary>
        public void InitDirAndFile()
        {
            string tempPaht = Environment.CurrentDirectory; // путь запуска текущего приложения. Application.StartupPath
            string tempPahtFile = Application.StartupPath; // путь запуска текущего приложения. Application.StartupPath
            string tempPathDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Test\GetProcesses";

            DirectoryInfo dirInfo = new DirectoryInfo(myPachDir);
            
            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();// создание кaтолога
                }

                //Проверка откуда была запущена программа!!!
               if (tempPaht.Equals(tempPathDir) )
                {
                    MessageBox.Show("[ezct");
                    WrateTextTemp($"Временный лог.\t\n Текущая версия программы запущена из = {tempPahtFile} А должна быть из {tempPathDir}", tempPaht + "\\");
                    //GetFailSite();
                }

                else
                {

                WrateTextTemp($"Временный лог.\t\n Текущая версия программы запущена из = {tempPaht} А не из установочной пaпки{tempPathDir}", tempPaht + "\\");
                GetFailSite(); //получение новой версии файла Работает
                MessageBox.Show("Скачивание и копирование завершено!!!");
                // CopyLinkAppStartup(true);//запись в автозагрузку

                }
            }

            catch (Exception ex)
            {
                WrateTextTemp("Произошла ошибка при создании главной директории!!! \n" + ex + "\n", tempPaht);
            }


        }

        /// <summary>
        /// Получение новой версии файла ссайта 000webhostapp.com
        /// </summary>
        public void GetFailSite()
        {
            try
            {

            string errorLog = $"{DateTime.Now.ToString()}\t\n";
            //string pathFile = @"C:\EoUServis\EoU.zip";
            string serFtp = @"https://testkkm.000webhostapp.com/setProcesses/GetProcesses.zip";

            if (System.IO.File.Exists(myPachDir+ "GetProcesses.zip"))
            {
                errorLog += $"Данный файл уже существует \t\n{serFtp}\t\n";
                WrateText(errorLog);
                File.Delete(myPachDir + "GetProcesses.zip");
              //  WrateText(errorLog);
            }

                using (var web = new WebClient())
                {

                    // скачиваем откуда и куда
                    web.DownloadFile(serFtp, myPachDir + "GetProcesses.zip");
                }

                ZipArhivMyPath(myPachDir + "GetProcesses.zip", myPachDir); // распаковка архива
                CopyLinkAppStartup(swechLink); // копирование ярлыка 
                //  voidRegAvtoLoad(true);  //
            }
            catch (Exception ec)
            {
                WrateText(ec.ToString());
            }
        }

        /// <summary>
        /// Разорхивация файлов с указание что и куда орхивировать
        /// </summary>
        /// <param name="MyzipFail">Путь для файла.Откуда и какой архив</param>
        /// <param name="MyExtractPath">Куда распаковыватьы</param>
        public void ZipArhivMyPath(string MyzipFail, string MyExtractPath)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(MyzipFail))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(MyExtractPath, ExtractExistingFileAction.OverwriteSilently); // перезаписывать существующие
                    }
                }
                // ZipFile.ExtractToDirectory(MyzipFail, MyExtractPath);
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }

             // File.Delete(MyzipFail);
        }

        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Журнал событий
        /// </summary>
        /// <param name="myText"></param>
        public void WrateText(string myText)
        {

            using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись

            }
        }

        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Временное логирования
        /// </summary>
        /// <param name="myText"></param>
        public void WrateTextTemp(string myText, string myPachDir)
        {
            using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись

            }
        }

        public void IniBollCheckBox1(bool swichh)
        {
            swechLink = swichh;
            DeleteMyFail();
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        public void DeleteMyFail()
        {
            try
            {
                if (File.Exists(linkAppPath))
                {

                System.IO.File.Delete(linkAppPath);
                WrateText($"Удаление ярлыка из папки с автозагрузкой");
                }
               // WrateText($"Ярлыка при удалении не обнаружено!!");
            }
            catch (Exception ex)
            {
                WrateText($"Ошибка при удалении ярлыка"+ex);
            }
            
        } 


    }

    public struct Transport
    {
        public string ID { set; get; }
        public string ProcessName { set; get; }
        //public string DateDeparture { set; get; }
        //public string DateDestination { set; get; }
        //public double Price { set; get; }

       // public Transport(string cityDeparture, string cityDestination, string dateDeparture, string dateDestination, double price)
        public Transport(string cityDeparture, string cityDestination)
        {
            this.ID = cityDeparture;
            this.ProcessName = cityDestination;
            //this.DateDeparture = dateDeparture;
            //this.DateDestination = dateDestination;
            //this.Price = price;
        }
    }
}
