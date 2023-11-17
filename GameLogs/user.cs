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
            username = _username;
            email = _email;
            password = _password;
        }

        public string username 
        {
            get 
            {  
                return _username; 
            }
            set 
            {
                throw new NotImplementedException();            
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        public string addUser() 
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
