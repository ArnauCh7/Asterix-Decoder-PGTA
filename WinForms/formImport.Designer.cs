namespace WinForms
{
    partial class formImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formImport));
            openFileDialog1 = new OpenFileDialog();
            uploadedLabel = new Label();
            likeImage = new PictureBox();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            loadingtextbox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)likeImage).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Archivos AST (*.ast)|*.ast";
            // 
            // uploadedLabel
            // 
            uploadedLabel.Anchor = AnchorStyles.None;
            uploadedLabel.AutoSize = true;
            uploadedLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            uploadedLabel.Location = new Point(345, 251);
            uploadedLabel.Name = "uploadedLabel";
            uploadedLabel.Size = new Size(232, 32);
            uploadedLabel.TabIndex = 2;
            uploadedLabel.Text = "Uploaded correctly";
            // 
            // likeImage
            // 
            likeImage.Anchor = AnchorStyles.None;
            likeImage.Image = (Image)resources.GetObject("likeImage.Image");
            likeImage.Location = new Point(408, 155);
            likeImage.Margin = new Padding(3, 4, 3, 4);
            likeImage.Name = "likeImage";
            likeImage.Size = new Size(79, 92);
            likeImage.TabIndex = 3;
            likeImage.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.None;
            progressBar1.Location = new Point(256, 433);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(403, 31);
            progressBar1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.CornflowerBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(371, 312);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(160, 67);
            button1.TabIndex = 5;
            button1.Text = "Import";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // loadingtextbox
            // 
            loadingtextbox.AllowDrop = true;
            loadingtextbox.Anchor = AnchorStyles.None;
            loadingtextbox.BackColor = SystemColors.ButtonFace;
            loadingtextbox.BorderStyle = BorderStyle.None;
            loadingtextbox.CharacterCasing = CharacterCasing.Upper;
            loadingtextbox.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point);
            loadingtextbox.Location = new Point(380, 406);
            loadingtextbox.Name = "loadingtextbox";
            loadingtextbox.ReadOnly = true;
            loadingtextbox.Size = new Size(163, 20);
            loadingtextbox.TabIndex = 6;
            loadingtextbox.Text = "LOADING, PLEASE WAIT.\r\n";
            // 
            // formImport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(loadingtextbox);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(likeImage);
            Controls.Add(uploadedLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "formImport";
            Text = "formImport";
            Load += formImport_Load;
            ((System.ComponentModel.ISupportInitialize)likeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Label uploadedLabel;
        private PictureBox likeImage;
        private ProgressBar progressBar1;
        private Button button1;
        private TextBox loadingtextbox;
    }
}