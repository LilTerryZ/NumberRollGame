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
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NumberRollGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstPage : Page
    {
        
        public string PName;
        Player player = new Player("");
        public FirstPage()
        {
            this.InitializeComponent();
        }
    
        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) {
                var Msg = new MessageDialog("Please enter a valid name");
                await Msg.ShowAsync();
            }
            else {
                PName = txtName.Text;
                var Msg1= new MessageDialog($"Welcome { PName } ! Have fun and good luck!");
                await Msg1.ShowAsync();
                this.Frame.Navigate(typeof(MainPage), PName);


            }
        }
        public string Na() { return PName; }
       
    }
}
