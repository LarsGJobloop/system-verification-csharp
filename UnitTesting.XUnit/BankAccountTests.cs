using BankAccountNS;

namespace BankAccountTests;

/// <summary>
/// Test the functional facts that we want to assert works
/// </summary>
public class BankAccountTests
{
    [Fact]
    public void Account_InitializesCorrectly()
    {
        // Arrange
        string expectedCustomerName = "John Doe";
        double expectedBalance = 100.0;

        // Act
        var account = new BankAccount(expectedCustomerName, expectedBalance);

        // Assert
        Assert.Equal(expectedCustomerName, account.CustomerName);
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Fact]
    public void Credit_IncreasesBalanceByAmount()
    {
        // Arrange
        var account = new BankAccount("John Doe", 100.0);
        double creditAmount = 50.0;
        double expectedBalance = 150.0;

        // Act
        account.Credit(creditAmount);

        // Assert
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Fact]
    public void Credit_ThrowsExceptionWhenAmountIsNegative()
    {
        // Arrange
        var account = new BankAccount("John Doe", 100.0);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(-10.0));
    }

    [Fact]
    public void Debit_DecreasesBalanceByAmount()
    {
        // Arrange
        var account = new BankAccount("John Doe", 100.0);
        double debitAmount = 50.0;
        double expectedBalance = 50.0;

        // Act
        account.Debit(debitAmount);

        // Assert
        Assert.Equal(expectedBalance, account.Balance);
    }

    [Fact]
    public void Debit_ThrowsExceptionWhenAmountExceedsBalance()
    {
        // Arrange
        var account = new BankAccount("John Doe", 100.0);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(150.0));
    }

    [Fact]
    public void Debit_ThrowsExceptionWhenAmountIsNegative()
    {
        // Arrange
        var account = new BankAccount("John Doe", 100.0);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(-10.0));
    }

    [Fact]
    public void Properties_AreReadOnly()
    {
        // Arrange
        var account = new BankAccount("John Doe", 100.0);

        // Act & Assert
        Assert.Equal("John Doe", account.CustomerName);
        Assert.Equal(100.0, account.Balance);

        // Attempting to modify CustomerName or Balance directly should not compile.
        // This test is to ensure the API remains immutable.
    }
}


/// <summary>
/// Excercises the edge cases we have identified. Many are related to common problems
/// encountered when using discrete data structures to represent real world objects.
/// Ie.
/// - Division by 0
/// - Floating point boundaries
/// - Floating point error accumulation
/// </summary>
public class BankAccountEdgeCaseTests
{
    [Theory]
    [InlineData(0)] // Zero amount
    [InlineData(0.01)] // Small positive amount
    [InlineData(-0.01)] // Small negative amount
    [InlineData(double.MaxValue)] // Max double value
    [InlineData(double.MinValue)] // Min double value
    [InlineData(double.Epsilon)] // Smallest positive value
    public void Credit_HandlesEdgeCases(double amount)
    {
        // Arrange
        var account = new BankAccount("Edge Tester", 100.0);

        if (amount < 0)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(amount));
        }
        else
        {
            // Act
            account.Credit(amount);

            // Assert
            Assert.Equal(100.0 + amount, account.Balance, precision: 5);
        }
    }

    [Theory]
    [InlineData(0)] // Zero amount
    [InlineData(0.01)] // Small positive amount
    [InlineData(-0.01)] // Small negative amount
    [InlineData(double.MaxValue)] // Max double value
    [InlineData(double.MinValue)] // Min double value
    [InlineData(double.Epsilon)] // Smallest positive value
    [InlineData(99.99)] // Just under balance
    [InlineData(100.0)] // Exactly equal to balance
    [InlineData(100.01)] // Slightly greater than balance
    public void Debit_HandlesEdgeCases(double amount)
    {
        // Arrange
        var account = new BankAccount("Edge Tester", 100.0);

        if (amount > 100.0 || amount < 0)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(amount));
        }
        else
        {
            // Act
            account.Debit(amount);

            // Assert
            Assert.Equal(100.0 - amount, account.Balance, precision: 5);
        }
    }

    // Broken: This test attempts to verify that rounding issues do not cause incorrect results,
    // but xUnit keeps generating test cases with extremely precise numbers (e.g., 9 decimals),
    // which is beyond the scope of what we want to verify.
    //
    // To fix this, we need to explore:
    // 1. How to control or constrain the input ranges for test cases in xUnit.
    // 2. How to better represent realistic use cases with the desired level of precision.
    //
    // For now, this test is commented out. It serves as an example of how we sometimes
    // need to go back to the documentation to learn or refine our approach.
    //
    // [Theory]
    // [InlineData(0.1, 0.2)] // Simple test for rounding issues with minimal decimal places
    // [InlineData(1.1, -1.1)] // Small positive and negative amounts
    // [InlineData(1.9, 0.1)] // Sum near integer boundary
    // public void Credit_Debit_HandlesRoundingErrors(double creditAmount, double debitAmount)
    // {
    //     // Arrange
    //     var account = new BankAccount("Rounding Tester", 0.0);

    //     // Act
    //     creditAmount = Math.Round(creditAmount, 2);
    //     debitAmount = Math.Round(debitAmount, 2);

    //     // Assert
    //     var expectedBalance = creditAmount + debitAmount;
    //     Assert.True(account.Balance >= 0, "Balance should not be negative due to rounding errors.");
    //     Assert.Equal(expectedBalance, account.Balance, precision: 3);
    // }

    [Theory]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void Credit_ThrowsForInvalidInputs(double amount)
    {
        // Arrange
        var account = new BankAccount("Edge Tester", 100.0);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(amount));
    }

    [Theory]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void Debit_ThrowsForInvalidInputs(double amount)
    {
        // Arrange
        var account = new BankAccount("Edge Tester", 100.0);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(amount));
    }
}
