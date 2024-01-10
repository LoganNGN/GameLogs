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
                    Dictionary<string, object> gameData = await apiConnector.GetGameData(_searchText, "Games");
                    await apiConnector.ProcessGames(new string[] { _searchText });
                    MessageBox.Show($"Recherche réussie pour le jeu : {_searchText}");

                    // Utilisez le dictionnaire gameData comme vous le souhaitez
                    // Par exemple, vous pouvez l'utiliser pour mettre à jour votre interface utilisateur (UI)
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
            if (gameData != null)
            {
                // Assurez-vous que "Name" existe dans le dictionnaire avant d'y accéder
                if (gameData.ContainsKey("Name"))
                {
                    this.lbTitle.Text = gameData["Name"].ToString();
                }
                else
                {
                    // Traitez le cas où "Name" n'existe pas dans le dictionnaire
                    this.lbTitle.Text = "Nom non disponible";
                }
            }
        }
    }
}
