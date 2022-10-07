using Avalonia.Controls;
using SharedProject;

namespace AvaloniaApplicationFormApp
{
    public class MainWindow : Window
    {
        private readonly Model model;

        private readonly StackPanel panel;
        private readonly TextBlock textBlockLoanAmount;
        private readonly NumericUpDown numericUpDownLoanAmount;
        private readonly TextBlock textBlockInterestRate;
        private readonly NumericUpDown numericUpDownInterestRate;
        private readonly TextBlock textBlockLoanTerm;
        private readonly NumericUpDown numericUpDownLoanTerm;
        private readonly TextBlock textBlockMonthlyPayment;
        private readonly Button buttonCalculate;

        public MainWindow()
        {
            model = new Model(10000000.0, 6.0, 30);
            model.CalculateMonthlyPayment();

            panel = new StackPanel();

            textBlockLoanAmount = new TextBlock() { Text = "Loan Amount" };
            numericUpDownLoanAmount = new NumericUpDown() { Value = model.LoanAmount, Increment = 200000.0 };

            textBlockInterestRate = new TextBlock() { Text = "Interest Rate" };
            numericUpDownInterestRate = new NumericUpDown() { Value = model.InterestRate };

            textBlockLoanTerm = new TextBlock() { Text = "Loan Term" };
            numericUpDownLoanTerm = new NumericUpDown() { Value = model.LoanTerm };

            textBlockMonthlyPayment = new TextBlock();
            SetMonthlyPayment(model.MonthlyPayment);

            buttonCalculate = new Button() { Content = "Calculate" };

            buttonCalculate.Click += (s, e) => Calculate();
            numericUpDownLoanAmount.ValueChanged += (s, e) => Calculate();
            numericUpDownInterestRate.ValueChanged += (s, e) => Calculate();
            numericUpDownLoanTerm.ValueChanged += (s, e) => Calculate();

            panel.Children.Add(textBlockLoanAmount);
            panel.Children.Add(numericUpDownLoanAmount);
            panel.Children.Add(textBlockInterestRate);
            panel.Children.Add(numericUpDownInterestRate);
            panel.Children.Add(textBlockLoanTerm);
            panel.Children.Add(numericUpDownLoanTerm);
            panel.Children.Add(buttonCalculate);
            panel.Children.Add(textBlockMonthlyPayment);

            Content = panel;
        }

        private void SetMonthlyPayment(double monthlyPayment)
        {
            textBlockMonthlyPayment.Text = monthlyPayment.ToString("C2");
        }

        private void Calculate()
        {
            model.LoanAmount = numericUpDownLoanAmount.Value;
            model.InterestRate = numericUpDownInterestRate.Value;
            model.LoanTerm = (int)numericUpDownLoanTerm.Value;

            model.CalculateMonthlyPayment();
            
            SetMonthlyPayment(model.MonthlyPayment);
        }
    }
}
