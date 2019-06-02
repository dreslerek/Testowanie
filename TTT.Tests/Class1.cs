using NUnit.Framework;

namespace TTT.Tests
{
    [TestFixture]
    public class UserOrderServiceTests
    {
        [TestCase]
        public void When_PremiumUser_Expect_10PercentDiscount()
        {
            User premiumUser = new User
            {
                UserId = 1,
                UserName = "George",
                UserType = UserType.Premium
            };

            Order order = new Order
            {
                OrderId = 1,
                ProductId = 212,
                ProductQuantity = 1,
                Amount = 150
            };

            UserOrderService userOrderService = new UserOrderService();

            userOrderService.ApplyDiscount(premiumUser, order);

            Assert.AreEqual(order.Amount, 135);
        }
        [TestCase]
        public void When_NameContainsPolishChars_Expect_ContainsPolishChars_ReturnsTrue()
        {
            User user = new User
            {
                UserId = 2,
                UserName = "Michał",
                UserType = UserType.Premium
            };

            var result = user.ContainsPolishChars();

            Assert.IsTrue(result);
        }
        [TestCase]
        public void When_NameDoesNotContainPolishChars_Expect_DoesNotContainPolishChars_ReturnsFalse()
        {
            User user = new User
            {
                UserId = 2,
                UserName = "Wojtek",
                UserType = UserType.Premium
            };

            var result = user.ContainsPolishChars();

            Assert.IsFalse(result);
        }

    }
    [TestFixture]
    public class UserInfoTests
    {
        [TestCase]
        public void When_PasswordIsLongEnough_Expect_PasswordIsLongEnough_ReturnsTrue()
        {
            User user = new User
            {
                password = "12345678"
            };

            var result = user.IsPasswordLongEnough();

            Assert.IsTrue(result);
        }
        [TestCase]
        public void When_PasswordIsLongEnough_Expect_PasswordIsNotLongEnough_ReturnsFalse()
        {
            User user = new User
            {
                password = "1234"
            };

            var result = user.IsPasswordLongEnough();

            Assert.IsFalse(result);
        }
        [TestCase(29, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(60, ExpectedResult = true)]
        [TestCase(80, ExpectedResult = true)]
        [TestCase(90, ExpectedResult = true)]
        public bool When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizenAsTrue(int age)
        {
            User user = new User();
            user.Age = age;

            bool result = user.IsSeniorCitizen();

            return result;
        }


    }



    }