namespace WinForms
{
    partial class formHelp
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
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHelp));
            Label label6;
            Label label7;
            Label label8;
            Label label9;
            Label label10;
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.BackColor = System.Drawing.Color.CornflowerBlue;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(374, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 24);
            label1.TabIndex = 0;
            label1.Text = "HELP";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(23, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 19);
            label2.TabIndex = 1;
            label2.Text = "Navigation";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Location = new System.Drawing.Point(23, 58);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(628, 49);
            label3.TabIndex = 2;
            label3.Text = "To navigate through the UI, use the sidebar which can be expanded to show the names of the different sections by pressing the three bars at the top left of the application next to the label \"Menu\".";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(23, 89);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(68, 18);
            label4.TabIndex = 3;
            label4.Text = "Import File";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.Location = new System.Drawing.Point(23, 107);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(388, 70);
            label5.TabIndex = 4;
            label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.BackColor = SystemColors.ActiveCaption;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(23, 177);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 17);
            label6.TabIndex = 5;
            label6.Text = "Display";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.Location = new System.Drawing.Point(23, 194);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(319, 148);
            label7.TabIndex = 6;
            label7.Text = resources.GetString("label7.Text");
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.BackColor = SystemColors.ActiveCaption;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(348, 177);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 18);
            label8.TabIndex = 7;
            label8.Text = "Simulation";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.Location = new System.Drawing.Point(348, 194);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(379, 185);
            label9.TabIndex = 8;
            label9.Text = resources.GetString("label9.Text");
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(23, 390);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(598, 30);
            label10.TabIndex = 9;
            label10.Text = resources.GetString("label10.Text");
            // 
            // formHelp
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formHelp";
            Text = "formHelp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}