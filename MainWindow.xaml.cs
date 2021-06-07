using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    public partial class MainWindow : Window
    {
        string lefttop = "";
        string operation = "";
        string righttop = "";
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement el in LayoutRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }
        private void Button_Click (object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            workField.Text += s;
            int num;
            bool res = Int32.TryParse(s,out num);
            if(res == true)
            {
                if(operation =="")
                {
                    lefttop += s;
                }
                else
                {
                    righttop += s;
                }
            }
            else
            {
                if(s=="=")
                {
                    Update_RightOp();
                    workField.Text += righttop;
                    operation = "";
                }
                else if(s=="CLEAR")
                {
                    lefttop = "";
                    righttop = "";
                    operation = "";
                    workField.Text = "";
                }
                else
                {
                    if(righttop != "")
                    {
                        Update_RightOp();
                        lefttop = righttop;
                        righttop = "";
                    }
                    operation = s;
                }
            }
        }
        private void Update_RightOp()
        {
            int num1 = Int32.Parse(lefttop);
            int num2 = Int32.Parse(righttop);
            switch(operation)
            {
                case "+":
                    righttop = (num1 + num2).ToString();
                    break;
                case "-":
                    righttop = (num1 - num2).ToString();
                    break;
                case "*":
                    righttop = (num1 * num2).ToString();
                    break;
                case "/":
                    righttop = (num1 / num2).ToString();
                    break;
            }
        }
    }
}
