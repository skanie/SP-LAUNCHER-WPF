using SP_LAUNCHER_MAIN_WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.IO.Compression;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SP_LAUNCHER_MAIN_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Создаем WebClient для загрузки содержимого файла по URL
            WebClient client = new WebClient();

            try
            {
                // Загружаем текстовый файл по указанному URL
                string url = "http://f0903093.xsph.ru/launcher-version.txt";
                string content = client.DownloadString(url);

                // Записываем содержимое файла в переменную
                string fileContent = content;

                // Делаем что-то с переменной fileContent, например, выводим ее значение на экран
                if (version != fileContent)
                {
                    Update Update = new Update();
                    Update.ShowDialog();
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Ошибка загрузки файла: " + ex.Message);
            }
            finally
            {
                // Обязательно освобождаем ресурсы WebClient
                client.Dispose();
            }

            usernameTextBlock.Text = App.NickNameBaseDate;

            string settingsFile = "gamedownload.txt";
            if (File.Exists(settingsFile))
            {
                using (FileStream fs = new FileStream(settingsFile, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        IncarnationDownloadCompleted = bool.Parse(reader.ReadLine());
                        EnigmaDownloadCompleted = bool.Parse(reader.ReadLine());
                        string line = reader.ReadLine();
                        if (line != null) 
                        { 
                            App.IncarnationLink = string.Intern(line); 
                        }
                        else
                        { 

                        }
                        if (line != null)
                        {
                            App.EnigmaLink = string.Intern(reader.ReadLine());
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        string version = "1.0.0.0";

        bool IncarnationChoised = false, 
             IncarnationDownloading = false, 
             IncarnationDownloadCompleted = false;

        bool EnigmaChoised = false, 
             EnigmaDownloading = false, 
             EnigmaDownloadCompleted = false;

        private bool isDragging = false;
        private double offsetX, offsetY;

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            offsetX = e.GetPosition(this).X;
            offsetY = e.GetPosition(this).Y;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                double newX = e.GetPosition(this).X - offsetX;
                double newY = e.GetPosition(this).Y - offsetY;
                this.Left += newX;
                this.Top += newY;
            }
        }

        private void Button_Click_Folder(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog(); // Создаем экземпляр диалога выбора папки

            System.Windows.Forms.DialogResult result = dialog.ShowDialog(); // Открываем диалог и получаем результат

            if (result == System.Windows.Forms.DialogResult.OK) // Если пользователь выбрал папку
            {
                string selectedPath = dialog.SelectedPath; // Получаем выбранный путь

                selectedFolderTextBox.Content = selectedPath; // Отображаем выбранный путь в текстовом поле
            }
        }

        private async void DOWNLOADBUTTON_Click(object sender, RoutedEventArgs e)
        {
            string folderChoice = (string)selectedFolderTextBox.Content;

            if (!string.IsNullOrEmpty(folderChoice))
            {
                string downloadUrl = ""; // URL для скачивания файла
                string destinationPath = ""; // Путь и имя файла для сохранения

                if (IncarnationChoised == true && IncarnationDownloadCompleted == true)
                {
                    string folderPath = App.IncarnationLink;

                    foreach (string filePath in Directory.GetFiles(folderPath))
                    {
                        File.Delete(filePath);
                    }
                    IncarnationDownloadCompleted = false;
                    App.IncarnationLink = "NoLink";
                    DOWNLOADBUTTON.Content = "Установить";
                    selectedFolderTextBox.Content = "";
                    CHOISEBUTTON.Visibility = Visibility.Visible;
                    using (FileStream fs = new FileStream("gamedownload.txt", FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            writer.WriteLine(IncarnationDownloadCompleted.ToString());
                            writer.WriteLine(EnigmaDownloadCompleted.ToString());
                            writer.WriteLine(App.IncarnationLink.ToString());
                            writer.WriteLine(App.EnigmaLink.ToString());
                        }
                    }
                }

                else if (EnigmaChoised == true && EnigmaDownloadCompleted == true)
                {
                    string folderPath = App.EnigmaLink;

                    foreach (string filePath in Directory.GetFiles(folderPath))
                    {
                        File.Delete(filePath);
                    }
                    EnigmaDownloadCompleted = false;
                    App.EnigmaLink = "NoLink";
                    DOWNLOADBUTTON.Content = "Установить";
                    selectedFolderTextBox.Content = "";
                    CHOISEBUTTON.Visibility = Visibility.Visible;
                    using (FileStream fs = new FileStream("gamedownload.txt", FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            writer.WriteLine(IncarnationDownloadCompleted.ToString());
                            writer.WriteLine(EnigmaDownloadCompleted.ToString());
                            writer.WriteLine(App.IncarnationLink.ToString());
                            writer.WriteLine(App.EnigmaLink.ToString());
                        }
                    }
                }

                else
                {
                    if (IncarnationChoised == true)
                    {
                        downloadUrl = "http://f0903093.xsph.ru/launcher.zip";
                        destinationPath = System.IO.Path.Combine(folderChoice, "incarnation.zip");
                        // MessageBox.Show(downloadUrl, destinationPath);
                        IncarnationDownloading = true;
                        MenuGridandStackgames.IsEnabled = false;
                        App.IncarnationLink = (string)selectedFolderTextBox.Content;
                    }

                    if (EnigmaChoised == true)
                    {
                        downloadUrl = "http://f0903093.xsph.ru/launcher.zip";
                        destinationPath = System.IO.Path.Combine(folderChoice, "enigma.zip");
                        // MessageBox.Show(downloadUrl, destinationPath);
                        EnigmaDownloading = true;
                        MenuGridandStackgames.IsEnabled = false;
                        App.EnigmaLink = (string)selectedFolderTextBox.Content;
                    }

                    PROGRESSBAR.Visibility = Visibility.Visible;

                    // Создаем объект WebClient
                    WebClient client = new WebClient();

                    // Определяем событие загрузки прогресса
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);

                    // Определяем событие завершения загрузки
                    client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadCompleted);

                    // Загружаем файл асинхронно
                    await client.DownloadFileTaskAsync(new Uri(downloadUrl), destinationPath);

                    string zipPath = destinationPath;
                    string extractPath = folderChoice;

                    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (File.Exists(System.IO.Path.Combine(extractPath, entry.FullName)))
                            {
                                File.Delete(System.IO.Path.Combine(extractPath, entry.FullName));
                            }
                            entry.ExtractToFile(System.IO.Path.Combine(extractPath, entry.FullName));
                        }
                    }

                    File.Delete(zipPath);

                    if (IncarnationDownloading == true)
                    {
                        IncarnationDownloadCompleted = true;
                        IncarnationDownloading = false;
                        MenuGridandStackgames.IsEnabled = true;
                        DOWNLOADBUTTON.Content = "Удалить";
                        CHOISEBUTTON.Visibility = Visibility.Hidden;
                        PROGRESSBAR.Visibility = Visibility.Hidden;
                        using (FileStream fs = new FileStream("gamedownload.txt", FileMode.Create))
                        {
                            using (StreamWriter writer = new StreamWriter(fs))
                            {
                                writer.WriteLine(IncarnationDownloadCompleted.ToString());
                                writer.WriteLine(EnigmaDownloadCompleted.ToString());
                                writer.WriteLine(App.IncarnationLink.ToString());
                                writer.WriteLine(App.EnigmaLink.ToString());
                            }
                        }
                    }

                    if (EnigmaDownloading == true)
                    {
                        EnigmaDownloadCompleted = true;
                        EnigmaDownloading = false;
                        MenuGridandStackgames.IsEnabled = true;
                        DOWNLOADBUTTON.Content = "Удалить";
                        CHOISEBUTTON.Visibility = Visibility.Hidden;
                        PROGRESSBAR.Visibility = Visibility.Hidden;
                        using (FileStream fs = new FileStream("gamedownload.txt", FileMode.Create))
                        {
                            using (StreamWriter writer = new StreamWriter(fs))
                            {
                                writer.WriteLine(IncarnationDownloadCompleted.ToString());
                                writer.WriteLine(EnigmaDownloadCompleted.ToString());
                                writer.WriteLine(App.IncarnationLink.ToString());
                                writer.WriteLine(App.EnigmaLink.ToString());
                            }
                        }
                    }

                    DownloadEnd DownloadEnd = new DownloadEnd();
                    DownloadEnd.ShowDialog();
                }
            }
            else
            {
                NoFolderChoise NoFolderChoise = new NoFolderChoise();
                NoFolderChoise.ShowDialog();
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Обновляем значение прогресс-бара
            PROGRESSBAR.Value = e.ProgressPercentage;
        }

        private void DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Обработка завершения загрузки файла
            if (e.Error != null)
            {
                NoConnection NoConnection = new NoConnection();
                NoConnection.ShowDialog();
            }
        }

        private void SettingButtonclick(object sender, MouseButtonEventArgs e)
        {
            Settings Settings = new Settings();
            Settings.ShowDialog();
        }

        private void MenuButtonclick(object sender, MouseButtonEventArgs e)
        {
            if (MenuGridandStackgames.Visibility == Visibility.Visible)
            {
                MenuGridandStackgames.Visibility = Visibility.Hidden;
            }
            else
            {
                MenuGridandStackgames.Visibility = Visibility.Visible;
            }
        }

        private void TurnUpButtonclick(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButtonclick(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void IncarnationInstallclick(object sender, RoutedEventArgs e)
        {
            ChoiseFolderGame.Visibility = Visibility.Visible;
            DOWNLOADBUTTON.Visibility = Visibility.Visible;
            CHOISEBUTTON.Visibility = Visibility.Visible;
            WELCOME.Visibility = Visibility.Hidden;
            IncarnationChoised = true;
            EnigmaChoised = false;

            if (IncarnationDownloadCompleted == true)
            {
                CHOISEBUTTON.Visibility = Visibility.Hidden;
                DOWNLOADBUTTON.Content = "Удалить";
                selectedFolderTextBox.Content = App.IncarnationLink;
            }

            if (IncarnationDownloadCompleted == false)
            {
                DOWNLOADBUTTON.Content = "Установить";
                selectedFolderTextBox.Content = "";
            }
        }
        private void EnigmaInstallclick(object sender, RoutedEventArgs e)
        {
            ChoiseFolderGame.Visibility = Visibility.Visible;
            DOWNLOADBUTTON.Visibility = Visibility.Visible;
            CHOISEBUTTON.Visibility = Visibility.Visible;
            WELCOME.Visibility = Visibility.Hidden;
            EnigmaChoised = true;
            IncarnationChoised = false;

            if (EnigmaDownloadCompleted == true)
            {
                CHOISEBUTTON.Visibility = Visibility.Hidden;
                DOWNLOADBUTTON.Content = "Удалить";
                selectedFolderTextBox.Content = App.EnigmaLink;
            }

            if (EnigmaDownloadCompleted == false)
            {
                DOWNLOADBUTTON.Content = "Установить";
                selectedFolderTextBox.Content = "";
            }
        }
    }
}
