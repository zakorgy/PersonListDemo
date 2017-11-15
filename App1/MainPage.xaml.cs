using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private System.Collections.ObjectModel.ObservableCollection<Person> personlist;
        public MainPage()
        {
            this.InitializeComponent();
            personlist = new System.Collections.ObjectModel.ObservableCollection<Person>()
            {
                new Person(){Name="Bubu", Age=3},
                new Person(){Name="Bub2", Age=5},
            };
            Random rnd = new Random();
            for(int i = 0; i < 20; i++)
            {
                personlist.Add(new Person() {
                    Name = "Huba" + i,
                    Age = rnd.Next(1, 100)
                });
            }
            personListView.ItemsSource = personlist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            personlist.Add(new Person() {
                Name = "Dynamic",
                Age = 2
            });
        }
    }
}
