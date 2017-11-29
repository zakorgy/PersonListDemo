using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationDataContainer localSettings =
                ApplicationData.Current.LocalSettings;
            if (localSettings.Values["mykey"] != null)
            {
                localSettingTextBlock.Text = localSettings.Values["mykey"].ToString();
            }

            // Roaming stuff
            ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;
            localSettingTextBlock.Text = ApplicationData.Current.RoamingStorageQuota.ToString();
        }

        private async void saveto_Storage_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings =
                ApplicationData.Current.LocalSettings;

            localSettings.Values["mykey"] = inputTextBox.Text;

            StorageFolder localFolder =
                ApplicationData.Current.LocalFolder;

            StorageFile file = await localFolder.CreateFileAsync("demo.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, inputTextBox.Text);
            filePath.Text = file.Path;
        }

        private async void loadFromStorage_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder localFolder =
                ApplicationData.Current.LocalFolder;

            StorageFile file = await localFolder.GetFileAsync("demo.txt");
            localSettingTextBlock.Text = await FileIO.ReadTextAsync(file);
        }
    }
}
