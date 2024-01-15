using System.Diagnostics;
using static APIConnector;

namespace GameLogs
{
    public partial class Acceuil : Form
    {
        #region private attributes
        private readonly APIConnector apiConnector = new APIConnector();
        private string _searchText = null;
        private Dictionary<string, object> gameData;
        private descriptionGame formulaireDescription;  
        #endregion private attributes

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
                    //apiConnector.ProcessGames(new string[] { _searchText });
                    var gameInfo = await apiConnector.GetGameInfo(_searchText);
                    this.gameData = apiConnector.GetGameData(gameInfo, "Games");
                    await apiConnector.WriteToFile(_searchText, gameInfo);
                    MessageBox.Show($"Recherche réussie pour le jeu : {_searchText}");
                    UpdateGui(gameData);

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

        private void UpdateGui(Dictionary<string, object> gameData)
        {
            if (_searchText != null)
            {

                gbGame.Visible = true;
                this.lbTitle.Text = gameData["Name"].ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de jeu valide.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btmDescriptionVoir_Click(object sender, EventArgs e)
        {
            if (this.gameData != null)
            {
                
                if (formulaireDescription == null || formulaireDescription.IsDisposed)
                {
                    
                    formulaireDescription = new descriptionGame(gameData);
                }
                formulaireDescription.Show();
            }
            else
            {
                MessageBox.Show("Aucune donnée de jeu disponible.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
