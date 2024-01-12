using static APIConnector;

namespace GameLogs
{
    public partial class Acceuil : Form
    {
        #region private attributes
        private readonly APIConnector apiConnector = new APIConnector();
        private string _searchText = null;
        
        #endregion private attributes

        #region public attributes

        #endregion public attributes

        public Acceuil()
        {
            InitializeComponent();
        }
        private async void btmRecherche_Click(object sender, EventArgs e)
        {
            _searchText = tbRecherche.Text.Trim();

            if (!string.IsNullOrEmpty(_searchText))
            {
                try
                {
                    string[] gameNameRecherche = _searchText.Split(",");
                    string[] gameNames = _seachText.Split(",");
                    await apiConnector.ProcessGames(gameNameRecherche);
                    MessageBox.Show($"Recherche réussie pour le jeu : {_searchText}");
                    UpdateGui();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la recherche pour le jeu {_searchText}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de jeu valide.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateGui()
        {
            if (_searchText != null)
            {

                gbGame.Visible = true;
                this.lbTitle.Text = _searchText;
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de jeu valide.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
