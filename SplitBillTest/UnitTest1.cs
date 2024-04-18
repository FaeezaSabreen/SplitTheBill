namespace SplitBillTest;
using SplitBillLib;

    [TestClass]
    public class TestCalculateTipTests
    {
        [TestMethod]
        public void TestCalculateTip_WithValidData_ShouldReturnCorrectTipAmounts()
        {
            // Arrange
            var calculator = new TestCalculateTip();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Rob", 25.00m },
                { "Ben", 35.00m },
                { "Christian", 45.00m }
            };
            float tipPercentage = 20;

            // Act
            var tipAmounts = calculator.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(5.00m, tipAmounts["Rob"]);
            Assert.AreEqual(7.00m, tipAmounts["Ben"]);
            Assert.AreEqual(9.00m, tipAmounts["Christian"]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestCalculateTip_WithInvalidTipPercentage_ShouldThrowArgumentException()
        {
            // Arrange
            var calculator = new TestCalculateTip();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Rob", 25.00m },
                { "Ben", 35.00m },
                { "Christian", 45.00m }
            };
            float tipPercentage = -10;

            // Act
            var tipAmounts = calculator.CalculateTip(mealCosts, tipPercentage);

        }

        [TestMethod]
        public void TestCalculateTip_WithZeroTotalCost_ShouldReturnZeroTipAmounts()
        {
            // Arrange
            var calculator = new TestCalculateTip();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Rob", 0.00m },
                { "Ben", 0.00m },
                { "Christian", 0.00m }
            };
            float tipPercentage = 15;

            // Act
            var tipAmounts = calculator.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(0, tipAmounts["Rob"]);
            Assert.AreEqual(0, tipAmounts["Ben"]);
            Assert.AreEqual(0, tipAmounts["Christian"]);
        }
    }
     [TestClass]
    public class PaymentCalculatorTests
    {
        [TestMethod]
        public void TestSplitAmount_ValidData_ShouldReturnCorrectAmount()
        {
            // Arrange
            var calculator = new PaymentCalculator();
            decimal totalAmount = 100.00m;
            int numberOfPeople = 4;

            // Act
            decimal splitAmount = calculator.SplitAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.AreEqual(25.00m, splitAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSplitAmount_InvalidNumberOfPeople_ShouldThrowArgumentException()
        {
            // Arrange
            var calculator = new PaymentCalculator();
            decimal totalAmount = 100.00m;
            int numberOfPeople = 0;

            // Act
            decimal splitAmount = calculator.SplitAmount(totalAmount, numberOfPeople);

          
        }

        [TestMethod]
        public void TestCalculateTip_NotImplemented_ShouldThrowNotImplementedException()
        {
            // Arrange
            var calculator = new PaymentCalculator();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Alice", 20.00m },
                { "Bob", 30.00m },
                { "Charlie", 40.00m }
            };
            float tipPercentage = 15;

            // Act & Assert
            Assert.ThrowsException<NotImplementedException>(() => calculator.CalculateTip(mealCosts, tipPercentage));
        }
    }
 [TestClass]
    public class TestTipPerPersonTests
    {
        [TestMethod]
        public void TestTipPerPerson_ValidData_ShouldReturnCorrectAmount()
        {
            // Arrange
            var calculator = new TestTipPerPerson();
            decimal price = 60.00m; 
            int numberOfPatrons = 6; 
            float tipPercentage = 25; 
            // Act
            decimal tipPerPerson = calculator.TipPerPerson(price, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(2.50m, tipPerPerson); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTipPerPerson_InvalidNumberOfPatrons_ShouldThrowArgumentException()
        {
            // Arrange
            var calculator = new TestTipPerPerson();
            decimal price = 70.00m; 
            int numberOfPatrons = -2; 
            float tipPercentage = 20; 

            // Act
            decimal tipPerPerson = calculator.TipPerPerson(price, numberOfPatrons, tipPercentage);

            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTipPerPerson_InvalidTipPercentage_ShouldThrowArgumentException()
        {
            // Arrange
            var calculator = new TestTipPerPerson();
            decimal price = 80.00m; 
            int numberOfPatrons = 8; 
            float tipPercentage = 110; 

            // Act
            decimal tipPerPerson = calculator.TipPerPerson(price, numberOfPatrons, tipPercentage);

           
        }
    }