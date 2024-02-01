using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SP_LAUNCHER_MAIN_WPF.View
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            string settingsFile = "settings.txt";
            if (File.Exists(settingsFile))
            {
                using (FileStream fs = new FileStream(settingsFile, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        OnLauncherIsPcCheckCheckButtonclickactive = bool.Parse(reader.ReadLine());
                        GoToTrayCheckButtonclickactive = bool.Parse(reader.ReadLine());
                    }
                }
            }
            if (OnLauncherIsPcCheckCheckButtonclickactive == false)
            {
                OnLauncherispc.Source = new BitmapImage(new Uri("\\View\\Res\\Icon\\icon_close.png", UriKind.Relative));
            }
            if (GoToTrayCheckButtonclickactive == false)
            {
                gototray.Source = new BitmapImage(new Uri("\\View\\Res\\Icon\\icon_close.png", UriKind.Relative));
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

        private void savesettings_click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("settings.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(OnLauncherIsPcCheckCheckButtonclickactive.ToString());
                    writer.WriteLine(GoToTrayCheckButtonclickactive.ToString());
                }
            }
        }

        bool OnLauncherIsPcCheckCheckButtonclickactive = true;
        bool GoToTrayCheckButtonclickactive = true;

        private void GoToTrayCheckButtonclick(object sender, MouseButtonEventArgs e)
        {
            if (gototray.Source.ToString().Contains("icon_close.png"))
            {
                gototray.Source = new BitmapImage(new Uri("\\View\\Res\\Icon\\icon _check_.png", UriKind.Relative));
                GoToTrayCheckButtonclickactive = true;
            }
            else
            {
                gototray.Source = new BitmapImage(new Uri("\\View\\Res\\Icon\\icon_close.png", UriKind.Relative));
                GoToTrayCheckButtonclickactive = false;
            }
        }

        private void OnLauncherIsPcCheckCheckButtonclick(object sender, MouseButtonEventArgs e) 
        { 
            if (OnLauncherispc.Source.ToString().Contains("icon_close.png")) 
            { 
                OnLauncherispc.Source = new BitmapImage(new Uri("\\View\\Res\\Icon\\icon _check_.png", UriKind.Relative));
                OnLauncherIsPcCheckCheckButtonclickactive = true;
            } 
            else 
            { 
                OnLauncherispc.Source = new BitmapImage(new Uri("\\View\\Res\\Icon\\icon_close.png", UriKind.Relative));
                OnLauncherIsPcCheckCheckButtonclickactive = false;
            } 
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
