﻿using System;
using System.Data;
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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Newcalculator
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
        public bool Point = true;

        private string Get_Result(string Operations)
        {
            DataTable table = new DataTable().compute(Operations,"");
            string numss = table.ToString();
            return table;
        }

        //private void Button_Click_Operator(object sender,RoutedEventArgs e)
        //{
        //    Button tempBTN = (Button)sender;
        //    if (AbleToAddop)
        //    {

        //    }
        //}
        private void Button_Click_Point(object sender, RoutedEventArgs e)
        {
            if (OutputText != "Error")
            {
                if (Point)
                {
                    if (InputText != "")
                    {
                        InputText += ".";
                    }
                    else
                    {
                        InputText = "0.";
                    }
                    Point = false;
                }
                InputBox.Text = InputText;
            }
            OutputBox.Text = Get_Result(OutputBox.Text);
            AbleToAddop = true;
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
            }
            else
            {
                OutputBox.Text = "Please Clear it.";
            }
            OutputBox.Text = Get_Result(OutputBox.Text);
            AbleToAddop = true;
        }
    }
}
