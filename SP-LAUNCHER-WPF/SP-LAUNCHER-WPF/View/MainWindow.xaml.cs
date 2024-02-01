using SP_LAUNCHER_WPF.View;
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

namespace SP_LAUNCHER_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void DOWNLOADBUTTON_Click(object sender, RoutedEventArgs e)
        {
            string folderChoice = (string)selectedFolderTextBox.Content;
            if (!string.IsNullOrEmpty(folderChoice))
            {
                _1STEPDOWNLOAD.Visibility = Visibility.Hidden;
                _2STEPDOWNLOAD.Visibility = Visibility.Visible;
                WELCOME.Visibility = Visibility.Hidden;
                DOWNLOAD_START.Visibility = Visibility.Visible;
                DOWNLOADLAUNCHERTEXT.Visibility = Visibility.Hidden;
                WAITFORDOWNLOAD.Visibility = Visibility.Visible;
                DOWNLOADBUTTON.Visibility = Visibility.Hidden;
                PROGRESSBAR.Visibility = Visibility.Visible;
                choisediskbackground.Visibility = Visibility.Hidden;
                CHOISEBUTTON.Visibility = Visibility.Hidden;
                selectedFolderTextBox.Visibility = Visibility.Hidden;

                string downloadUrl = "http://f0903093.xsph.ru/launcher.zip"; // URL для скачивания файла
                string destinationPath = System.IO.Path.Combine(folderChoice, "launcher.zip"); // Путь и имя файла для сохранения

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

                DownloadEnd DownloadEnd = new DownloadEnd();
                DownloadEnd.ShowDialog();
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
    }
}
