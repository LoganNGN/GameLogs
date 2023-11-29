using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameLogs
{
    public partial class Acceuil : Form
    {
        private const int VerticalSpacing = 10; // Espacement vertical entre les lignes
        private const int ContainerCount = 100;

        private Panel containerPanel; // Ajout d'un panel pour le d�filement

        public Acceuil()
        {
            InitializeComponent();
            InitializeContainers();
            BackColor = Color.Black;
            this.SizeChanged += MainForm_SizeChanged;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // Redistribuer les conteneurs lorsque la taille du formulaire change
            ArrangeContainers();
        }

        private void InitializeContainers()
        {
            containerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true // Enable auto-scrolling
            };

            Controls.Add(containerPanel);

            // Assuming you already have containGameDescription created
            for (int i = 0; i < ContainerCount; i++)
            {
                // Create a new instance of GameContainer
                GameContainer duplicateContainer = new GameContainer
                {
                    Size = containGameDescription.Size,
                    BackColor = containGameDescription.BackColor // Set your desired background color
                    // Copy other properties as needed
                };

                // Set the image path and size for the duplicated container
                duplicateContainer.ImagePath = "ta m�re"; // Replace with the actual path to your image
                duplicateContainer.ImageSize = new Size(100, 100); // Replace with the desired size

               

                // Add the duplicated container to the containerPanel.Controls
                containerPanel.Controls.Add(duplicateContainer);
            }

            // Arrange the containers after adding them
            ArrangeContainers();
        }

        private void ArrangeContainers()
        {
            int containerX = 10; // Ajustez la position horizontale selon vos besoins
            int containerY = 10; // Ajustez la position verticale selon vos besoins

            foreach (Control control in containerPanel.Controls)
            {
                // V�rifier si le container d�passe la largeur du panel
                if (containerX + control.Width + VerticalSpacing > containerPanel.Width)
                {
                    // Passer � la ligne suivante
                    containerX = 10;
                    containerY += control.Height + VerticalSpacing;
                }

                // D�finir la position du container
                control.Location = new Point(containerX, containerY);

                // Mettre � jour la position X pour le prochain container
                containerX += control.Width + VerticalSpacing;
            }
        }
    }

    public class GameContainer : Panel
    {
        public PictureBox GameImage { get; }
        public Label DescriptionLabel { get; }

        // Ajoutez ces propri�t�s pour le chemin et la taille de l'image
        public string ImagePath { get; set; }
        public Size ImageSize { get; set; }

        public GameContainer()
        {
            GameImage = new PictureBox
            {
                // Initialisez les propri�t�s de PictureBox selon vos besoins
                SizeMode = PictureBoxSizeMode.StretchImage // Ajustez la taille de l'image en fonction de vos pr�f�rences
            };

            DescriptionLabel = new Label
            {
                // Initialisez les propri�t�s du Label selon vos besoins
            };

            // Ajoutez GameImage et DescriptionLabel � ce GameContainer
            Controls.Add(GameImage);
            Controls.Add(DescriptionLabel);
        }
    }
}
