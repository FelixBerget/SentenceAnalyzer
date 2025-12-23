using Neo4j.Driver;

namespace TestIt
{
    internal class Program
    {
        static string fileName = "sentence_data.json";
        static string dataBaseLink = "";
        static string userName = "";
        static string password = "";
        static async Task Main(string[] args)
        {
            ISentenceAnalyzer c = new SentenceAnalyzer();
            ClaudePrompter claudePrompter = new ClaudePrompter();
            string jsonString = await claudePrompter.PromptClaude("");
            Sentence s = c.ConvertWithString(jsonString);
            using var driver = GraphDatabase.Driver(dataBaseLink, AuthTokens.Basic(userName, password));
            IGraphDBService db = new Neo4jService(driver);
            await db.SendToServer(s);
        }

        
       
    }
}
