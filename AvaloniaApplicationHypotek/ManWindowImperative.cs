using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationHypotek
{
    public class ManWindowImperative : Window
    {
        public ManWindowImperative()
        {
            StackPanel panel = new StackPanel();
            TextBlock textBlockLoanAmount = new TextBlock() { Text = "Loan Amount" };
            NumericUpDown numericUpDownLoanAmount = new NumericUpDown() { Increment = 200000.0 };
           
            numericUpDownLoanAmount.Bind(NumericUpDown.ValueProperty, new Binding("LoanAmount"));

            TextBlock textBlockMonthlyPayment = new TextBlock();
            textBlockMonthlyPayment.Bind(TextBlock.TextProperty, new Binding("MonthlyPayment"));

            panel.Children.Add(textBlockLoanAmount);
            panel.Children.Add(numericUpDownLoanAmount);
            panel.Children.Add(textBlockMonthlyPayment);

            Content = panel;
        }
    }
}
