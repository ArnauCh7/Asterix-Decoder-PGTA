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
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // openFileButton
            // 
            openFileButton.BackColor = System.Drawing.Color.CornflowerBlue;
            openFileButton.FlatAppearance.BorderSize = 0;
            openFileButton.FlatStyle = FlatStyle.Flat;
            openFileButton.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            openFileButton.Location = new System.Drawing.Point(349, 53);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new System.Drawing.Size(87, 29);
            openFileButton.TabIndex = 0;
            openFileButton.Text = "Browse";
            openFileButton.UseVisualStyleBackColor = false;
            openFileButton.Click += buttonProject3_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new System.Drawing.Point(27, 103);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new System.Drawing.Size(761, 302);
            dataGridView.TabIndex = 1;
            // 
            // P3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(dataGridView);
            Controls.Add(openFileButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "P3";
            Text = "P3";
            Load += P3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button openFileButton;
        private DataGridView dataGridView;
    }
}