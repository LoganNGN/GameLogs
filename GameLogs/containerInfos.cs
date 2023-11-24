using System.Drawing;
using System.Windows.Forms;

namespace DuplicationContainer
{
    public class CustomContainer : UserControl
    {
        private PictureBox pictureBox;
        private Label label;

        public string ImagePath { get; set; }
        public string TextContent { get; set; }

        public CustomContainer()
        {
            InitializeComponents();
            BackColor = Color.Black;
        }

        private void InitializeComponents()
        {
            // Initialiser les composants de votre conteneur (image et texte)
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(200, 100), // Taille fixe pour l'image
                Location = new Point(0, 0)
            };

            label = new Label
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Text = TextContent
            };

            // Charger l'image à partir du chemin spécifié
            if (!string.IsNullOrEmpty(ImagePath) && System.IO.File.Exists(ImagePath))
            {
                pictureBox.Image = Image.FromFile(ImagePath);
            }

            // Ajouter les composants au conteneur
            Controls.Add(pictureBox);
            Controls.Add(label);

            // Définir la taille fixe du conteneur
            Size = new Size(200, 150); // Ajustez la taille selon vos besoins
        }
    }
}
