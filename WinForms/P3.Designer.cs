namespace WinForms
{
    partial class P3
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
            openFileButton = new Button();
            SuspendLayout();
            // 
            // openFileButton
            // 
            openFileButton.Anchor = AnchorStyles.None;
            openFileButton.BackColor = System.Drawing.Color.CornflowerBlue;
            openFileButton.FlatAppearance.BorderSize = 0;
            openFileButton.FlatStyle = FlatStyle.Flat;
            openFileButton.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            openFileButton.Location = new System.Drawing.Point(293, 202);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new System.Drawing.Size(195, 64);
            openFileButton.TabIndex = 0;
            openFileButton.Text = "Execute P3";
            openFileButton.UseVisualStyleBackColor = false;
            openFileButton.Click += buttonProject3_Click;
            // 
            // P3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(openFileButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "P3";
            Text = "P3";
            Load += P3_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button openFileButton;
    }
}