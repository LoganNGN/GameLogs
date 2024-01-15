namespace GameLogs
{
    partial class Acceuil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbGame = new GroupBox();
            lbTitle = new Label();
            btmDescriptionVoir = new Button();
            tbRecherche = new TextBox();
            btmRecherche = new Button();
            gbGame.SuspendLayout();
            SuspendLayout();
            // 
            // gbGame
            // 
            gbGame.Controls.Add(lbTitle);
            gbGame.Controls.Add(btmDescriptionVoir);
            gbGame.FlatStyle = FlatStyle.Flat;
            gbGame.Location = new Point(1, 81);
            gbGame.Name = "gbGame";
            gbGame.Size = new Size(822, 56);
            gbGame.TabIndex = 0;
            gbGame.TabStop = false;
            gbGame.Visible = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbTitle.ForeColor = Color.White;
            lbTitle.Location = new Point(12, 18);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(45, 25);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "Nya";
            // 
            // btmDescriptionVoir
            // 
            btmDescriptionVoir.BackColor = Color.Snow;
            btmDescriptionVoir.Location = new Point(722, 22);
            btmDescriptionVoir.Name = "btmDescriptionVoir";
            btmDescriptionVoir.Size = new Size(75, 23);
            btmDescriptionVoir.TabIndex = 0;
            btmDescriptionVoir.Text = "Voir";
            btmDescriptionVoir.UseVisualStyleBackColor = false;
            btmDescriptionVoir.Click += btmDescriptionVoir_Click;
            // 
            // tbRecherche
            // 
            tbRecherche.BackColor = SystemColors.Info;
            tbRecherche.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbRecherche.Location = new Point(405, 30);
            tbRecherche.Name = "tbRecherche";
            tbRecherche.Size = new Size(204, 29);
            tbRecherche.TabIndex = 1;
            // 
            // btmRecherche
            // 
            btmRecherche.BackColor = Color.Snow;
            btmRecherche.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btmRecherche.Location = new Point(615, 30);
            btmRecherche.Name = "btmRecherche";
            btmRecherche.Size = new Size(116, 29);
            btmRecherche.TabIndex = 2;
            btmRecherche.Text = "Recherche";
            btmRecherche.UseVisualStyleBackColor = false;
            btmRecherche.Click += btmRecherche_Click;
            // 
            // Acceuil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(821, 482);
            Controls.Add(btmRecherche);
            Controls.Add(tbRecherche);
            Controls.Add(gbGame);
            Name = "Acceuil";
            Text = "Acceuil";
            gbGame.ResumeLayout(false);
            gbGame.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gbGame;
        private Button btmDescriptionVoir;
        private Label lbTitle;
        private TextBox tbRecherche;
        private Button btmRecherche;
    }
}