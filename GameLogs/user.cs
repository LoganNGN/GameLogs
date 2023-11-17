using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogs
{
    public class user
    {
        #region private attribute
        private string _username;
        private string _password;
        private string _email;
        private List<user> users = new List<user>();
        #endregion

        #region public methodes
        public user(string username, string email, string password) 
        {
            _username = username;
            _email = email;
            _password = password;
        }

        public string username 
        {
            get 
            {  
                return _username; 
            }
            set 
            {
                _username = value;            
            } 
        }

        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string email
        {
            get
            {
                return _email;
            }
            set 
            { 
                _email = value;
            }
        }

        public string addUser() 
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
