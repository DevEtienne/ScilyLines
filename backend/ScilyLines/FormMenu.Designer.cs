namespace ScilyLines
{
    partial class FormMenu
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
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxSecteur = new System.Windows.Forms.ListBox();
            this.listBoxLiaison = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(71, 242);
            this.buttonAjouter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(117, 32);
            this.buttonAjouter.TabIndex = 1;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Location = new System.Drawing.Point(259, 242);
            this.buttonSupprimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(128, 32);
            this.buttonSupprimer.TabIndex = 2;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = true;
            // 
            // buttonModifier
            // 
            this.buttonModifier.Location = new System.Drawing.Point(438, 242);
            this.buttonModifier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(125, 32);
            this.buttonModifier.TabIndex = 3;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Secteurs";
            // 
            // listBoxSecteur
            // 
            this.listBoxSecteur.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxSecteur.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSecteur.FormattingEnabled = true;
            this.listBoxSecteur.ItemHeight = 25;
            this.listBoxSecteur.Location = new System.Drawing.Point(52, 46);
            this.listBoxSecteur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxSecteur.Name = "listBoxSecteur";
            this.listBoxSecteur.Size = new System.Drawing.Size(291, 154);
            this.listBoxSecteur.TabIndex = 0;
            this.listBoxSecteur.SelectedIndexChanged += new System.EventHandler(this.listBoxSecteur_SelectedIndexChanged);
            // 
            // listBoxLiaison
            // 
            this.listBoxLiaison.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxLiaison.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLiaison.FormattingEnabled = true;
            this.listBoxLiaison.ItemHeight = 25;
            this.listBoxLiaison.Location = new System.Drawing.Point(369, 46);
            this.listBoxLiaison.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxLiaison.Name = "listBoxLiaison";
            this.listBoxLiaison.Size = new System.Drawing.Size(291, 154);
            this.listBoxLiaison.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Liaisons";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxLiaison);
            this.Controls.Add(this.listBoxSecteur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.buttonSupprimer);
            this.Controls.Add(this.buttonAjouter);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxSecteur;
        private System.Windows.Forms.ListBox listBoxLiaison;
        private System.Windows.Forms.Label label2;
    }
}