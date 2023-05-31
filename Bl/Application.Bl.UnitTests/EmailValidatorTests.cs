using NUnit.Framework;

namespace Application.Bl.UnitTests
{
    public class EmailValidatorTests
    {
        [Test]
        [TestCase("application@dot.com", true)]
        [TestCase("applicationdot.com", false)]
        [TestCase("application.11@dot.com", true)]
        public void CheckEmail(string email, bool isValid)
        {
            var emailValidator = new EmailValidator();

            Assert.That(emailValidator.IsValid(email), Is.EqualTo(isValid));
        }
    }
}