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
            this.labelNoLiaison = new System.Windows.Forms.Label();
            this.textBoxDuree = new System.Windows.Forms.TextBox();
            this.labelPortDepart = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDurée = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPortDepart = new System.Windows.Forms.ComboBox();
            this.comboBoxPortArrivee = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(220, 368);
            this.buttonAjouter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(116, 38);
            this.buttonAjouter.TabIndex = 1;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Location = new System.Drawing.Point(385, 39);
            this.buttonSupprimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(144, 40);
            this.buttonSupprimer.TabIndex = 2;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = true;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Location = new System.Drawing.Point(572, 39);
            this.buttonModifier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(141, 40);
            this.buttonModifier.TabIndex = 3;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = true;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Secteurs";
            // 
            // listBoxSecteur
            // 
            this.listBoxSecteur.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxSecteur.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSecteur.FormattingEnabled = true;
            this.listBoxSecteur.ItemHeight = 30;
            this.listBoxSecteur.Location = new System.Drawing.Point(58, 58);
            this.listBoxSecteur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxSecteur.Name = "listBoxSecteur";
            this.listBoxSecteur.Size = new System.Drawing.Size(327, 184);
            this.listBoxSecteur.TabIndex = 0;
            this.listBoxSecteur.SelectedIndexChanged += new System.EventHandler(this.listBoxSecteur_SelectedIndexChanged);
            // 
            // listBoxLiaison
            // 
            this.listBoxLiaison.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxLiaison.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLiaison.FormattingEnabled = true;
            this.listBoxLiaison.ItemHeight = 30;
            this.listBoxLiaison.Location = new System.Drawing.Point(423, 58);
            this.listBoxLiaison.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxLiaison.Name = "listBoxLiaison";
            this.listBoxLiaison.Size = new System.Drawing.Size(327, 184);
            this.listBoxLiaison.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 36);
            this.label2.TabIndex = 6;
            this.label2.Text = "Liaisons";
            // 
            // labelNoLiaison
            // 
            this.labelNoLiaison.AutoSize = true;
            this.labelNoLiaison.BackColor = System.Drawing.SystemColors.Info;
            this.labelNoLiaison.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F);
            this.labelNoLiaison.Location = new System.Drawing.Point(500, 124);
            this.labelNoLiaison.Name = "labelNoLiaison";
            this.labelNoLiaison.Size = new System.Drawing.Size(0, 30);
            this.labelNoLiaison.TabIndex = 7;
            // 
            // textBoxDuree
            // 
            this.textBoxDuree.Location = new System.Drawing.Point(86, 372);
            this.textBoxDuree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxDuree.Name = "textBoxDuree";
            this.textBoxDuree.Size = new System.Drawing.Size(112, 26);
            this.textBoxDuree.TabIndex = 10;
            // 
            // labelPortDepart
            // 
            this.labelPortDepart.AutoSize = true;
            this.labelPortDepart.BackColor = System.Drawing.Color.Lavender;
            this.labelPortDepart.Location = new System.Drawing.Point(98, 275);
            this.labelPortDepart.Name = "labelPortDepart";
            this.labelPortDepart.Size = new System.Drawing.Size(91, 20);
            this.labelPortDepart.TabIndex = 11;
            this.labelPortDepart.Text = "Port Départ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lavender;
            this.label3.Location = new System.Drawing.Point(236, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Port Arrivée";
            // 
            // labelDurée
            // 
            this.labelDurée.AutoSize = true;
            this.labelDurée.BackColor = System.Drawing.Color.Lavender;
            this.labelDurée.Location = new System.Drawing.Point(110, 349);
            this.labelDurée.Name = "labelDurée";
            this.labelDurée.Size = new System.Drawing.Size(53, 20);
            this.labelDurée.TabIndex = 13;
            this.labelDurée.Text = "Durée";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.comboBoxPortDepart);
            this.panel1.Controls.Add(this.comboBoxPortArrivee);
            this.panel1.Controls.Add(this.buttonSupprimer);
            this.panel1.Controls.Add(this.buttonModifier);
            this.panel1.Location = new System.Drawing.Point(38, 275);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 160);
            this.panel1.TabIndex = 14;
            // 
            // comboBoxPortDepart
            // 
            this.comboBoxPortDepart.FormattingEnabled = true;
            this.comboBoxPortDepart.Location = new System.Drawing.Point(47, 28);
            this.comboBoxPortDepart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxPortDepart.Name = "comboBoxPortDepart";
            this.comboBoxPortDepart.Size = new System.Drawing.Size(115, 28);
            this.comboBoxPortDepart.TabIndex = 16;
            // 
            // comboBoxPortArrivee
            // 
            this.comboBoxPortArrivee.FormattingEnabled = true;
            this.comboBoxPortArrivee.Location = new System.Drawing.Point(182, 28);
            this.comboBoxPortArrivee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxPortArrivee.Name = "comboBoxPortArrivee";
            this.comboBoxPortArrivee.Size = new System.Drawing.Size(115, 28);
            this.comboBoxPortArrivee.TabIndex = 15;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.labelDurée);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPortDepart);
            this.Controls.Add(this.textBoxDuree);
            this.Controls.Add(this.labelNoLiaison);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxLiaison);
            this.Controls.Add(this.listBoxSecteur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelNoLiaison;
        private System.Windows.Forms.TextBox textBoxDuree;
        private System.Windows.Forms.Label labelPortDepart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelDurée;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxPortDepart;
        private System.Windows.Forms.ComboBox comboBoxPortArrivee;
    }
}