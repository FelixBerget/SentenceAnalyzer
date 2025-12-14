using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public class TestService : IService
    {

        public async Task SendToServer(string dataBase, string userName, string passWord, Sentence sentence)
        {
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
