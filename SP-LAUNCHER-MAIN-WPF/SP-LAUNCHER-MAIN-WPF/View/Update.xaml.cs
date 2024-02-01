using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Update()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string updatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Update.exe");

            if (System.IO.File.Exists(updatePath))
            {
                System.Diagnostics.Process.Start(updatePath);
            }
            else
            {
                MessageBox.Show("Файл Update.exe не найден.");
            }
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
    }
}
