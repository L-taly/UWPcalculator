using System.Windows.Input;
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
        public void Button_Click_Point(object sender, RoutedEventArgs e)
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

        private void Button_Click_Operator(object sender, RoutedEventArgs e, string n)
        {
            if (OutputText != "Error!")
            {
                if (AbleToAddop)
                {
                    InputText = InputText.TrimEnd('.');
                    InputText += n;
                }
                InputBox.Text = InputText;
            }
            AbleToAddop = false;
        }

        private void Button_Click_Num(object sender, RoutedEventArgs e, string n)
        {
            if (OutputText != "Error!")
            {
                if (InputBox.Text == "0")
                {
                    InputText = n;
                }
                else
                {
                    InputText += n;
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
            else if (InputText.Length != 0 && char.IsDigit(InputText[InputText.Length - 1]))
            {
                OutputBox.Text = (new BinaryTree(InputText)).GetResult().ToString();
            }
            InputBox.Text = InputText;
        }
        private void Pivot_KeyUp(object sender, KeyRoutedEventArgs e)//监测是否松开Shift键
        {
            if (e.Key == Windows.System.VirtualKey.LeftShift) isShiftKeyPressed = false;
        }
        private void Pivot_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.LeftShift) isShiftKeyPressed = true;//判断是否按下Shift键
            if (isShiftKeyPressed == false)
            {
                if (e.Key == VirtualKey.Back)
                {
                    Button_Click_Delete(sender, e);
                }
                if (e.Key == VirtualKey.Number1 || e.Key == VirtualKey.NumberPad1)
                    Button_Click_1(sender, e);
                if (e.Key == VirtualKey.Number2 || e.Key == VirtualKey.NumberPad2)
                    Button_Click_2(sender, e);
                if (e.Key == VirtualKey.Number3 || e.Key == VirtualKey.NumberPad3)
                    Button_Click_3(sender, e);
                if (e.Key == VirtualKey.Number4 || e.Key == VirtualKey.NumberPad4)
                    Button_Click_4(sender, e);
                if (e.Key == VirtualKey.Number5 || e.Key == VirtualKey.NumberPad5)
                    Button_Click_5(sender, e);
                if (e.Key == VirtualKey.Number6 || e.Key == VirtualKey.NumberPad6)
                    Button_Click_6(sender, e);
                if (e.Key == VirtualKey.Number7 || e.Key == VirtualKey.NumberPad7)
                    Button_Click_7(sender, e);
                if (e.Key == VirtualKey.Number8 || e.Key == VirtualKey.NumberPad8)
                    Button_Click_8(sender, e);
                if (e.Key == VirtualKey.Number9 || e.Key == VirtualKey.NumberPad9)
                    Button_Click_9(sender, e);
                if (e.Key == VirtualKey.Number0 || e.Key == VirtualKey.NumberPad0)
                    Button_Click_0(sender, e);
                if (e.Key == VirtualKey.Add)
                    Button_Click_Add(sender, e);
                if (e.Key == VirtualKey.Subtract || (int)e.Key == 189)
                    Button_Click_Subtract(sender, e);
                if (e.Key == VirtualKey.Multiply)
                    Button_Click_Multiply(sender, e);
                if (e.Key == VirtualKey.Divide || (int)e.Key == 191)
                    Button_Click_Divide(sender, e);
                if (e.Key == VirtualKey.Decimal || (int)e.Key == 190)
                    Button_Click_Point(sender, e);
            }
            else if (isShiftKeyPressed == true)//这个是因为UWP没有具体的VirtualKey，直接用值
            {
                if ((int)e.Key == 187)
                    Button_Click_Add(sender, e);
                if (e.Key == VirtualKey.Number8)
                    Button_Click_Multiply(sender, e);
            }
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            string n = "0";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string n = "1";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string n = "2";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string n = "3";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string n = "4";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string n = "5";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string n = "6";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string n = "7";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string n = "8";
            Button_Click_Num(sender, e, n);
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            string n = "9";
            Button_Click_Num(sender, e, n);
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string n = "+";
            Button_Click_Operator(sender, e, n);
        }
        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            string n = "/";
            Button_Click_Operator(sender, e, n);
        }
        private void Button_Click_Subtract(object sender, RoutedEventArgs e)
        {
            string n = "-";
            Button_Click_Operator(sender, e, n);
        }
        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            string n = "*";
            Button_Click_Operator(sender, e, n);
        }
    }
}