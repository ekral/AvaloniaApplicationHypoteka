namespace SharedProject
{
    public class Model
    {
        private const int frequency = 12;

        public int Id { get; set; }
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }

        public double MonthlyPayment { get; private set; }

        public Model(double loanAmount, double interestRate, int loanTerm)
        {
            LoanAmount = loanAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
        }

        public void CalculateMonthlyPayment()
        {
            double i = InterestRate / (frequency * 100);
            int n = LoanTerm * frequency;
            double v = 1 / (1 + i);

            MonthlyPayment = i * LoanAmount / (1 - Math.Pow(v, n));

        }
    }
}