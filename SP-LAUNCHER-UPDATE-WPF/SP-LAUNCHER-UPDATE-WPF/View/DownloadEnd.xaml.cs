﻿using System;
using System.Collections.Generic;
using System.IO.Compression;
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
using System.Net;
using System.IO;

namespace SP_LAUNCHER_UPDATE_WPF.View
{
    /// <summary>
    /// Логика взаимодействия для DownloadEnd.xaml
    /// </summary>
    public partial class DownloadEnd : Window
    {
        public DownloadEnd()
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
            Application.Current.Shutdown();
        }
    }
}