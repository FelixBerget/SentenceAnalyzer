using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestIt
{
    public class DatabaseService : IService
    {
        public async Task SendToServer(string dataBase, string userName, string passWord, Sentence sentence)
        {
            await using var driver = GraphDatabase.Driver(dataBase, AuthTokens.Basic(userName, passWord));
            foreach (Word w in sentence.words)
            {
                var result = await driver.ExecutableQuery("MATCH)CREATE (:Word {id:$id,text: $text ,position: $position, type: $type})")
                    .WithParameters(new { id = w.id, text = w.text, position = w.position, type = w.type })
                    .WithConfig(new QueryConfig(database:"neo4j"))
                    .ExecuteAsync();
                var summary = result.Summary;
                Console.WriteLine($"Created {summary.Counters.NodesCreated} nodes in {summary.ResultAvailableAfter.Milliseconds} ms.");
            }
            
            foreach (Relations r in sentence.relations) {
                string queryString = "MATCH(fromWord:Word{id:$from}) MATCH(toWord:Word{id:$to}) CREATE(fromWord)-[:" + r.type + "]->(toWord)" ;
                    var result = await driver.ExecutableQuery(queryString)
                    .WithParameters(new {from = r.from, to = r.to, type = r.type})
                    .WithConfig(new QueryConfig(database: "neo4j"))
                    .ExecuteAsync();
                var summary = result.Summary;
                Console.WriteLine($"Created {summary.Counters.NodesCreated} nodes in {summary.ResultAvailableAfter.Milliseconds} ms.");
            }
        }

        public Sentence RecieveFromServer(string dataBase, string userName, string passWord)
        {
            return new Sentence();
        }

        public Sentence SearchInServer(string dataBase, string userName, string passWord)
        {
            return new Sentence();
        }
    }
}
