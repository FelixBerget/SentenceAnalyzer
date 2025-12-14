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
            IConverter c = new Converter();
            Sentence s = c.Convert(fileName);
            IService db = new DatabaseService();
            await db.SendToServer(dataBaseLink,userName,password,s);
        }

        
       
    }
}
