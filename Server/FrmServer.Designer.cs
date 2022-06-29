namespace Server
{
    partial class FrmServer
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
            this.label2 = new System.Windows.Forms.Label();
            this.rbTwo = new System.Windows.Forms.RadioButton();
            this.rbThree = new System.Windows.Forms.RadioButton();
            this.rbFour = new System.Windows.Forms.RadioButton();
            this.cbQuizSelection = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(99, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose quiz:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(98, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of players:";
            // 
            // rbTwo
            // 
            this.rbTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbTwo.AutoSize = true;
            this.rbTwo.BackColor = System.Drawing.Color.Transparent;
            this.rbTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbTwo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbTwo.Location = new System.Drawing.Point(216, 57);
            this.rbTwo.Name = "rbTwo";
            this.rbTwo.Size = new System.Drawing.Size(32, 17);
            this.rbTwo.TabIndex = 2;
            this.rbTwo.TabStop = true;
            this.rbTwo.Text = "2";
            this.rbTwo.UseVisualStyleBackColor = false;
            // 
            // rbThree
            // 
            this.rbThree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbThree.AutoSize = true;
            this.rbThree.BackColor = System.Drawing.Color.Transparent;
            this.rbThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbThree.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbThree.Location = new System.Drawing.Point(274, 57);
            this.rbThree.Name = "rbThree";
            this.rbThree.Size = new System.Drawing.Size(32, 17);
            this.rbThree.TabIndex = 3;
            this.rbThree.TabStop = true;
            this.rbThree.Text = "3";
            this.rbThree.UseVisualStyleBackColor = false;
            // 
            // rbFour
            // 
            this.rbFour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbFour.AutoSize = true;
            this.rbFour.BackColor = System.Drawing.Color.Transparent;
            this.rbFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbFour.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbFour.Location = new System.Drawing.Point(330, 57);
            this.rbFour.Name = "rbFour";
            this.rbFour.Size = new System.Drawing.Size(32, 17);
            this.rbFour.TabIndex = 4;
            this.rbFour.TabStop = true;
            this.rbFour.Text = "4";
            this.rbFour.UseVisualStyleBackColor = false;
            // 
            // cbQuizSelection
            // 
            this.cbQuizSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbQuizSelection.FormattingEnabled = true;
            this.cbQuizSelection.Location = new System.Drawing.Point(215, 22);
            this.cbQuizSelection.Name = "cbQuizSelection";
            this.cbQuizSelection.Size = new System.Drawing.Size(146, 21);
            this.cbQuizSelection.TabIndex = 5;
            this.cbQuizSelection.SelectedIndexChanged += new System.EventHandler(this.cbQuizSelection_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(392, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 48);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(61, 151);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(447, 199);
            this.dgvResults.TabIndex = 7;
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Server.Properties.Resources.history;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(565, 393);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbQuizSelection);
            this.Controls.Add(this.rbFour);
            this.Controls.Add(this.rbThree);
            this.Controls.Add(this.rbTwo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz selection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmServer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbTwo;
        private System.Windows.Forms.RadioButton rbThree;
        private System.Windows.Forms.RadioButton rbFour;
        private System.Windows.Forms.ComboBox cbQuizSelection;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}

