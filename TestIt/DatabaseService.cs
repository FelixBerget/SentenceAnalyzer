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
            var result = await driver.ExecutableQuery(@"CREATE(id:Word {text: $text ,position: $position, type: $type})");
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
