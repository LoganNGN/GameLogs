namespace GameLogs
{
    public partial class descriptionGame : Form
    {
        private testinfoGames _testinfoGames;
        private string ImagePath = @"C:\Users\pf31etl\source\repos\GameLogs\GameLogs\imgTest";
        private void CreateContact()
        {
            _testinfoGames = new testinfoGames("Ricard", "Nya nya nya nay nay naynaynaynanyany", "console.jpeg");
        }

        public descriptionGame()
        {
            CreateContact();
            InitializeComponent();
            UpdateGui();
        }
        private void UpdateGui()
        {
            this.lbTitle.Text = _testinfoGames.Name;
            this.lbDescription.Text = _testinfoGames.Description;

            if (!string.IsNullOrEmpty(_testinfoGames.PathToImg))
            {
                string imagePath = Path.Combine(@"C:\Users\pf31etl\source\repos\GameLogs\GameLogs\imgTest", _testinfoGames.PathToImg);
                this.imgGame.Image = Image.FromFile(imagePath); 
            }
        }
    }
}
