namespace GameLogs
{
    public partial class Acceuil : Form
    {
        #region private attributes
        private testinfoGames _testinfoGames = null;
        #endregion private attributes

        #region public attributes
        public string _searchText;
        #endregion public attributes

        public Acceuil()
        {
            InitializeComponent();
        }

        // test liste à suprimmer
        private List<testinfoGames> CreateListContact()
        {
            List<testinfoGames> testinfoGamesList = new List<testinfoGames>
            {
                new testinfoGames("Ricard", "Nya nya nya nay nay naynaynaynanyany", "console.jpeg"),
                new testinfoGames("Nyaa", " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim", "Nya4.jpg"),
            };

            return testinfoGamesList;
        }

        private bool SearchGames(string searchText, out testinfoGames foundGame)
        {
            List<testinfoGames> gamesList = CreateListContact();

            foreach (testinfoGames testinfoGames in gamesList)
            {
                if (testinfoGames.Name == searchText)
                {
                    foundGame = testinfoGames;
                    return true;
                }
            }
            foundGame = null;
            return false;
        }

        private void btmRecherche_Click(object sender, EventArgs e)
        {
            _searchText = tbRecherche.Text;

            testinfoGames foundGame;
            bool isGameFound = SearchGames(_searchText, out foundGame);

            if (isGameFound)
            {
                _testinfoGames = foundGame;
                UpdateGui();
                gbGame.Visible = true;
            }
            else
            {
                MessageBox.Show("Jeu non trouvé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btmDescription_Click(object sender, EventArgs e)
        {
            descriptionGame descriptionGameForm = new descriptionGame(_testinfoGames);
            descriptionGameForm.ShowDialog();
        }

        private void UpdateGui()
        {
            if (_testinfoGames != null)
            {
                this.lbTitle.Text = _testinfoGames.Name;
            }
        }
    }
}
