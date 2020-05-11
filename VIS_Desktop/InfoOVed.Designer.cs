namespace VIS_Desktop
{
    partial class InfoOVed
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
            this.listBoxVed = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDo = new System.Windows.Forms.Button();
            this.comboBoxVed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxVed
            // 
            this.listBoxVed.FormattingEnabled = true;
            this.listBoxVed.Location = new System.Drawing.Point(12, 38);
            this.listBoxVed.Name = "listBoxVed";
            this.listBoxVed.Size = new System.Drawing.Size(415, 251);
            this.listBoxVed.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(352, 9);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(75, 23);
            this.btnDo.TabIndex = 2;
            this.btnDo.Text = "Zrob!";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // comboBoxVed
            // 
            this.comboBoxVed.FormattingEnabled = true;
            this.comboBoxVed.Location = new System.Drawing.Point(127, 9);
            this.comboBoxVed.Name = "comboBoxVed";
            this.comboBoxVed.Size = new System.Drawing.Size(168, 21);
            this.comboBoxVed.TabIndex = 3;
            this.comboBoxVed.SelectedIndexChanged += new System.EventHandler(this.comboBoxVed_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vyber vedoucího:";
            // 
            // InfoOVed
            // 
            this.AcceptButton = this.btnDo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(439, 327);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxVed);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxVed);
            this.Name = "InfoOVed";
            this.Text = "InfoOVed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.ComboBox comboBoxVed;
        private System.Windows.Forms.Label label1;
    }
}