using System;

namespace GameLogs
{ //liste pour tester l'affichage utilisateur
    /// <summary>
    /// This class is designed to manage a Contact
    /// </summary>
    public class testinfoGames
    {
        #region private attributes
        private string _name;
        private string _description;
        private string _pathToImg;
        #endregion private attributes

        /// <summary>
        /// This constructor allow to create a new contact object
        /// </summary>
        /// <param name="name">contact's name</param>
        /// <param name="description">contact's firtname</param>
        /// <param name="pathToImg">path to the contact's profil image</param>
        #region public methods
        public testinfoGames(string name, string description, string pathToImg = "/")
        {
            _name = name;
            _description = description;
            _pathToImg = pathToImg;
        }

        /// <summary>
        /// This property gets the contact's name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// This property gets the contact's firstname
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        /// <summary>
        /// This property gets the path to the contact' profil image and
        /// allow to update the value.
        /// It's impact the lastupdate value also.
        /// </summary>
        public string PathToImg
        {
            get
            {
                return _pathToImg;
            }
        }
        #endregion public methods
    }
}