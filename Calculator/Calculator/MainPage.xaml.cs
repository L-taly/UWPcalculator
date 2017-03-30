using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
        public bool preNum = false;
        public bool AbleToAddop = false;
        public string InputText = "0";
        public string OutputText = "0";
        public bool Operator;
        public bool Point = true;
        public bool isShiftKeyPressed = false;

        //private string Get_Result(string Operations)
        //{

            
        //}

        //private void Button_Click_Operator(object sender,RoutedEventArgs e)
        //{
        //    Button tempBTN = (Button)sender;
        //    if (AbleToAddop)
        //    {

        //    }
        //}
        private void Button_Click_Point(object sender, RoutedEventArgs e)
        {
            int len = InputText.Length;
            if (OutputText != "Error")
            {
                if (Point)
                {
                    if (InputText != "")
                    {
                        InputText += ".";
                        Point = false;
                        AbleToAddop = true;
                    }
                    else
                    {
                        InputText = "0.";
                        Point = false;
                        AbleToAddop = true;
                    }                    
                }
                InputBox.Text = InputText;

            }

        }

        private void Button_Click_Operator(object sender, RoutedEventArgs e)
        {
            Button tempBTN = (Button)sender;
            if(OutputText != "Error!")
            {
                if (AbleToAddop)
                {

                        InputText = InputText.TrimEnd('.');
                        InputText += tempBTN.Content.ToString();
                }
                InputBox.Text = InputText;
            }
            AbleToAddop = false;
        }

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
                preNum = true;
                OutputBox.Text = (new BinaryTree(InputBox.Text)).GetResult().ToString();
            }
            else
            {
                OutputBox.Text = "Please Clear it.";
            }
            if (preNum && !AbleToAddop)
            {
                Point = true;
            }
            AbleToAddop = true;
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            InputText = InputText.Substring(0, InputText.Length - 1);
            if (InputText.Length == 0)
            {
                InputText = "0";
                OutputBox.Text = "0";
            }
            else if (InputText.Length != 0 && !char.IsDigit(InputText[InputText.Length - 1]))
            {
                OutputBox.Text = (new BinaryTree(InputText.Substring(0, InputText.Length - 1))).GetResult().ToString();
            }
            else if(InputText.Length != 0 && char.IsDigit(InputText[InputText.Length - 1]))
            {
                OutputBox.Text = (new BinaryTree(InputText)).GetResult().ToString();
            }
            InputBox.Text = InputText;
        }

        //private void PivotItem_KeyDown(object sender, KeyRoutedEventArgs e)
        //{
            
        //    if(e.Key == VirtualKey.Shift)
        //    {
        //        isShiftKeyPressed = true;
        //    }
        //    else if(isShiftKeyPressed == false)
        //    {
        //        if (e.Key == VirtualKey.Number1)
        //            Button_Click_Num(sender, e);
        //    }
        //}

        //private void Button_KeyDown2(KeyRoutedEventArgs e)
        //{
        //    if(e.Key == VirtualKey.Number2)
        //    {
        //        Button_Click_Num(, e);
        //    }
        //}
    }
}