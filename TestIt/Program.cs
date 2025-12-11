using Neo4j.Driver;

namespace TestIt
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            testConnection t = new testConnection();
            await t.printTest("Bayern Monaco 5 - 0 Sporting");
        }

        
       
    }
    public class testConnection
    {
        public readonly IDriver _driver;

        public testConnection()
        {
            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "test1234"));
        }
        public async Task printTest(string message)
        {
            await using var session = _driver.AsyncSession();
            var test = await session.ReadTransactionAsync(async tx =>
            {
                var cursor = await tx.RunAsync(
                    "RETURN $msg AS message",
                    new { msg = message });
                var record = await cursor.SingleAsync();
                return record["message"].As<string>();
            });
            Console.WriteLine(test);
        }
    }
}
