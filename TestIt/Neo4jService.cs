using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestIt
{
    public class Neo4jService : IGraphDBService
    {
        private readonly IDriver _driver;

        public Neo4jService(IDriver driver) 
        {
            _driver = driver;
        }
        public async Task SendToServer(Sentence sentence)
        {
            foreach (Word w in sentence.words)
            {
                var result = await _driver.ExecutableQuery("CREATE (:Word {id:$id,text: $text ,position: $position, type: $type})")
                    .WithParameters(new { id = w.id, text = w.text, position = w.position, type = w.type })
                    .WithConfig(new QueryConfig(database:"neo4j"))
                    .ExecuteAsync();
                var summary = result.Summary;
                Console.WriteLine($"Created {summary.Counters.NodesCreated} nodes in {summary.ResultAvailableAfter.Milliseconds} ms.");
            }
            
            foreach (Relations r in sentence.relations) {
                string queryString = "MATCH(fromWord:Word{id:$from}) MATCH(toWord:Word{id:$to}) CREATE(fromWord)-[:" + r.type + "]->(toWord)" ;
                    var result = await _driver.ExecutableQuery(queryString)
                    .WithParameters(new {from = r.from, to = r.to, type = r.type})
                    .WithConfig(new QueryConfig(database: "neo4j"))
                    .ExecuteAsync();
                var summary = result.Summary;
                Console.WriteLine($"Created {summary.Counters.NodesCreated} nodes in {summary.ResultAvailableAfter.Milliseconds} ms.");
            }
        }

        public async Task<List<Word>> RecieveFromServer(string dataBase, string userName, string passWord)
        {
            var result = await _driver.ExecutableQuery("MATCH(n) RETURN n")
                .ExecuteAsync();

            List<Word> words = new List<Word>();
            foreach (var part in result.Result)
            {
                INode n = part.Get<INode>("n");
                string text = (string)n.Properties["text"];
                string id = (string)n.Properties["id"];
                long longpositon = (long)n.Properties["position"];
                int position = (int)(longpositon);
                string type = (string)n.Properties["type"];
                Word w = new Word(id, text, position, type);
                words.Add(w);
            }
            return words;
        }

        public async Task<List<Word>> SearchInServer(string dataBase, string userName, string passWord, string askedWord)
        {
            var result = await _driver.ExecutableQuery("MATCH(n {text:$askedWord}) RETURN n")
                .WithParameters(new {askedWord = askedWord})
                .ExecuteAsync();
            List<Word> words = new List<Word>();
            foreach (var part in result.Result)
            {
                INode n = part.Get<INode>("n");
                string text = (string)n.Properties["text"];
                string id = (string)n.Properties["id"];
                long longpositon = (long)n.Properties["position"];
                int position = (int)(longpositon);
                string type = (string)n.Properties["type"];
                Word w = new Word(id, text, position, type);
                words.Add(w);
            }
            return words;
        }
    }
}
