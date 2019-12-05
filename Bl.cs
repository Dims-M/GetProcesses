using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GetProcesses
{
  public  class Bl
    {
        
        /// <summary>
        /// Основная папка программы
        /// </summary>
        private string myPachDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\Test\";
        private string myLogPachDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Test\GetProcessesLog\";
        private string myPachDirFileApp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Test\GetProcesses\";
        private bool swechLink = true; // добавление ярлыка в автозагрузку
        private string linkAppPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup)+ @"\GetProcesses.lnk";

        private static int countProcesse = 0;


        /// <summary>
        /// Получение списка запущенных процессов
        /// </summary>
        /// <returns></returns>
        public List<Transport> getCompProcesse()
        {
            List<Transport> transList = new List<Transport>();
            Transport transport; // = new Transport((transList.Count + 1).ToString(), "fndfg", "fhjmfhj", "gk,ghj", 3.14);
            Process[] processes = Process.GetProcesses();
           // countProcesse = processes.Count();

            foreach (var instance in processes)
            {
                transport = new Transport(instance.Id.ToString(), instance.ProcessName.ToString(), instance.MainWindowTitle.ToString() );

                // transList.Add(instance.ProcessName);
                // listBox1.Items.Add(instance.ProcessName);
                transList.Add(transport);
            }
            countProcesse = transList.Count;
           // transList.Add(transport);
            return transList;
        }

        /// <summary>
        /// Медо чтения их тех. файла в лист
        /// </summary>
        public List<Transport> ReadBlackList()
        {
            //str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ")

            List<Transport> lines = new List<Transport>();
            FileInfo fileInfo = new FileInfo(@"Log//MyLogKillProssec.txt");
           
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }
            FileStream file = new FileStream(@"Log//MyLogKillProssec.txt", FileMode.Open);
            Transport transport; //
            int chet = 0;
            using (StreamReader readFile = new StreamReader(file, Encoding.UTF8)) 
            {
                string temp = string.Empty; // инциализация пустой строки

                while (readFile.Peek() != -1)
                {

                    transport = new Transport(chet.ToString(), temp , "");

                    lines.Add(transport);
                    //temp = readFile.ReadLine();
                    ////if (temp == "flag")
                    ////    continue;
                    ////else
                    //    lines.Add(temp);
                    chet++;
                }
            }
            file.Close();

            return lines;
        }
         
        


        //закрыть нужны процесс по имени.
        public void KillProssec(string nameProssec)
        {
            try
            {
               // MessageBox.Show($"Процесс {nameProssec} будет закрыт") ;

                for (int i =0; i<= countProcesse; i++)
                {
                    System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill(); //не понятно как решить ошибку индекса
                    Thread.Sleep(100); // что бы коректно закрывались процессы
                }

               // System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill();
                WrateTextTemp("Ошибка при закрытии процесса \n", @"Log\MyLogKillProssec.txt", true);

            }
            catch (Exception ex)
            {
                WrateText(" Ошибка при закрытии процесса\t\n" + ex);
            }

        }

        /// <summary>
        /// Добавление в черный список просессов по имени
        /// </summary>
        /// <param name="nameProssec"></param>
        public void AddBlacListProcess(string nameProssec)
        {
            try
            {
                MessageBox.Show($"Процесс {nameProssec} будет добавлен в список закрываемых  при запуске программы процессов");

                System.Diagnostics.Process.GetProcessesByName(nameProssec)[0].Kill();

               // WrateTextTemp($"\n{nameProssec}", @"Log\MyLogKillProssec.txt", true); 
            }
            catch (Exception ex)
            {
                WrateText(" Ошибка при закрытии процесса\t\n" + ex);
            }

        }

        /// <summary>
        /// Чтение листа и сразу закрытие процесса из листа
        /// </summary>
        public void ReadingList()
        {
            string tepmmMass = null;
           
           // MessageBox.Show("Будут завершены процессы из черного списка )))");

            if (File.Exists(@"Log\MyLogKillProssec.txt"))
            {
                using (StreamReader sw = new StreamReader(@"Log\MyLogKillProssec.txt", System.Text.Encoding.Default))
                {
                    while ((tepmmMass = sw.ReadLine()) != null)  // построчно.
                    {
                        KillProssec(tepmmMass); // удаляем процесс
                    }
                }
                AddBlacListProcess(tepmmMass); // запись в лист

            }
           else
            WrateText("!!Ошибка при чтении файла блеклиста!!!\t\n");

        }

        /// <summary>
        /// Чтение файла с процессами для закрытия
        /// </summary>
        /// <param name="nameProc"></param>
        public void ReaderWhiteList(string nameProc)
        {
            //str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ")
            string tempName = "";
            string newLogKill = "";
            string[] tempMassLog  = new string[300];

            if (File.Exists(@"Log\MyLogKillProssec.txt"))
            {
                using (StreamReader sw = new StreamReader(@"Log\MyLogKillProssec.txt", System.Text.Encoding.Default))
                {
                   // tempName = sw.
                    while ((tempName = sw.ReadLine()) != null)  // построчно. 
                    {
                     //  tempMassLog
                       // newLogKill += tempName;

                        if (tempName.Contains(nameProc)) // ищем нужный процесс по строчьно.
                        {
                            WrateText("!!Сработал брейк\t\n");
                           
                            continue;
                        }
                        // tempMassLog[] = tempName;
                        newLogKill += System.Text.RegularExpressions.Regex.Replace(tempName, @"\s+", " ");
                        newLogKill += "\n";
                    }
                  
                }
            // File.Delete(@"Log\MyLogKillProssec.txt");
            WrateTextTemp($"\n{newLogKill}", @"Log\MyLogKillProssec.txt", false);
            }
            
            else {
                WrateText("!!Ошибка при чтении файла блеклиста!!!\t\n");
            }
        }



        /// <summary>
        /// Закрытие процесса по id
        /// </summary>
        /// <param name="idProssec"></param>
        public void KillProssec(int idProssec)
        {
            try
            {
                System.Diagnostics.Process.GetProcessById(idProssec).Kill(); // GetProcessesByName(nameProssec)[0].Kill();
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

            DirectoryInfo dirInfo = new DirectoryInfo(@"Log");
            FileInfo fileInfo = new FileInfo(@"Log\MyLogKillProssec.txt");
            
            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();// создание кaтолога
                   // Directory.CreateDirectory("Log"); //создание папки лога
                }

                if (!fileInfo.Exists)
                {
                    fileInfo.Create();
                }
                 #region Gecjw
                //Проверка откуда была запущена программа!!!
                //if (tempPaht.Equals(tempPathDir) )
                // {
                //     MessageBox.Show("[ezct");
                //     WrateTextTemp($"Временный лог.\t\n Текущая версия программы запущена из = {tempPahtFile} А должна быть из {tempPathDir}", tempPaht + "\\");
                //     //GetFailSite();
                // }

                // else
                // {

                // WrateTextTemp($"Временный лог.\t\n Текущая версия программы запущена из = {tempPaht} А не из установочной пaпки{tempPathDir}", tempPaht + "\\");
                // GetFailSite(); //получение новой версии файла Работает
                // MessageBox.Show("Скачивание и копирование завершено!!!");
                // // CopyLinkAppStartup(true);//запись в автозагрузку

                // }
                #endregion
            }

            catch (Exception ex)
            {
                WrateTextTemp("Произошла ошибка при создании главной директории!!! \n" + ex + "\n", tempPaht, true);
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
            DirectoryInfo dirInfo = new DirectoryInfo(@"Log");
            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();// создание кaтолога
                }

            }

            catch (Exception ex)
            {

            }

                using (StreamWriter sw = new StreamWriter(@"Log\Log.txt", true, System.Text.Encoding.Default))

           // using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись

            }
        }

        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Временное логирования
        /// </summary>
        /// <param name="myText"></param>
        public void WrateTextTemp(string myText, string myPachDir, bool zapis)
        {
            DirectoryInfo dirInfo = new DirectoryInfo("\\Log");

            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();// создание кaтолога
                    //Directory.CreateDirectory(myPachDir + "Log"); //создание папки лога
                    // File.Create(myPachDir + @"Log\texLog.txt");
                }

                 using (StreamWriter sw = new StreamWriter(myPachDir, zapis, System.Text.Encoding.Default))
                //using (StreamWriter sw = new StreamWriter(@"Log\Log.txt", true, System.Text.Encoding.Default))
                {
                   // sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись
                    sw.WriteLine(myText); // запись

                }

            }
            catch (Exception ex)
            {

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
        public string OpisanieProgressa { set; get; }
        //public string DateDestination { set; get; }
        //public double Price { set; get; }

       // public Transport(string cityDeparture, string cityDestination, string dateDeparture, string dateDestination, double price)
        public Transport(string _id, string _processName, string _opisanieProgressa)
        {
            this.ID = _id;
            this.ProcessName = _processName;

            OpisanieProgressa = _opisanieProgressa;
            //this.DateDeparture = dateDeparture;
            //this.DateDestination = dateDestination;
            //this.Price = price;
        }
    }
}
