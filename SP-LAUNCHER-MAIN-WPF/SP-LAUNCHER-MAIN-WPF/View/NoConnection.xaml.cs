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
    /// Логика взаимодействия для NoConnection.xaml
    /// </summary>
    public partial class NoConnection : Window
    {
        public NoConnection()
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
            this.Close();
        }
    }
}
