namespace ScilyLines
{
    partial class FormConnexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUtilisateur = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUtilisateur = new System.Windows.Forms.TextBox();
            this.textBoxMotDePasse = new System.Windows.Forms.TextBox();
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUtilisateur
            // 
            this.labelUtilisateur.AutoSize = true;
            this.labelUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelUtilisateur.Location = new System.Drawing.Point(234, 119);
            this.labelUtilisateur.Name = "labelUtilisateur";
            this.labelUtilisateur.Size = new System.Drawing.Size(90, 24);
            this.labelUtilisateur.TabIndex = 0;
            this.labelUtilisateur.Text = "Utilisateur";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(201, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mot de passe";
            // 
            // textBoxUtilisateur
            // 
            this.textBoxUtilisateur.Location = new System.Drawing.Point(340, 121);
            this.textBoxUtilisateur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUtilisateur.Name = "textBoxUtilisateur";
            this.textBoxUtilisateur.Size = new System.Drawing.Size(170, 22);
            this.textBoxUtilisateur.TabIndex = 2;
            // 
            // textBoxMotDePasse
            // 
            this.textBoxMotDePasse.Location = new System.Drawing.Point(340, 171);
            this.textBoxMotDePasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMotDePasse.Name = "textBoxMotDePasse";
            this.textBoxMotDePasse.Size = new System.Drawing.Size(170, 22);
            this.textBoxMotDePasse.TabIndex = 3;
            this.textBoxMotDePasse.UseSystemPasswordChar = true;
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnexion.Location = new System.Drawing.Point(250, 227);
            this.buttonConnexion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(129, 31);
            this.buttonConnexion.TabIndex = 4;
            this.buttonConnexion.Text = "Connexion";
            this.buttonConnexion.UseVisualStyleBackColor = true;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 52);
            this.label2.TabIndex = 5;
            this.label2.Text = "ScilyLines";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ScilyLines.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(12, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(598, 305);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonConnexion);
            this.Controls.Add(this.textBoxMotDePasse);
            this.Controls.Add(this.textBoxUtilisateur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUtilisateur);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormConnexion";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUtilisateur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUtilisateur;
        private System.Windows.Forms.TextBox textBoxMotDePasse;
        private System.Windows.Forms.Button buttonConnexion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

