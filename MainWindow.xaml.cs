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

namespace firstWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string leftop = ""; 
        string operation = ""; 
        string rightop = ""; 
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textBlock.Text += s;
            decimal num;
            bool result = Decimal.TryParse(s, out num);

            if (result)
            {
                if(operation == "")
                {
                    leftop += s;

                }
                else
                {
                    rightop += s;

                }
            }
            else
            {
                if (s == "=")
                {
                    Updade_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                        
                }
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightop != "")
                    {
                        Updade_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        private void Updade_RightOp()
        {
            decimal num1 = Decimal.Parse(leftop);
            decimal num2 = Decimal.Parse(rightop);
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        rightop = (num1 / num2).ToString();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Error. Division by zero.");
                        leftop = "";
                        rightop = "";
                        operation = "";
                        textBlock.Text = "";

                        break;
                    }
            }
        }
    }
}
