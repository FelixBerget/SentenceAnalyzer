using Neo4j.Driver;

namespace TestIt
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            testConnection t = new testConnection();
            List<string> stringlist = new List<string>();
            stringlist.Add("hello");
            stringlist.Add("i");
            stringlist.Add("am");
            stringlist.Add("doing");
            stringlist.Add("programming");
            await t.printTest(stringlist);
        }

        
       
    }
    public class testConnection
    {
        public readonly IDriver _driver;

        public testConnection()
        {
            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "test1234"));
        }
        public async Task printTest(List<String> stringlist)
        {
            await using var session = _driver.AsyncSession();
            var test = await session.WriteTransactionAsync(async tx =>
            {
                var cursor = await tx.RunAsync(
                    @"
                CREATE (w1:Word {text: $text1, position: $pos1})
                CREATE (w2:Word {text: $text2, position: $pos2})
                CREATE (w3:Word {text: $text3, position: $pos3})
                CREATE (w4:Word {text: $text4, position: $pos4})
                CREATE (w5:Word {text: $text5, position: $pos5})
                CREATE (w1)-[:NEXT]->(w2)
                CREATE (w2)-[:NEXT]->(w3)
                CREATE (w3)-[:NEXT]->(w4)
                CREATE (w4)-[:NEXT]->(w5)
                CREATE (w2)-[:SUBJECT_OF]->(w4)
                RETURN 'Created' as message",
                new
                {
                    text1 = "hello", pos1 = 0,
                    text2 = "i", pos2 = 1,
                    text3 = "am", pos3 = 2,
                    text4 = "doing",pos4 = 3,
                    text5 = "programming", pos5 = 4
                });
                var record = await cursor.SingleAsync();
                return record["message"].As<string>();
            });
            Console.WriteLine(test);
        }
    }
}
