namespace VIS_Desktop
{
    partial class MainForm
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
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.labelSigned = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnEventSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upcoming Events:";
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Items.AddRange(new object[] {
            "Event1",
            "Event2",
            "Event3",
            "Event4"});
            this.listBoxEvents.Location = new System.Drawing.Point(31, 95);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(175, 199);
            this.listBoxEvents.TabIndex = 0;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // labelSigned
            // 
            this.labelSigned.AutoSize = true;
            this.labelSigned.Location = new System.Drawing.Point(647, 11);
            this.labelSigned.Name = "labelSigned";
            this.labelSigned.Size = new System.Drawing.Size(43, 13);
            this.labelSigned.TabIndex = 2;
            this.labelSigned.Text = "Signed:";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(647, 37);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(32, 13);
            this.labelRole.TabIndex = 3;
            this.labelRole.Text = "Role:";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(31, 313);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(70, 23);
            this.btnAddEvent.TabIndex = 4;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Visible = false;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnEventSignIn
            // 
            this.btnEventSignIn.Location = new System.Drawing.Point(31, 312);
            this.btnEventSignIn.Name = "btnEventSignIn";
            this.btnEventSignIn.Size = new System.Drawing.Size(91, 23);
            this.btnEventSignIn.TabIndex = 5;
            this.btnEventSignIn.Text = "Sign in to event";
            this.btnEventSignIn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEventSignIn);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelSigned);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxEvents);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxEvents;
        public System.Windows.Forms.Label labelSigned;
        public System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnEventSignIn;
    }
}