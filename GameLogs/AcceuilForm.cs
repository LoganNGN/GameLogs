namespace GameLogs
{
    public partial class Acceuil : Form
    {
        #region private attributes
        private const int VerticalSpacing = 10; // Espacement vertical entre les lignes
        private const int ContainerCount = 100;
        private testinfoGames _testinfoGames = null;
        #endregion private attributes

        public Acceuil()
        {
            InitializeComponent();
            BackColor = Color.Gray;
        }

        private void CreateContact()
        {
            _testinfoGames = new testinfoGames("Ricard", "Nya nya nya nay nay naynaynaynanyany", "ricard.png");
        }

        private void btmRecherche_Click(object sender, EventArgs e)
        {
            if (tbRecherche.Text == "Nya")
            {
                CreateContact();
                UpdateGui();
                gbGame.Visible = true;
            }
        }

        private void btmDescription_Click(object sender, EventArgs e)
        {
            descriptionGame descriptionGame = new descriptionGame();
            descriptionGame.ShowDialog();
        }
        private void UpdateGui()
        {
            this.lbTitle.Text = _testinfoGames.Name; 
        }
    }
}
