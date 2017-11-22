using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SzteDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultTextBlock.Text = await GetPage();
            }
            catch
            {
                resultTextBlock.Text = "Something went wrong, maybe a bad url?";
            }
        }

        private async Task<string> GetPage()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(urlInputTextBox.Text);
            return "Status code: " + result.StatusCode.ToString();
        }

        private void animationButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AnimationDemo));
        }
    }
}
