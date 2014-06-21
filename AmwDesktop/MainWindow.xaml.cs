using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using DialogResultEnum = System.Windows.Forms.DialogResult;
using AmwDesktop.Data;
using AmwDesktop.Data.Models;

namespace AmwDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinimizeToTray.Enable(this);
        }

        private void LoadList()
        {
            var snm = AmwDBContext.GetFolders();
            var items = snm.Select(a => new { ShortPath = System.IO.Path.GetFileName(a.Path), Path=a.Path } );
            foldersListbox.ItemsSource = items;
        }

        private void addWatchedFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var v = new FolderBrowserDialog();
            v.RootFolder = Environment.SpecialFolder.UserProfile;
            var dr = v.ShowDialog();
            if (dr == DialogResultEnum.OK)
            {
                AmwDBContext.AddFolder(new Data.Models.SyncableDirectory() { Path = v.SelectedPath });
                LoadList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
    }
}
