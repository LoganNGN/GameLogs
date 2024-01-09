namespace GameLogs
{
    public partial class descriptionGame : Form
    {
        private testinfoGames _testinfoGames;
        private string ImagePath = @"C:\Users\pf31etl\source\repos\GameLogs\GameLogs\imgTest";

        public descriptionGame(testinfoGames game)
        {
            _testinfoGames = game;
            InitializeComponent();
            UpdateGui();
        }

        private void UpdateGui()
        {
            if (_testinfoGames != null)
            {
                this.lbTitle.Text = _testinfoGames.Name;
                this.lbDescription.Text = _testinfoGames.Description;

                if (_testinfoGames.PathToImg == null )
                {
                    MessageBox.Show("image non trouvé", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(!string.IsNullOrEmpty(_testinfoGames.PathToImg))
                {
                    string imagePath = Path.Combine(ImagePath, _testinfoGames.PathToImg);
                    this.imgGame.Image = Image.FromFile(imagePath);
                   
                }

            }
        }
    }
}
