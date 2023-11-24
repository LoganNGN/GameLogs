using DuplicationContainer;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace GameLogs
{
    public partial class Acceuil : Form
    {

        private const int VerticalSpacing = 10; // Espacement vertical entre les lignes
        private const int ContainerCount = 20;

        private Panel containerPanel; // Ajout d'un panel pour le défilement
        public Acceuil()
        {
            InitializeComponent();
            InitializeContainers();
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
                AutoScroll = true, // Active le défilement automatique
                Dock = DockStyle.Fill // Remplit tout l'espace disponible dans le formulaire
            };

            Controls.Add(containerPanel);

            // Initialiser les conteneurs au chargement du formulaire
            ArrangeContainers();
        }

        private void ArrangeContainers()
        {
            int containerX = 10; // Ajustez la position horizontale selon vos besoins
            int containerY = 10; // Ajustez la position verticale selon vos besoins

            for (int i = 0; i < ContainerCount; i++)
            {
                // Créer une nouvelle instance de CustomContainer
                CustomContainer container = new CustomContainer
                {
                    TextContent = $"Container {i + 1}",
                    ImagePath = "path/to/your/image.jpg"
                };

                // Ajouter le container au panel
                containerPanel.Controls.Add(container);

                // Vérifier si le container dépasse la largeur du panel
                if (containerX + container.Width + VerticalSpacing > containerPanel.Width)
                {
                    // Passer à la ligne suivante
                    containerX = 10;
                    containerY += container.Height + VerticalSpacing;
                }

                // Définir la position du container
                container.Location = new Point(containerX, containerY);

                // Mettre à jour la position X pour le prochain container
                containerX += container.Width + VerticalSpacing;
            }
        }
    }
}