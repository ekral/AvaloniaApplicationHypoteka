using AvaloniaApplicationHypotek;

namespace TestProjectHypoteka
{
    public class UnitTestHypoteka
    {
        [Fact]
        public void TestValidniDataSpravnaSplatka()
        {
            Model model = new Model();
            double monthly = model.MonthlyPayment(10000000.0, 6.0, 30);
            Assert.Equal(59955.05, monthly, 2);
        }

        [Fact]
        public void TestViewModelValidniDataSpravnaSplatka()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.LoanAmount = 10000000.0;
            viewModel.InterestRate = 6.0;
            viewModel.LoanTerm = 30;

            viewModel.Calculate();

            Assert.Equal(59955.05, viewModel.MonthlyPayment, 2);
        }
    }
}