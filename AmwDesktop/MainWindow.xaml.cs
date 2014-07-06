using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using AirMedia.Core.Log;
using AirMedia.Core.Requests.Controller;
using AirMedia.Core.Requests.Interfaces;
using AirMedia.Core.Requests.Model;
using AmwDesktop.Controller.Requests.Impl;
using MessageBox = System.Windows.Forms.MessageBox;
using DialogResultEnum = System.Windows.Forms.DialogResult;
using AmwDesktop.Data;

namespace AmwDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRequestResultListener
    {
        public MainWindow()
        {
            InitializeComponent();
            MinimizeToTray.Enable(this);

            try
            {
                AmwDBContext.DeleteAndCreate();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ReloadList()
        {
            var snm = AmwDBContext.GetDirectories();
            var items = snm.Select(folderEntity => new UI.ViewModel.SyncableDirectoryListItem(folderEntity) );
            foldersListbox.ItemsSource = items;
        }

        private void addWatchedFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.RootFolder = Environment.SpecialFolder.UserProfile;
            var dr = folderBrowser.ShowDialog();
            if (dr != DialogResultEnum.OK)
                return;

            if (AmwDBContext.CanSyncDirectory(folderBrowser.SelectedPath))
            {
                MessageBox.Show("Папка уже добавлена");
                return;
            }
            AmwDBContext.AddDirectory(folderBrowser.SelectedPath);

            ReloadList();

            RequestManager.Instance.SubmitRequest(new FindMediaFilesInDirectoryRequest(), true);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadList();

            RequestManager.Instance.RegisterEventHandler(this);
        }

        private void removeSelectedDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var snm = (UI.ViewModel.SyncableDirectoryListItem) foldersListbox.SelectedValue;
            if (snm == null)
                return;
            AmwDBContext.RemoveDirectory(snm.Path);
            ReloadList();
        }

        public void HandleRequestResult(object sender, ResultEventArgs args)
        {
            AmwLog.Info("tag", "JOB FINISHED:_)");
        }
    }
}
