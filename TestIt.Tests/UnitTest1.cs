using Moq;
using Neo4j.Driver;

namespace TestIt.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task When_no_words_no_calls_to_database()
        {
            var mockDriver = new Mock<IDriver>();
            var testService = new Neo4jService(mockDriver.Object);
            await testService.SendToServer(new Sentence());
            mockDriver.Verify(x => x.ExecutableQuery(It.IsAny<string>()),Times.Never);
        }



    }
}
