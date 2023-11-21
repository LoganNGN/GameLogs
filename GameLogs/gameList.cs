using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogs
{
    public class GameList
    {
        #region private attribute
        private List<GameList> gameLists = new List<GameList>();
        #endregion
        #region public methods
        public List<GameList> addGameInList
        {
            get 
            {  
                throw new NotImplementedException(); 
            }
        }
        public void removeGame(GameList gameList)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
