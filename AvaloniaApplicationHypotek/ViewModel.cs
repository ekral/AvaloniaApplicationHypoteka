using SharedProject;
using System.ComponentModel;

namespace AvaloniaApplicationHypotek
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        readonly Model model;

        public double LoanAmount
        {
            get => model.LoanAmount; 
            set 
            { 
                model.LoanAmount = value;
                Calculate();
            }
        }

        public double InterestRate
        {
            get => model.InterestRate;
            set 
            { 
                model.InterestRate = value;
                Calculate();
            }
        }

        public int LoanTerm
        {
            get => model.LoanTerm;
            set 
            { 
                model.LoanTerm = value;
                Calculate();
            }
        }

        public double MonthlyPayment
        {
            get => model.MonthlyPayment;
        }

        public ViewModel()
        {
            model = new Model(10000000.0, 6.0, 30);
            Calculate();
        }

        public void Calculate()
        {
            model.CalculateMonthlyPayment();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MonthlyPayment)));
        }
    }
}
