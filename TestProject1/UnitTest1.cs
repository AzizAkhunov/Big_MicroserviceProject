using GAI.Application.Interfaces;
using GAI.Application.Services;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("AA", "11", true)]
        public void CheckTestPostCreateForPunishment(string account, string password, bool Is)
        {
            var checker = new LogInCheckerService();
            bool result = checker.LogInChecker(account,password);
            string resultt = result == true ? "False" : null;
            Assert.True(Is,resultt);
        }
    }
}