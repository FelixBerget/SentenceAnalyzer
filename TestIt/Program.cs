using Neo4j.Driver;

namespace TestIt
{
    internal class Program
    {
        static string fileName = "sentence_data.json";
        static string dataBaseLink = "bolt://localhost:7687";
        static string userName = "neo4j";
        static string password = "test1234";
        static async Task Main(string[] args)
        {
            ISentenceAnalyzer c = new SentenceAnalyzer();
            Sentence s = c.Convert(fileName);
            IGraphDBService db = new Neo4jService();
            await db.SendToServer(dataBaseLink,userName,password,s);
        }

        
       
    }
}
