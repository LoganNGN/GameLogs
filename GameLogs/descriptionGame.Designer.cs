namespace GameLogs
{
    partial class descriptionGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            imgGame = new PictureBox();
            lbTitle = new Label();
            lbDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)imgGame).BeginInit();
            SuspendLayout();
            // 
            // imgGame
            // 
            imgGame.Image = Properties.Resources.imgTestRobot;
            imgGame.Location = new Point(12, 12);
            imgGame.Name = "imgGame";
            imgGame.Size = new Size(297, 320);
            imgGame.SizeMode = PictureBoxSizeMode.Zoom;
            imgGame.TabIndex = 0;
            imgGame.TabStop = false;
            imgGame.UseWaitCursor = true;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbTitle.Location = new Point(337, 53);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(68, 40);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "Nya";
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbDescription.Location = new Point(346, 105);
            lbDescription.MaximumSize = new Size(300, 0);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(33, 40);
            lbDescription.TabIndex = 2;
            lbDescription.Text = "test\r\nn\r\n";
            lbDescription.UseMnemonic = false;
            // 
            // descriptionGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbDescription);
            Controls.Add(lbTitle);
            Controls.Add(imgGame);
            Name = "descriptionGame";
            Text = "descriptionGame";
            ((System.ComponentModel.ISupportInitialize)imgGame).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imgGame;
        private Label lbTitle;
        private Label lbDescription;
    }
}