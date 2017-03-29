using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Calculator
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        public bool AbleToAddop;
        public string InputText = "0";
        public string OutputText = "0";
        public bool Operator;

        
        private void Button_Click_Num(object sender, RoutedEventArgs e)
        {
            Button tempBTN = (Button)sender;
            if (OutputText != "Error!")
            {
                if (InputBox.Text == "0")
                {
                    InputText = tempBTN.Content.ToString();
                }
                else
                {
                    InputText += tempBTN.Content.ToString();
                }
                InputBox.Text = InputText;
            }
            else
            {
                OutputBox.Text = "Please Clear it.";
            }
            AbleToAddop = true;
        }
    }
}