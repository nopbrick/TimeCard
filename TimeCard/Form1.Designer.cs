namespace TimeCard
{
    partial class Form1
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
            this.Application_name = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Application_name
            // 
            this.Application_name.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Application_name.Location = new System.Drawing.Point(100, 9);
            this.Application_name.Name = "Application_name";
            this.Application_name.Size = new System.Drawing.Size(299, 52);
            this.Application_name.TabIndex = 0;
            this.Application_name.Text = "TimeCard Application";
            this.Application_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "Punch hours in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 70);
            this.button2.TabIndex = 2;
            this.button2.Text = "View time sheets";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 369);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Application_name);
            this.Name = "Form1";
            this.Text = "Welcome Screen";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label Application_name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}