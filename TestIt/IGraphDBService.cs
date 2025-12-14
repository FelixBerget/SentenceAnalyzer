using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public interface IGraphDBService
    {
        public Task SendToServer(string dataBase, string userName, string passWord, Sentence sentence);

        public Sentence RecieveFromServer(string dataBase, string userName, string passWord);

        public Sentence SearchInServer(string dataBase, string userName, string passWord);
    }
}
