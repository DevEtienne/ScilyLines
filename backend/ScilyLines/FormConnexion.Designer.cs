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
            this.SuspendLayout();
            // 
            // labelUtilisateur
            // 
            this.labelUtilisateur.AutoSize = true;
            this.labelUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelUtilisateur.Location = new System.Drawing.Point(178, 123);
            this.labelUtilisateur.Name = "labelUtilisateur";
            this.labelUtilisateur.Size = new System.Drawing.Size(127, 26);
            this.labelUtilisateur.TabIndex = 0;
            this.labelUtilisateur.Text = "Utilisateur : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(151, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mot de passe :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxUtilisateur
            // 
            this.textBoxUtilisateur.Location = new System.Drawing.Point(357, 123);
            this.textBoxUtilisateur.Name = "textBoxUtilisateur";
            this.textBoxUtilisateur.Size = new System.Drawing.Size(191, 26);
            this.textBoxUtilisateur.TabIndex = 2;
            // 
            // textBoxMotDePasse
            // 
            this.textBoxMotDePasse.Location = new System.Drawing.Point(357, 206);
            this.textBoxMotDePasse.Name = "textBoxMotDePasse";
            this.textBoxMotDePasse.Size = new System.Drawing.Size(191, 26);
            this.textBoxMotDePasse.TabIndex = 3;
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.Location = new System.Drawing.Point(327, 290);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(145, 35);
            this.buttonConnexion.TabIndex = 4;
            this.buttonConnexion.Text = "Connexion";
            this.buttonConnexion.UseVisualStyleBackColor = true;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(292, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "ScilyLines";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonConnexion);
            this.Controls.Add(this.textBoxMotDePasse);
            this.Controls.Add(this.textBoxUtilisateur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUtilisateur);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

