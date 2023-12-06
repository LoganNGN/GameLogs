using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameLogs
{
    public partial class Acceuil : Form
    {
        private const int VerticalSpacing = 10; // Espacement vertical entre les lignes
        private const int ContainerCount = 100;

        private Panel containerPanel; // Ajout d'un panel pour le défilement

        public Acceuil()
        {
            InitializeComponent();
            BackColor = Color.Gray;
        }

        private void btmRecherche_Click(object sender, EventArgs e)
        {
            if (tbRecherche.Text == "Nya")
            {
                gbGame.Visible = true;
            }
        }

        private void btmDescription_Click(object sender, EventArgs e)
        {
            descriptionGame descriptionGame = new descriptionGame();
            descriptionGame.ShowDialog();
        }
    }
}
