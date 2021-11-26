using System;

public class Class1
{
	public Class1()
	{
        [Test]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actualResult);
        }
            [
                Test,
                TestCase("abcd1234", false),
                TestCase("irf@uni-corvinus", false),
                TestCase("irf.uni-corvinus.hu", false),
                TestCase("irf@uni-corvinus.hu", true)
            ]

            [
            Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
            ]
        public void TestRegisterHappyPath(string email, string password)
            {

            
            var accountServiceMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Returns<Account>(a => a);
            var accountController = new AccountController();
            accountController.AccountManager = accountServiceMock.Object;

          
            var actualResult = accountController.Register(email, password);

          
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
            accountServiceMock.Verify(m => m.CreateAccount(actualResult), Times.Once);



        }
        [
                Test,
                TestCase("irf@uni-corvinus", "Abcd1234"),
                TestCase("irf.uni-corvinus.hu", "Abcd1234"),
                TestCase("irf@uni-corvinus.hu", "abcd1234"),
                TestCase("irf@uni-corvinus.hu", "ABCD1234"),
                TestCase("irf@uni-corvinus.hu", "abcdABCD"),
                TestCase("irf@uni-corvinus.hu", "Ab1234"),
            ]
        public void TestRegisterValidateException(string email, string password)
            {
            // Arrange
            var accountController = new AccountController();

            // Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }

            }

}
