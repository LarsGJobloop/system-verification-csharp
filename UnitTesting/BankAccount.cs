namespace BankAccountNS;

/// <summary>
/// Bank account demo class.
/// </summary>
public class BankAccount
{
        private readonly string customerName;
        private double balance;

        public BankAccount(string customerName, double balance)
        {
                this.customerName = customerName;
                this.balance = balance;
        }

        public string CustomerName
        {
                get { return customerName; }
        }

        public double Balance
        {
                get { return balance; }
        }

        public void Debit(double amount)
        {
                if (
                    amount > balance ||
                    amount < 0 ||
                    double.IsNaN(amount)
                )
                {
                        throw new ArgumentOutOfRangeException("amount");
                }

                balance -= amount;
        }

        public void Credit(double amount)
        {
                if (
                    amount < 0 ||
                    double.IsNaN(amount) ||
                    double.IsInfinity(amount)
                )
                {
                        throw new ArgumentOutOfRangeException("amount");
                }

                balance += amount;
        }
}