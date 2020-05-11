namespace VIS_Desktop
{
    partial class DiteBecomeVed
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
            this.comboBoxDeti = new System.Windows.Forms.ComboBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxDeti = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Vyber dítě:";
            // 
            // comboBoxDeti
            // 
            this.comboBoxDeti.FormattingEnabled = true;
            this.comboBoxDeti.Location = new System.Drawing.Point(127, 15);
            this.comboBoxDeti.Name = "comboBoxDeti";
            this.comboBoxDeti.Size = new System.Drawing.Size(168, 21);
            this.comboBoxDeti.TabIndex = 8;
            this.comboBoxDeti.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeti_SelectedIndexChanged);
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(352, 15);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(75, 23);
            this.btnDo.TabIndex = 7;
            this.btnDo.Text = "Zrob!";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(12, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxDeti
            // 
            this.listBoxDeti.FormattingEnabled = true;
            this.listBoxDeti.Location = new System.Drawing.Point(12, 44);
            this.listBoxDeti.Name = "listBoxDeti";
            this.listBoxDeti.Size = new System.Drawing.Size(415, 251);
            this.listBoxDeti.TabIndex = 5;
            // 
            // DiteBecomeVed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 333);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDeti);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxDeti);
            this.Name = "DiteBecomeVed";
            this.Text = "DiteBecomeVed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDeti;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxDeti;
    }
}