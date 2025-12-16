using Neo4j.Driver;

namespace TestIt
{
    internal class Program
    {
        static string fileName = "sentence_data.json";
        static string dataBaseLink = "bolt://localhost:7687";
        static string userName = "neo4j";
        static string password = "test1234";
        static string wordForSearch = "lasagne";
        static async Task Main(string[] args)
        {
            ISentenceAnalyzer c = new SentenceAnalyzer();
            Sentence s = c.Convert(fileName);

            using var driver = GraphDatabase.Driver(dataBaseLink, AuthTokens.Basic(userName, password));
            IGraphDBService db = new Neo4jService(driver);
            List<Word> fullList = await db.RecieveFromServer(dataBaseLink, userName, password);
            List<Word> searchedList = await db.SearchInServer(dataBaseLink,userName,password,wordForSearch);
            foreach (Word w in fullList)
            {
                Console.WriteLine(w.id + " pos :" + w.position + " text :" + w.text + " type:" + w.type);
            }
            Console.WriteLine("_____________________________________________________________");
            foreach (Word w in searchedList)
            {
                Console.WriteLine(w.id + " pos :" + w.position + " text :" + w.text + " type:" + w.type);
            }
        }

        
       
    }
}
