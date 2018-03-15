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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace PictureViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Image image;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Filter|*.bmp;*.png;*.jpg;*.jpeg|All Files|*.*";
            openDialog.InitialDirectory = @"PictureViewer";
            openDialog.Title = "Load Picture";

            if (openDialog.ShowDialog().Value)
            {
                
                string fileName = openDialog.FileName;
                image = new Image();

                image.Source = null;
                Grid.SetColumn(image, 0);
                Grid.SetRow(image, 1);
                Grid.SetColumnSpan(image, 2);

                BitmapImage bmpImage = new BitmapImage();
                bmpImage.BeginInit();
                bmpImage.UriSource = new Uri(fileName, UriKind.RelativeOrAbsolute);
                bmpImage.EndInit();
                image.Source = bmpImage;

                Grid.SetColumn(image, 0);
                Grid.SetRow(image, 1);
                Grid.SetColumnSpan(image, 2);
                grid.Children.Add(image);

                txtStatus.Text = fileName;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (image != null)
            {
                image.Source = null;
                txtStatus.Text = "Ready";
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (image != null)
            {
                image.Stretch = Stretch.Uniform;
                grid.UpdateLayout();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            image.Stretch = Stretch.Fill;
            grid.UpdateLayout();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }
    }
}
