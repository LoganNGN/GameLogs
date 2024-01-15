using System.Net;

namespace GameLogs
{
    public partial class descriptionGame : Form
    {
        private Dictionary<string, object> gameData;
        public descriptionGame(Dictionary<string, object> gameData)
        {
            this.gameData = gameData;
            InitializeComponent();
            UpdateGui();
        }
        private void UpdateGui()
        {
            if (gameData != null)
            {
                this.lbTitle.Text = gameData.ContainsKey("Name") ? gameData["Name"].ToString() : "N/A";
                this.lbDescription.UseCompatibleTextRendering = true;
                this.lbDescription.Text = gameData.ContainsKey("Description") ? gameData["Description"].ToString() : "N/A";

                if (gameData.ContainsKey("BackgroundImage") && gameData["BackgroundImage"] != null)
                {
                    string imageUrl = gameData["BackgroundImage"].ToString();

                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            byte[] data = webClient.DownloadData(imageUrl);
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
                            {
                                // Chargez l'image dans le PictureBox
                                this.imgGame.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors du téléchargement de l'image : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Clé 'BackgroundImage' absente ou valeur nulle", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
