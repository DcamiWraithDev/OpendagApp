namespace OpendagApplicatie
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.totaalLabel = new System.Windows.Forms.Label();
            this.mei20Label = new System.Windows.Forms.Label();
            this.mei27Label = new System.Windows.Forms.Label();
            this.juni3Label = new System.Windows.Forms.Label();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Docenten overzicht";
            // 
            // totaalLabel
            // 
            this.totaalLabel.AutoSize = true;
            this.totaalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaalLabel.Location = new System.Drawing.Point(23, 67);
            this.totaalLabel.Name = "totaalLabel";
            this.totaalLabel.Size = new System.Drawing.Size(294, 31);
            this.totaalLabel.TabIndex = 2;
            this.totaalLabel.Text = "Totaal aanmeldingen:";
            // 
            // mei20Label
            // 
            this.mei20Label.AutoSize = true;
            this.mei20Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mei20Label.Location = new System.Drawing.Point(12, 105);
            this.mei20Label.Name = "mei20Label";
            this.mei20Label.Size = new System.Drawing.Size(301, 31);
            this.mei20Label.TabIndex = 3;
            this.mei20Label.Text = "Aanmeldingen 20 Mei:";
            // 
            // mei27Label
            // 
            this.mei27Label.AutoSize = true;
            this.mei27Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mei27Label.Location = new System.Drawing.Point(12, 143);
            this.mei27Label.Name = "mei27Label";
            this.mei27Label.Size = new System.Drawing.Size(301, 31);
            this.mei27Label.TabIndex = 4;
            this.mei27Label.Text = "Aanmeldingen 27 Mei:";
            // 
            // juni3Label
            // 
            this.juni3Label.AutoSize = true;
            this.juni3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.juni3Label.Location = new System.Drawing.Point(22, 181);
            this.juni3Label.Name = "juni3Label";
            this.juni3Label.Size = new System.Drawing.Size(293, 31);
            this.juni3Label.TabIndex = 5;
            this.juni3Label.Text = "Aanmeldingen 3 Juni:";
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.Snow;
            this.refreshBtn.Location = new System.Drawing.Point(648, 9);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(65, 65);
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.Text = "🔄";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.juni3Label);
            this.Controls.Add(this.mei27Label);
            this.Controls.Add(this.mei20Label);
            this.Controls.Add(this.totaalLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Docenten overzicht";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totaalLabel;
        private System.Windows.Forms.Label mei20Label;
        private System.Windows.Forms.Label mei27Label;
        private System.Windows.Forms.Label juni3Label;
        private System.Windows.Forms.Button refreshBtn;
    }
}