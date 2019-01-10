using NUnit.Framework;

namespace Framework
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void FindEmptyDestinationRoute()
        {
            steps.FindRoute("LED", "");
            Assert.AreEqual("Empty field", steps.GetBadDestinationError());
        }

        [Test]
        public void FindOriginationEqualsDestinationRoute()
        {
            steps.FindRoute("LED", "LED");
            Assert.AreEqual("Empty field", steps.GetBadOriginationError());
        }

        [Test]
        public void FindRouteInPast()
        {
            steps.FindRouteInPast("LED", "MSQ");
            Assert.AreEqual("Select departure and return dates", steps.GetDateError());
        }



        //[Test]
        //public void OneCanLoginGithub()
        //{
        //    steps.LoginGithub(USERNAME, PASSWORD);
        //    Assert.AreEqual(USERNAME, steps.GetLoggedInUserName());
        //}

        //[Test]
        //public void OneCanCreateProject()
        //{
        //    steps.LoginGithub(USERNAME, PASSWORD);
        //    string repositoryName = steps.GenerateRandomRepositoryNameWithCharLength(REPOSITORY_RANDOM_POSTFIX_LENGTH);
        //    steps.CreateNewRepository(repositoryName, "auto-generated test repo");
        //    Assert.AreEqual(repositoryName, steps.GetCurrentRepositoryName());
        //}
    }
}
